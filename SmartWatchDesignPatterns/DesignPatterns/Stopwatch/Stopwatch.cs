using System.Collections.Generic;
using System.Linq;
using wStopwatch = System.Diagnostics.Stopwatch;

namespace SmartWatchDesignPatterns.DesignPatterns.Stopwatch
{
    class Stopwatch
    {
        wStopwatch wsw;
        Originator o;
        CareTaker c;
        Memento m;
        Queue<string> mementoqueue;

        public Stopwatch()
        {
            wsw = new wStopwatch();

            o = new Originator();

            c = new CareTaker();

            m = o.CreateMemento();

            mementoqueue = new Queue<string>(5);

            mementoqueue.Enqueue("00:00:00");
            mementoqueue.Enqueue("00:00:00");
            mementoqueue.Enqueue("00:00:00");
            mementoqueue.Enqueue("00:00:00");
            mementoqueue.Enqueue("00:00:00");
            
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

        public Queue<string> MementoList
        {
            get { return mementoqueue; }
            set { mementoqueue = value; }
        }

        public string getMementoFromQueue(int number)
        {

            return mementoqueue.ElementAt(number);
        }
    }
}
