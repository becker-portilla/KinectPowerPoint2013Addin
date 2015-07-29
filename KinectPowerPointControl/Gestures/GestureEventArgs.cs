using System;

namespace KinectPowerPointControl.Gestures
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
