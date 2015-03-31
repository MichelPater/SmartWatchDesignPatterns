using System;

namespace SmartWatchDesignPatterns.DesignPatterns
{
    class TimeCreator
    {
        public Clock.Clock CreateClock()
        {
            return new Clock.Clock();
        }

        public Timer.Timer CreateTimer()
        {
            throw new NotImplementedException("Method is not implemented");
        }

        public Stopwatch.Stopwatch CreateStopwatch()
        {
            throw new NotImplementedException("Method is not implemented");
        }
    }
}
