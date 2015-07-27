using Microsoft.Kinect;

namespace KinectPowerPointAddIn.Gestures
{
    public interface IGesturePose
    {
        GesturePoseResult DetectPose(Body body);
    }
}
