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

        void Main()
        {

            wStopwatch wsw = new wStopwatch();

            Originator o = new Originator();

            CareTaker c = new CareTaker();
            c.Memento = o.CreateMemento();

            wsw.Start();

            TimeSpan ts = wsw.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
        }

    }

    class Originator
    {
        private string _savedTime;

        public string savedTime
        {
            get { return _savedTime; }
            set { _savedTime = value; }
        }

        public Memento CreateMemento()
        {
            return (new Memento(_savedTime));
        }

        public void setMemento(Memento memento)
        {
            savedTime = memento.savedTime;
        }

    }

    class Memento
    {
        private string _savedTime;

        public Memento(string savedTime)
        {
            this._savedTime = savedTime;
        }

        public string savedTime
        {
            get { return _savedTime; }
        }
    }

    class CareTaker
    {
        private Memento _memento;

        public Memento Memento
        {
            get { return _memento; }
            set { _memento = value; }
        }
    }
}
