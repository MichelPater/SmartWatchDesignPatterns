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
        private SecondHandler _secondHandler = new SecondHandler();
        private MinuteHandler _minuteHandler = new MinuteHandler();
        private HourHandler _hourHandler = new HourHandler();

        public TimeDisplay()
        {
            _secondHandler.SetSuccesor(_minuteHandler);
            _minuteHandler.SetSuccesor(_hourHandler);
        }

        public DateTime GetTime()
        {
            DateTime today = DateTime.Today;
            return new DateTime(today.Year, today.Month, today.Day, _hourHandler.Hour, _minuteHandler.Minute, _secondHandler.Second);
        }
    }
}
