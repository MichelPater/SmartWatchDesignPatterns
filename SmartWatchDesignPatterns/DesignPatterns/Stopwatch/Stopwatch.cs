using System.Collections.Generic;
using System.Linq;
using wStopwatch = System.Diagnostics.Stopwatch;

namespace SmartWatchDesignPatterns.DesignPatterns.Stopwatch
{
    class Stopwatch: ITime
    {
        Originator _originator;
        Queue<string> _mementoqueue;
        /// <summary>
        /// Create the Stopwatch and enqueque memento's
        /// </summary>
        public Stopwatch() 
        {
            WStopwatch = new wStopwatch();

            _originator = new Originator();

            CareTaker = new CareTaker();

            Memento = _originator.CreateMemento();

            _mementoqueue = new Queue<string>(5);

            _mementoqueue.Enqueue("00:00:00");
            _mementoqueue.Enqueue("00:00:00");
            _mementoqueue.Enqueue("00:00:00");
            _mementoqueue.Enqueue("00:00:00");
            _mementoqueue.Enqueue("00:00:00");
            
        }

        public wStopwatch WStopwatch { get; set; }

        public Originator Originator
        {
            get { return _originator; }
            set { _originator = value; }
        }

        public CareTaker CareTaker { get; set; }

        public Memento Memento { get; set; }

        /// <summary>
        /// Convert the memento to a list
        /// </summary>
        public Queue<string> MementoList
        {
            get { return _mementoqueue; }
            set { _mementoqueue = value; }
        }

        /// <summary>
        /// Get the memento from a queque
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string GetMementoFromQueue(int number)
        {

            return _mementoqueue.ElementAt(number);
        }

        public string getTitle()
        {
            return "Stopwatch";
        }
    }
}
