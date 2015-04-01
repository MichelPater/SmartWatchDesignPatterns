namespace SmartWatchDesignPatterns.DesignPatterns.Stopwatch
{
    internal class MementoPattern
    {
    }

    internal class Originator
    {
        //The savedStopwatch time
        public string savedTime { get; set; }

        public Memento CreateMemento()
        {
            return (new Memento(savedTime));
        }

        public void SetMemento(Memento memento)
        {
            savedTime = memento.SavedTime;
        }
    }

    internal class Memento
    {
        private readonly string _savedTime;

        /// <summary>
        ///     Create a memento form a savedtime
        /// </summary>
        /// <param name="savedTime"></param>
        public Memento(string savedTime)
        {
            _savedTime = savedTime;
        }

        public string SavedTime
        {
            get { return _savedTime; }
        }
    }

    internal class CareTaker
    {
        public Memento Memento { get; set; }
    }
}