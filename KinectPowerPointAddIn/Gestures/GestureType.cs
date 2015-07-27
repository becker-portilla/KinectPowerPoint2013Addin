using System;

namespace KinectPowerPointAddIn.Gestures
{
    public enum GestureType
    {
        /// <summary>
        /// Move Right Hand Right To Left
        /// </summary>
        HandRight_R2L,
        /// <summary>
        /// Move Right Hand Left To Right
        /// </summary>
        HandRight_L2R,
        /// <summary>
        /// Move Left Hand Right To Left
        /// </summary>
        HandLeft_L2R, 
        /// <summary>
        /// Move Left Hand Left To Right
        /// </summary>
        HandLeft_R2L, 
        /// <summary>
        /// Close and Open Right Hand
        /// </summary>
        HandRight_C2O,
        /// <summary>
        /// Close and Open Left Hand
        /// </summary>
        HandLeft_C2O 
    }
}
