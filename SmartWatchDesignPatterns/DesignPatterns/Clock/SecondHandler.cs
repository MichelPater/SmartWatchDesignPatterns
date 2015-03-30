using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWatchDesignPatterns.DesignPatterns.Clock
{
    class SecondHandler : TimeHandler
    {
        public int Minute
        {
            get { return _second; }
            set { _second = value; }
        }

        private  int _second = 0;

        public override void Tick()
        {
            if (_second <= 59)
            {
                _second++;
            }
            else if (succesor != null)
            {
                Tick();
                _second = 0;
            }
            
        }
    }
}
