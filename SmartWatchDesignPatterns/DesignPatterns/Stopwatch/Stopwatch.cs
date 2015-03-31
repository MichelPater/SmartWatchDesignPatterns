using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wStopwatch = System.Diagnostics.Stopwatch;

namespace SmartWatchDesignPatterns.DesignPatterns.Stopwatch
{
    class StopwatchHolder
    {
        wStopwatch wsw;
        string elapsedTime;
        Originator o;
        CareTaker c;

        public StopwatchHolder()
        {
            wsw = new wStopwatch();

             o = new Originator();

             c = new CareTaker();

        }

        public string ElapsedTime
        {
            get { return elapsedTime; }
            set { elapsedTime = value; }
        }

        public CareTaker CareTaker
        {
            get { return c; }
            set { c = value; }
        }

        public void SaveTime()
        {
            o.savedTime = elapsedTime;
            c.Memento = o.CreateMemento();
        }

        public void RestoreTimer()
        {
           stopTheWatch();
           o.setMemento(c.Memento);
           elapsedTime = o.savedTime;
        }

        public void startTheWatch()
        {
            wsw.Start();
        }

        public void stopTheWatch()
        {
            wsw.Stop();
        }
    }
}
