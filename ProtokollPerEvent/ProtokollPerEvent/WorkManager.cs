using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtokollPerEvent
{
    public class WorkManager
    {
        public void DoSomething(ProtokollManager protokoll)
        {
            //var protokoll = new ProtokollManager();
            //protokoll.LogHandler += LogProgress;

            for (int i = 0; i < 10; i++)
            {
                // Do something
                System.Threading.Thread.Sleep(1000);

                // Log
                protokoll.Log(ProtokollLevel.All, i.ToString());
            }
        }

        public void DoAndLogTime(ProtokollManager protokoll)
        {
            protokoll.LogTimeStart("Start 1");
            System.Threading.Thread.Sleep(1000);
            protokoll.LogTimeEnd("End 1");

            protokoll.LogTimeStart("Start 2");
            System.Threading.Thread.Sleep(2000);
            protokoll.LogTimeEnd("End 2");

            protokoll.LogTimeStart("Start 3");
            System.Threading.Thread.Sleep(3000);
            protokoll.LogTimeEnd("End 3");


        }
    }
}
