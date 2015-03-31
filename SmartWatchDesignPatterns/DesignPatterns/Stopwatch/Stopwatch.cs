using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wStopwatch = System.Diagnostics.Stopwatch;

namespace SmartWatchDesignPatterns.DesignPatterns.Stopwatch
{
    class Stopwatch
    {
        wStopwatch wsw;
        TimeSpan ts;
        String elapsedTime;
        Originator o;

        public Stopwatch()
        {
            Originator o = new Originator();

            wStopwatch wsw = new wStopwatch();

            wsw.Start();

            TimeSpan ts = wsw.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
        }

        public void SaveTime()
        {
            o.CreateMemento();
        }
    }
}
