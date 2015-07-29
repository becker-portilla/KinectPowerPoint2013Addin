using System;
using System.Collections.Generic;

namespace KinectPowerPointControl.Gestures
{
    public static class GestureCollection
    {
        public static Gesture GetGesture(GestureType type)
        {
            Gesture gesture = new Gesture(type);
            switch (type)
            {
                case GestureType.HandRight_R2L:
                    gesture.Poses = new IGesturePose[2];
                    gesture.Poses[0] = new Poses.HandRight_HandRightOfElbowPose();
                    gesture.Poses[1] = new Poses.HandRight_HandLeftOfElbowPose();
                    return gesture;
                case GestureType.HandRight_L2R:
                    gesture.Poses = new IGesturePose[2];
                    gesture.Poses[0] = new Poses.HandRight_HandLeftOfElbowPose();
                    gesture.Poses[1] = new Poses.HandRight_HandRightOfElbowPose();
                    return gesture;
                case GestureType.HandRight_C2O:
                    gesture.Poses = new IGesturePose[3];
                    gesture.Poses[0] = new Poses.HandRight_HandOpenedPose();
                    gesture.Poses[1] = new Poses.HandRight_HandClosedPose();
                    gesture.Poses[2] = new Poses.HandRight_HandOpenedPose();
                    return gesture;
                case GestureType.HandLeft_R2L:
                    gesture.Poses = new IGesturePose[2];
                    gesture.Poses[0] = new Poses.HandLeft_HandRightOfElbowPose();
                    gesture.Poses[1] = new Poses.HandLeft_HandLeftOfElbowPose();
                    return gesture;
                case GestureType.HandLeft_L2R:
                    gesture.Poses = new IGesturePose[2];
                    gesture.Poses[0] = new Poses.HandLeft_HandLeftOfElbowPose();
                    gesture.Poses[1] = new Poses.HandLeft_HandRightOfElbowPose();
                    return gesture;
                case GestureType.HandLeft_C2O:
                    gesture.Poses = new IGesturePose[3];
                    gesture.Poses[0] = new Poses.HandLeft_HandOpenedPose();
                    gesture.Poses[1] = new Poses.HandLeft_HandClosedPose();
                    gesture.Poses[2] = new Poses.HandLeft_HandOpenedPose();
                    return gesture;
                default:
                    return null;
            }
        }

        //TODO return all poses, return poses by part of body, etc
    }
}
