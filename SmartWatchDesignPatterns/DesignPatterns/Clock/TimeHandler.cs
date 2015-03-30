using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWatchDesignPatterns.DesignPatterns.Clock
{
    abstract class TimeHandler
    {
        protected TimeHandler succesor;

        public void SetSuccesor(TimeHandler succesor)
        {
            this.succesor = succesor;
        }

        /// <summary>
        /// Ticking of clock, which will be chained 
        /// </summary>
        public abstract void Tick();
    }
}
