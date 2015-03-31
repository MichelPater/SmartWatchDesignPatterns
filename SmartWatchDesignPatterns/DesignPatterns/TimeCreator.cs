using System;

namespace SmartWatchDesignPatterns.DesignPatterns
{
    class TimeCreator
    {
        public Clock.Clock CreateClock()
        {
            return new Clock.Clock();
        }

        public Timer.Timer CreateTimer(int minute, int second)
        {
            return new Timer.Timer(minute, second);
        }

        public Stopwatch.Stopwatch CreateStopwatch()
        {
            return new Stopwatch.Stopwatch();
        }
    }
}
