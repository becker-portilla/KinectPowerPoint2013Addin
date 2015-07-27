using System;
using Microsoft.Kinect;

namespace KinectPowerPointAddIn.Gestures
{
    public class GestureManager
    {
        private const int WINDOW_SIZE = 50;
        private const int MAX_PAUSE_CONT = 8;
        public int WindowSize { get; set; }
        public int MaxPauseCont { get; set; }
        public Gesture Gesture { get; set; }

        private int currentPose = 0;
        private int pausedFrameCount = MAX_PAUSE_CONT;
        private int frameCount = 0;
        private bool isPaused = false;

        public event EventHandler<GestureEventArgs> GestureRecognized;

        public GestureManager()
        {
            WindowSize = WINDOW_SIZE;
            MaxPauseCont = MAX_PAUSE_CONT;
        }

        public GestureManager(GestureType type, IGesturePose[] poses)
        {
            WindowSize = WINDOW_SIZE;
            MaxPauseCont = MAX_PAUSE_CONT;
            Gesture = new Gesture(type, poses);
        }

        public GestureManager(Gesture gesture)
        {
            WindowSize = WINDOW_SIZE;
            MaxPauseCont = MAX_PAUSE_CONT;
            Gesture = gesture;
        }

        public void DetectGesture(Body body)
        {
            GesturePoseResult result = Gesture.Poses[currentPose].DetectPose(body);

            if (result == GesturePoseResult.Succeeded)
            {
                //Logger.Log("Pose Encontrada: " + Gesture.Poses[currentPose].ToString());
                if (currentPose + 1 < Gesture.Poses.Length)
                {
                    currentPose++;
                    frameCount = 0;
                }
                else
                {
                    if (GestureRecognized != null)
                    {
                        Logger.Log("Gesto Encontrado(manager): " + Gesture.Type.ToString());
                        GestureRecognized(this, new GestureEventArgs(Gesture.Type));
                        Reset();
                    }
                }
            }
            else if (frameCount >= WindowSize)
            {
                Reset();
                //Logger.Log("Pose dudosa: " + Gesture.Poses[currentPose].ToString());
            }

            frameCount++;
        }

        public void DetectGesture_WithPause(Body body) //TODO revisar
        {
            if (isPaused)
            {
                if (frameCount == pausedFrameCount)
                {
                    isPaused = false;
                }

                frameCount++;
            }

            GesturePoseResult result = Gesture.Poses[currentPose].DetectPose(body);

            if (result == GesturePoseResult.Succeeded)
            {
                Logger.Log("Pose Encontrada: " + Gesture.Poses[currentPose].ToString());
                if (currentPose + 1 < Gesture.Poses.Length)
                {
                    currentPose++;
                    frameCount = 0;
                    pausedFrameCount = MaxPauseCont;
                    isPaused = true;
                }
                else
                {
                    if (GestureRecognized != null)
                    {
                        GestureRecognized(this, new GestureEventArgs(Gesture.Type));
                        Reset();
                    }
                }
            }
            else if (result == GesturePoseResult.Failed || frameCount == WindowSize)
            {
                Logger.Log("Pose NO Encontrada: " + Gesture.Poses[currentPose].ToString());
                Reset();
            }
            else
            {
                Logger.Log("Pose dudosa: " + Gesture.Poses[currentPose].ToString());
                frameCount++;
                pausedFrameCount = MaxPauseCont / 2;
                isPaused = true;
            }
        }

        public void Reset()
        {
            currentPose = 0;
            frameCount = 0;
            pausedFrameCount = MaxPauseCont / 2;
            isPaused = true;
        }
    }
}
