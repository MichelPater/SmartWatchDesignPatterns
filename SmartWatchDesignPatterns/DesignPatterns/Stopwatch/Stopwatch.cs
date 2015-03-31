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
        Originator o;
        CareTaker c;
        Memento m;

        public Stopwatch()
        {
            wsw = new wStopwatch();

            o = new Originator();

            c = new CareTaker();

            m = o.CreateMemento();
            
        }

        public wStopwatch wStopwatch
        {
            get { return wsw; }
            set { wsw = value; }
        }

        public Originator Originator
        {
            get { return o; }
            set { o = value; }
        }

        public CareTaker CareTaker
        {
            get { return c; }
            set { c = value; }
        }

        public Memento Memento
        {
            get { return m;}
            set { m = value; }
        }
    }
}
