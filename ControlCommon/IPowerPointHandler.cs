using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlCommon
{
    public interface IPowerPointHandler
    {
        void Init();
        void GoFirstSlide();
        void GoLastSlide();
        void GoNextSlide();
        void GoPreviousSlide();
        bool PlayPresentation { get; set; }
        
        event EventHandler SlideShowBegin;
        event EventHandler SlideShowEnd;
    }
}
