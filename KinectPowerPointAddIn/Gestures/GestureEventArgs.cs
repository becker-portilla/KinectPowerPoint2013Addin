using System;

namespace KinectPowerPointAddIn.Gestures
{
    public class GestureEventArgs : EventArgs
    {
        public GestureType GestureType { get; private set; }
        public GestureEventArgs(GestureType type)
        {
            GestureType = type;
        }
    }
}
