using Microsoft.Kinect;

namespace KinectPowerPointControl.Gestures
{
    public interface IGesturePose
    {
        GesturePoseResult DetectPose(Body body);
    }
}
