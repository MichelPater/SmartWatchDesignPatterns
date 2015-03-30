using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWatchDesignPatterns.DesignPatterns.Clock
{
    class MinuteHandler : TimeHandler
    {
        public int Minute {
            get { return _minute; } 
            set { _minute = value; } 
        }

        private int _minute;

        public override void Tick()
        {
            if (_minute <= 59)
            {
                _minute++;
            }
            else if (succesor != null)
            {
                Tick();
                _minute = 0;
            }
        }
    }
}
