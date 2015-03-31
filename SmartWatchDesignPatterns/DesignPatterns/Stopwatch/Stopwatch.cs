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

        public Stopwatch()
        {
            wsw = new wStopwatch();

            ts = new TimeSpan();

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",ts.Hours, ts.Minutes, ts.Seconds);
        }
    }
}
