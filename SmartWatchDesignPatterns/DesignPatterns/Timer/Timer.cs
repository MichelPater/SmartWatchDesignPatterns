using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SmartWatchDesignPatterns.DesignPatterns.Timer
{

    /*Timer Class
     * Bevat start tijd en benodigdheden voor de States
     * Logica moet voor timer moet worden toegevoegd
     */
    class Timer
    {
        private int second;
        private int minute;
        private Context context;

        public Timer(int minute, int second)
        {
            context = new Context(new DefaultState());
            this.minute = minute;
            this.second = second;
        }
        /*
        public StatePattern State
        {
            get { return _state; }
            set { _state = value; }
        }
        */

        public Context Context
        {
            get { return context; }
            set { context = value; }
        }
        
        public int Minute
        {
            get { return minute; }
            set { minute = value; }
        }

        public int Second
        {
            get { return second; }
            set { second = value; }
        }

    }


}
