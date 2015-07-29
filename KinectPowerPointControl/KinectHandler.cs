using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using KinectPowerPointControl.Gestures;
using ControlCommon;

namespace KinectPowerPointControl
{
    public class KinectHandler
    {
        #region [Propiedades Privadas]
        private KinectSensor kinectSensor = null;
        private BodyFrameReader bodyFrameReader = null;
        private bool irSiguiente = false;
        private bool irAnterior = false;
        private GestureCollectionManager gestureCollectionManager;
        #endregion

        public IPowerPointHandler Handler { get; set; }

        public KinectHandler()
        {
            this.kinectSensor = KinectSensor.GetDefault();
            List<Gesture> man = new List<Gesture>();
            //man.Add(GestureCollection.GetGesture(GestureType.HandRight_L2R));
            man.Add(GestureCollection.GetGesture(GestureType.HandRight_R2L));
            //man.Add(GestureCollection.GetGesture(GestureType.HandRight_C2O));
            man.Add(GestureCollection.GetGesture(GestureType.HandLeft_L2R));
            //man.Add(GestureCollection.GetGesture(GestureType.HandLeft_R2L));
            //man.Add(GestureCollection.GetGesture(GestureType.HandLeft_C2O));
            gestureCollectionManager = new GestureCollectionManager(man);
            gestureCollectionManager.GestureRecognized += gestureManager_GestureRecognized;
        }

        void gestureManager_GestureRecognized(object sender, GestureEventArgs e)
        {
            Logger.Log("Gesto reconocido(Handler): " + e.GestureType.ToString());
            switch (e.GestureType)
            {
                case GestureType.HandRight_R2L:
                case GestureType.HandLeft_R2L:
                case GestureType.HandRight_C2O:
                    Handler.GoNextSlide();
                    break;
                case GestureType.HandRight_L2R:
                case GestureType.HandLeft_L2R:
                case GestureType.HandLeft_C2O:
                    Handler.GoPreviousSlide();
                    break;
            }
        }

        public void Start()
        {
            if (this.kinectSensor != null)
            {
                if (Handler != null)
                {
                    Handler.Init();
                    this.kinectSensor.Open();
                    FrameDescription frameDescription = this.kinectSensor.DepthFrameSource.FrameDescription;
                    this.bodyFrameReader = this.kinectSensor.BodyFrameSource.OpenReader();
                    this.bodyFrameReader.FrameArrived += Reader_FrameArrived;
                }
            }

        }

        public void Stop()
        {
            if (this.kinectSensor != null)
            {
                this.kinectSensor.Close();
            }
        }


        public void Reader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            bool dataReceived = false;
            Body[] bodies = null;

            using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
            {
                if (bodyFrame != null)
                {
                    bodies = new Body[bodyFrame.BodyCount];

                    bodyFrame.GetAndRefreshBodyData(bodies);
                    dataReceived = true;
                }
            }

            if (dataReceived)
            {
                foreach (Body body in bodies)
                {
                    gestureCollectionManager.DetectGestures(body);
                    //BasicHandGesture(body);
                }
            }
        }

        private void BasicHandGesture(Body body)
        {
            if (body.HandRightState == HandState.Closed)
            {
                if (irSiguiente)
                {
                    Handler.GoNextSlide();
                    irSiguiente = false;
                }
            }

            if (body.HandRightState == HandState.Open)
            {
                irSiguiente = true;
            }

            if (body.HandLeftState == HandState.Closed)
            {
                if (irAnterior)
                {
                    Handler.GoPreviousSlide();
                    irAnterior = false;
                }
            }

            if (body.HandLeftState == HandState.Open)
            {
                irAnterior = true;
            }
        }
    }
}
