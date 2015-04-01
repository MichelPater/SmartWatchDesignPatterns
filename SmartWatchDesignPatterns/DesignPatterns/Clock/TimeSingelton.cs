using System;

namespace SmartWatchDesignPatterns.DesignPatterns.Clock
{
    class TimeSingelton
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        TimeSingelton()
        {
            
        }

        static readonly TimeSingelton Instance = new TimeSingelton();

        /// <summary>
        /// Create a uniqueinstance of the singelton
        /// </summary>
        public static TimeSingelton UniqueInstance
        {
            get { return Instance; }
        }

        /// <summary>
        /// Get the Current DateTime
        /// </summary>
        /// <returns></returns>
        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}
