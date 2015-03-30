using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wTimer = System.Windows.Forms.Timer;

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
        private string color;
        private StatePattern _state;
        static wTimer myTimer = new wTimer();

        public Timer(int minute, int second)
        {
            _state = new StatePattern();
            this.minute = minute;
            this.second = second;
        }

        public StatePattern State
        {
            get { return _state; }
            set { _state = value; }
        }

        public int getMinute()
        {
            return minute;
        }

        public int getSecond()
        {
            return second;
        }

        public string getColor()
        {

            return null;
        }

        private void TimeTickEvent(Object myObject, EventArgs myEventArgs)
        {
            if (minute == 0 && second == 0)
            {
                //switch state naar de AlarmedState
            }
            else
            {
                if (second >= 1)
                {
                    --second;
                }
                else
                {
                    second = 59;
                    --minute;
                }
            }
        }

        public void Main()
        {
            myTimer.Tick += new EventHandler(TimeTickEvent);

            myTimer.Interval = 1000;
            myTimer.Start();

            //AlarmState activeren met exitflag?
        }
    }


}
