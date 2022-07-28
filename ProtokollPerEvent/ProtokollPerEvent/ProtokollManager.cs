using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtokollPerEvent
{
    public class ProtokollManager
    {
        const int indentLength = 4;
        bool Active { get; set; }

        public ProtokollManager(bool active)
        {
            Active = active;
        }

        Stopwatch stopWatch = new Stopwatch();

        public void Log(ProtokollLevel level, string entry)
        {
            if(Active)
                OnLog(level, 0, entry, DateTime.Now);
        }
        public void Log(ProtokollLevel level, int indentation, string entry)
        {
            if(Active)
                OnLog(level, indentation, entry, DateTime.Now);
        }

        public void LogTimeStart(string entry)
        {
            if (Active)
            {
                Log(ProtokollLevel.All, entry);
                stopWatch.Start();
            }
        }
        public void LogTimeEnd(string entry)
        {
            if (Active)
            {
                stopWatch.Stop();
                Log(ProtokollLevel.All, entry + ", Elapsed: " + stopWatch.Elapsed.ToString());
                stopWatch.Reset();
            }
        }

        protected virtual void OnLog(ProtokollLevel level, int indentation, string entry, DateTime entryTime)
        {
            var args = new ProtokollManagerEventArgs(level, (new String(' ', indentation * indentLength) + entry), DateTime.Now);
            LogHandler?.Invoke(this, args);
        }

        public event EventHandler<ProtokollManagerEventArgs> LogHandler;
    }
}
