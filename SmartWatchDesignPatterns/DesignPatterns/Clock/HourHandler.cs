using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWatchDesignPatterns.DesignPatterns.Clock
{
    class HourHandler : TimeHandler
    {
        public int Hour
        {
            get { return _hour; }
            set { _hour = value; }
        }

        private int _hour;

        public override void Tick()
        {
            if (_hour <= 23)
            {
                _hour++;
            }
            else if (succesor != null)
            {
                Tick();
                _hour = 0;
            }
        }
    }
}
