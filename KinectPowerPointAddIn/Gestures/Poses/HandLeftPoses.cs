using System;
using Microsoft.Kinect;

namespace KinectPowerPointAddIn.Gestures.Poses
{
    public class HandLeft_HandRightOfElbowPose : IGesturePose
    {
        public GesturePoseResult DetectPose(Body body) //TODO contemplar mano cerrada o abierta
        {
            if (body.Joints[JointType.HandLeft].Position.Y > body.Joints[JointType.ElbowLeft].Position.Y) //mano arriba del codo
            {
                if (body.Joints[JointType.HandLeft].Position.X > body.Joints[JointType.ElbowLeft].Position.X) //mano a la derecha del codo
                {
                    return GesturePoseResult.Succeeded;
                }

                // Hand has not dropped but is not quite where we expect it to be, pausing till next frame
                return GesturePoseResult.Undetermined;
            }

            return GesturePoseResult.Failed;
        }
    }

    public class HandLeft_HandLeftOfElbowPose : IGesturePose
    {
        public GesturePoseResult DetectPose(Body body) //TODO contemplar mano cerrada o abierta
        {
            if (body.Joints[JointType.HandLeft].Position.Y > body.Joints[JointType.ElbowLeft].Position.Y) //mano arriba del codo
            {
                if (body.Joints[JointType.HandLeft].Position.X < body.Joints[JointType.ElbowLeft].Position.X) //mano a la derecha del codo
                {
                    return GesturePoseResult.Succeeded;
                }

                // Hand has not dropped but is not quite where we expect it to be, pausing till next frame
                return GesturePoseResult.Undetermined;
            }

            return GesturePoseResult.Failed;
        }
    }

    public class HandLeft_HandClosedPose : IGesturePose
    {
        public GesturePoseResult DetectPose(Body body)
        {
            if (body.HandLeftState == HandState.Closed)
                return GesturePoseResult.Succeeded;

            return GesturePoseResult.Failed;
        }
    }

    public class HandLeft_HandOpenedPose : IGesturePose
    {
        public GesturePoseResult DetectPose(Body body)
        {
            if (body.HandLeftState == HandState.Open)
                return GesturePoseResult.Succeeded;

            return GesturePoseResult.Failed;
        }
    }
}
