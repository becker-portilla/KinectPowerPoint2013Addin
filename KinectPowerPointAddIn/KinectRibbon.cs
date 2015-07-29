using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using KinectPowerPointControl;
using PowerPoint2013Control;
using ControlCommon;

namespace KinectPowerPointAddIn
{
    public partial class KinectRibbon
    {
        private void KinectRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void kinectBtn_Click(object sender, RibbonControlEventArgs e)
        {
            KinectHandler kinect = new KinectHandler();

            if (kinectBtn.Checked)
            {
                kinect.Handler = new PowerPointHandler();
                kinect.Handler.PlayPresentation = this.chkStartPresentation.Checked;
                kinect.Start();
            }
            else
            {
                kinect.Stop();
            }
        }
    }
}
