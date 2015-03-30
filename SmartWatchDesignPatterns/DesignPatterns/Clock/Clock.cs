using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace SmartWatchDesignPatterns.DesignPatterns.Clock
{
   public class Clock
    {
        private TimeSingelton _timeSingelton = TimeSingelton.UniqueInstance;

        public Clock()
        {
            var datetime = DateTime.Now;
        }

        private void UpdateClock()
        {
            
            _timeSingelton.GetTime();
        }
    }
}
