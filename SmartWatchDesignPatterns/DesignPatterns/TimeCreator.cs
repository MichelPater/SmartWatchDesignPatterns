namespace SmartWatchDesignPatterns.DesignPatterns
{
    internal class TimeCreator
    {
        /// <summary>
        ///     Create an instance of Clock
        /// </summary>
        /// <returns></returns>
        public Clock.Clock CreateClock()
        {
            return new Clock.Clock();
        }

        /// <summary>
        ///     Create an instance of Timer
        /// </summary>
        /// <returns></returns>
        public Timer.Timer CreateTimer(int minute, int second)
        {
            return new Timer.Timer(minute, second);
        }

        /// <summary>
        ///     Create an instance of Stopwatch
        /// </summary>
        /// <returns></returns>
        public Stopwatch.Stopwatch CreateStopwatch()
        {
            return new Stopwatch.Stopwatch();
        }
    }
}