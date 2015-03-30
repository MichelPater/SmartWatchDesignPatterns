using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartWatchDesignPatterns.DesignPatterns.Clock.Chain_of_Responsibility;

namespace SmartWatchDesignPatterns.DesignPatterns.Clock
{
    class TimeDisplay
    {
        private SecondHandler _secondHandler;
        private MinuteHandler _minuteHandler;
        private HourHandler _hourHandler;

        public TimeDisplay()
        {
            
        }

        public DateTime GetTime()
        {
            DateTime today = DateTime.Today;
            return new DateTime(today.Year, today.Month, today.Day, _hourHandler.Hour , _minuteHandler.Minute, _secondHandler.Second);
        }
    }
}
