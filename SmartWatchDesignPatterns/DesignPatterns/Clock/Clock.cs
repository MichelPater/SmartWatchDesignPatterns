using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SmartWatchDesignPatterns.DesignPatterns.Clock
{
    class Clock
    {
        private TimeSingelton _timeSingelton = TimeSingelton.UniqueInstance;

        public Clock()
        {
            
        }

        private void UpdateClock()
        {
            

            _timeSingelton.GetTime();
        }
    }
}
