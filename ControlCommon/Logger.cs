using System;
using System.Diagnostics;

namespace ControlCommon
{
    public static class Logger
    {
        static EventLog log { get; set; }

        public static void Log(string text)
        {
            //if (log == null)
            //{
            //    log = new EventLog("Application", System.Environment.MachineName, "KinectControl");
            //}
            
            //log.WriteEntry(text, EventLogEntryType.Information);
            //log.Close();
        }

        public static void LogError(string text)
        {
            //if (log == null)
            //{
            //    log = new EventLog("Application", System.Environment.MachineName, "KinectControl");
            //}

            //log.WriteEntry(text, EventLogEntryType.Error);
            //log.Close();
        }
    }
}
