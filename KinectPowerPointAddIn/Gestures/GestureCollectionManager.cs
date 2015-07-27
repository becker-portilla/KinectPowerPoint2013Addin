using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectPowerPointAddIn.Gestures
{
    public class GestureCollectionManager
    {
        public List<Gesture> Gestures
        {
            set
            {
                foreach (Gesture g in value)
                {
                    GestureManager manager = new GestureManager(g);
                    manager.GestureRecognized += manager_GestureRecognized;
                    gesturesManaged.Add(manager);
                }
            }
        }
        private List<GestureManager> gesturesManaged { get; set; }

        public event EventHandler<GestureEventArgs> GestureRecognized;
        public GestureCollectionManager()
        {
            gesturesManaged = new List<GestureManager>();
            Gestures = new List<Gesture>();
        }

        public GestureCollectionManager(List<Gesture> gestures)
        {
            gesturesManaged = new List<GestureManager>();
            Gestures = gestures;
        }

        public void DetectGestures(Body body)
        {
            foreach (GestureManager m in gesturesManaged)
            {                
                m.DetectGesture(body);
            }
        }

        void manager_GestureRecognized(object sender, GestureEventArgs e)
        {
            Logger.Log("Gesto Encontrado(CollectionManager): " + e.GestureType.ToString());
            if (GestureRecognized != null)
            {
                GestureRecognized(sender, e);
                Logger.Log("Gesto Encontrado: " + e.GestureType.ToString());
            }

            foreach (GestureManager m in gesturesManaged)
            {
                m.Reset();
            }
        }
    }
}
