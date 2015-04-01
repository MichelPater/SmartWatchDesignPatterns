using System.Collections.Generic;
using System.Linq;
using wStopwatch = System.Diagnostics.Stopwatch;

namespace SmartWatchDesignPatterns.DesignPatterns.Stopwatch
{
    internal class Stopwatch : ITime
    {
        /// <summary>
        ///     Create the Stopwatch and enqueque memento's
        /// </summary>
        public Stopwatch()
        {
            WStopwatch = new wStopwatch();

            Originator = new Originator();

            CareTaker = new CareTaker();

            Memento = Originator.CreateMemento();

            MementoList = new Queue<string>(5);

            MementoList.Enqueue("00:00:00");
            MementoList.Enqueue("00:00:00");
            MementoList.Enqueue("00:00:00");
            MementoList.Enqueue("00:00:00");
            MementoList.Enqueue("00:00:00");
        }

        public wStopwatch WStopwatch { get; set; }
        public Originator Originator { get; set; }
        public CareTaker CareTaker { get; set; }
        public Memento Memento { get; set; }

        /// <summary>
        ///     Convert the memento to a list
        /// </summary>
        public Queue<string> MementoList { get; set; }

        public string getTitle()
        {
            return "Stopwatch";
        }

        /// <summary>
        ///     Get the memento from a queque
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string GetMementoFromQueue(int number)
        {
            return MementoList.ElementAt(number);
        }
    }
}