using System;

namespace SmartWatchDesignPatterns.DesignPatterns.Clock
{
    internal class TimeSingelton
    {
        private static readonly TimeSingelton Instance = new TimeSingelton();

        /// <summary>
        ///     Default constructor
        /// </summary>
        private TimeSingelton()
        {
        }

        /// <summary>
        ///     Create a uniqueinstance of the singelton
        /// </summary>
        public static TimeSingelton UniqueInstance
        {
            get { return Instance; }
        }

        /// <summary>
        ///     Get the Current DateTime
        /// </summary>
        /// <returns></returns>
        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}