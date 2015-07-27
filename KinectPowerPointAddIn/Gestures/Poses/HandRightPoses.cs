using System;
using Microsoft.Kinect;

namespace KinectPowerPointAddIn.Gestures.Poses
{
    public class HandRight_HandRightOfElbowPose : IGesturePose
    {
        public GesturePoseResult DetectPose(Body body) //TODO contemplar mano cerrada o abierta
        {
            if (body.Joints[JointType.HandRight].Position.Y > body.Joints[JointType.ElbowRight].Position.Y) //mano arriba del codo
            {
                if (body.Joints[JointType.HandRight].Position.X > body.Joints[JointType.ElbowRight].Position.X) //mano a la derecha del codo
                {
                    return GesturePoseResult.Succeeded;
                }

                // Hand has not dropped but is not quite where we expect it to be, pausing till next frame
                return GesturePoseResult.Undetermined;
            }

            return GesturePoseResult.Failed;
        }
    }

    public class HandRight_HandLeftOfElbowPose : IGesturePose
    {
        public GesturePoseResult DetectPose(Body body) //TODO contemplar mano cerrada o abierta
        {
            if (body.Joints[JointType.HandRight].Position.Y > body.Joints[JointType.ElbowRight].Position.Y) //mano arriba del codo
            {
                if (body.Joints[JointType.HandRight].Position.X < body.Joints[JointType.ElbowRight].Position.X) //mano a la izquierda del codo
                {
                    return GesturePoseResult.Succeeded;
                }

                // Hand has not dropped but is not quite where we expect it to be, pausing till next frame
                return GesturePoseResult.Undetermined;
            }

            return GesturePoseResult.Failed;
        }
    }

    public class HandRight_HandClosedPose : IGesturePose
    {
        public GesturePoseResult DetectPose(Body body)
        {
            if (body.HandRightState == HandState.Closed)
                return GesturePoseResult.Succeeded;
            
            return GesturePoseResult.Failed;
        }
    }

    public class HandRight_HandOpenedPose : IGesturePose
    {
        public GesturePoseResult DetectPose(Body body)
        {
            if (body.HandRightState == HandState.Open)
                return GesturePoseResult.Succeeded;

            return GesturePoseResult.Failed;
        }
    }
}
