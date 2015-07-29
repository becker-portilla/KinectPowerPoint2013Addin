using System;

namespace KinectPowerPointControl.Gestures
{
    public class Gesture
    {
        public GestureType Type { get; set; }
        public IGesturePose[] Poses { get; set; }

        public Gesture(GestureType type)
        {
            Type = type;
        }

        public Gesture(GestureType type, IGesturePose[] poses)
        {
            Type = type;
            Poses = poses;
        }
    }
}
