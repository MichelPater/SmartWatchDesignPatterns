﻿using System;
using System.Timers;
using SmartWatchDesignPatterns.DesignPatterns.Clock.Chain_of_Responsibility;

namespace SmartWatchDesignPatterns.DesignPatterns.Clock
{
    class TimeDisplay
    {
        private SecondHandler _secondHandler = new SecondHandler();
        private MinuteHandler _minuteHandler = new MinuteHandler();
        private HourHandler _hourHandler = new HourHandler();
        private System.Timers.Timer _timer = new System.Timers.Timer(1000);

        public TimeDisplay()
        {
            _secondHandler.SetSuccesor(_minuteHandler);
            _minuteHandler.SetSuccesor(_hourHandler);

            _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            _timer.Interval = 1000;
            _timer.Enabled = true; 

            InitializeTime();
        }

        public void InitializeTime()
        {
            var _time = DateTime.Now;

            _secondHandler.Second = _time.Second;
            _minuteHandler.Minute = _time.Minute;
            _hourHandler.Hour = _time.Hour;
        }


        public DateTime GetTime()
        {
            DateTime today = DateTime.Today;
            return new DateTime(today.Year, today.Month, today.Day, _hourHandler.Hour, _minuteHandler.Minute, _secondHandler.Second);
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            _secondHandler.Tick();
            Console.WriteLine(GetTime().ToString());
        }
    }
}
