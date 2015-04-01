namespace SmartWatchDesignPatterns.DesignPatterns.Stopwatch
{
    class MementoPattern
    {
    }

    class Originator
    {
        private string _savedTime;

        //The savedStopwatch time
        public string savedTime
        {
            get { return _savedTime; }
            set { _savedTime = value; }
        }

        public Memento CreateMemento()
        {
            return (new Memento(_savedTime));
        }

        public void SetMemento(Memento memento)
        {
            savedTime = memento.SavedTime;
        }
    }

    class Memento
    {
        private readonly string _savedTime;

        /// <summary>
        /// Create a memento form a savedtime
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

    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}
