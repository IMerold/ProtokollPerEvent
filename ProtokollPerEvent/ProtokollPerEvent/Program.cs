using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtokollPerEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            ProtokollManager protokoll = new ProtokollManager(true);
            protokoll.LogHandler += LogProgress;

            WorkManager workManager = new WorkManager();
            workManager.DoSomething(protokoll);
            //workManager.DoAndLogTime(protokoll);

            Console.ReadKey();
        }

        static void LogProgress(object sender, ProtokollManagerEventArgs e)
        {
            String LogString = $"{e.EntryTime} {e.Entry}{Environment.NewLine}";
            Console.Write(LogString);
            File.AppendAllText(@"c:\temp\log.txt", LogString);
        }
    }
}
