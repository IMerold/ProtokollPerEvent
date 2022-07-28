using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtokollPerEvent
{
    public enum ProtokollLevel
    {
        Nothing, Logfile, Display, All
    }

    public class ProtokollManagerEventArgs : EventArgs
    {
        public string Entry { get; set; }
        public DateTime EntryTime { get; set; }
        public ProtokollLevel Level { get; set; }

        public ProtokollManagerEventArgs(ProtokollLevel level, string entry, DateTime entryTime)
        {
            this.Level = level;
            this.Entry = entry;
            this.EntryTime = entryTime;
        }
    }
}
