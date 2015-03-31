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
        Originator o;
        CareTaker c;

        public Stopwatch()
        {
            wsw = new wStopwatch();

            o = new Originator();

            c = new CareTaker();

            //Misschien in factory of mainwindow plaatsen later
            ts = new TimeSpan();

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",ts.Hours, ts.Minutes, ts.Seconds);
            
        }

        public wStopwatch wStopwatch
        {
            get { return wsw; }
            set { wsw = value; }
        }
    }
}
