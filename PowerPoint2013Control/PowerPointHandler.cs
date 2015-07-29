using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// add PowerPoint namespace
using PPt = Microsoft.Office.Interop.PowerPoint;
using System.Runtime.InteropServices;
using ControlCommon;

namespace PowerPoint2013Control
{
    public class PowerPointHandler : IPowerPointHandler
    {
        // Define PowerPoint Application object
        PPt.Application pptApplication;
        // Define Presentation object
        PPt.Presentation presentation;
        // Define Slide collection
        PPt.Slides slides;
        PPt.Slide slide;

        // Slide count
        int slidescount;
        // slide index
        int slideIndex;

        public bool PlayPresentation { get; set; }

        public PowerPointHandler()
        {
            PlayPresentation = true;
        }

        public void Init()
        {
            try
            {
                // Get Running PowerPoint Application object
                pptApplication = Marshal.GetActiveObject("PowerPoint.Application") as PPt.Application;
                pptApplication.SlideShowBegin += pptApplication_SlideShowBegin;
                pptApplication.SlideShowEnd += pptApplication_SlideShowEnd;

                if (pptApplication != null)
                {
                    try
                    {
                        // Get Presentation Object
                        presentation = pptApplication.ActivePresentation;
                        if(PlayPresentation)
                            presentation.SlideShowSettings.Run();
                    }
                    catch
                    {
                        // Get presentation in protected mode
                        presentation = pptApplication.ActiveProtectedViewWindow.Presentation;
                        if (PlayPresentation)
                            presentation.SlideShowSettings.Run();
                    }
                    //// Get Slide collection object
                    slides = presentation.Slides;
                    //// Get Slide count
                    slidescount = slides.Count;
                    //// Get current selected slide 
                    try
                    {
                        // Get selected slide object in normal view
                        slide = slides[pptApplication.ActiveWindow.Selection.SlideRange.SlideNumber];
                    }
                    catch
                    {
                        // Get selected slide object in reading view
                        slide = pptApplication.SlideShowWindows[1].View.Slide;
                    }
                }
            }
            catch
            {
                //TODO
            }
        }

        void pptApplication_SlideShowEnd(PPt.Presentation Pres)
        {
            if (SlideShowEnd != null)
            {
                SlideShowEnd(this, new EventArgs());
            }
        }

        private void pptApplication_SlideShowBegin(PPt.SlideShowWindow Wn)
        {
            if (SlideShowBegin != null)
            {
                SlideShowBegin(this, new EventArgs());
            }
        }

        public void GoFirstSlide()
        {
            try
            {
                // Call Select method to select first slide in normal view
                slides[1].Select();
                slide = slides[1];
            }
            catch
            {
                // Transform to first page in reading view
                pptApplication.SlideShowWindows[1].View.First();
                slide = pptApplication.SlideShowWindows[1].View.Slide;
            }
        }

        public void GoLastSlide()
        {
            try
            {
                slides[slidescount].Select();
                slide = slides[slidescount];
            }
            catch
            {
                pptApplication.SlideShowWindows[1].View.Last();
                slide = pptApplication.SlideShowWindows[1].View.Slide;
            }
        }

        public void GoNextSlide()
        {
            slideIndex = slide.SlideIndex + 1;
            if (slideIndex <= slidescount)
            {
                try
                {
                    //standard mode
                    //slide = slides[slideIndex];
                    //slides[slideIndex].Select();

                    Logger.Log("Siguiente Diapositiva");

                    //fullscreen mode
                    if (pptApplication.SlideShowWindows.Count > 0)
                    {
                        pptApplication.SlideShowWindows[1].View.Next(); //TODO que pasa si hay mas de una ppt en fullscrenn? por ejemplo 2 monitores
                        slide = pptApplication.SlideShowWindows[1].View.Slide;
                    }
                }
                catch(Exception ex)
                {
                    Logger.LogError("Error slide siguiente: " + ex.Message);
                }
            }
        }

        public void GoPreviousSlide()
        {
            slideIndex = slide.SlideIndex - 1;
            if (slideIndex >= 1)
            {
                try
                {
                    //standard mode
                    //slide = slides[slideIndex];
                    //slides[slideIndex].Select();

                    Logger.Log("Siguiente Diapositiva");

                    //fullscreen mode
                    if (pptApplication.SlideShowWindows.Count > 0)
                    {
                        pptApplication.SlideShowWindows[1].View.Previous(); //TODO que pasa si hay mas de una ppt en fullscrenn? por ejemplo 2 monitores
                        slide = pptApplication.SlideShowWindows[1].View.Slide;
                    }
                }
                catch(Exception ex)
                {
                    Logger.LogError("Error slide anterior: " + ex.Message);
                }
            }
        }


        public void Test()
        {
            PPt.Application app = Marshal.GetActiveObject("PowerPoint.Application") as PPt.Application;
            try
            {
                PPt.Presentation activePresentation = app.ActivePresentation;
                activePresentation.SlideShowSettings.Run();
            }
            catch
            {
                PPt.ProtectedViewWindow activeProtectedWindow = app.ActiveProtectedViewWindow;
                activeProtectedWindow.Presentation.SlideShowSettings.Run();
            }

           // app.SlideShowNextSlide += app_SlideShowNextSlide;

            if (app.SlideShowWindows != null && app.SlideShowWindows.Count > 0)
            {
                
            }
        }


        public event EventHandler SlideShowBegin;

        public event EventHandler SlideShowEnd;
    }
}
