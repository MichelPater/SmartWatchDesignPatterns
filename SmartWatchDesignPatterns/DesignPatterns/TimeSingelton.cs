using System;

namespace SmartWatchDesignPatterns.DesignPatterns
{
    class TimeSingelton
    {

        TimeSingelton()
        {
            
        }

        static readonly TimeSingelton Instance = new TimeSingelton();

        public static TimeSingelton UniqueInstance
        {
            get { return Instance; }
        }

        public DateTime GetTime()
        {
            return DateTime.UtcNow;
        }
    }
}
