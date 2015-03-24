using System;

namespace SmartWatchDesignPatterns.DesignPatterns
{
    class Singelton
    {

        Singelton()
        {
            
        }

        static readonly Singelton Instance = new Singelton();

        public static Singelton UniqueInstance
        {
            get { return Instance; }
        }

        public DateTime GetTime()
        {
            return DateTime.UtcNow;
        }
    }
}
