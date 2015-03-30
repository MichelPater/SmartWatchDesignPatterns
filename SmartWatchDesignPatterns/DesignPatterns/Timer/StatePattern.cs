using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWatchDesignPatterns.DesignPatterns.Timer
{
    public class StatePattern
    {
        
            State state = new DefaultState();
        
    }
        abstract class State
        {
            public abstract void StateUpdate(State state);
            public abstract string getColor();
            
        }

        /*Alle states die worden gebruikt
         * Default voor de start waarbij de tijd wordt opgegeven
         * Alarmed voor wanneer de tijd op is
         * Running voor lopend
         * Pauze voor pauze
         */
        class DefaultState : State
        {
            string color = "blue";
            string stateName = "Default";

            public override void StateUpdate(State state)
            {
                state = new DefaultState();
            }

            public override string getColor()
            {
                return color;
            }

            

        }

        class RunningState : State
        {
            public override void StateUpdate(State state)
            {
                state = new PauzeState();
            }
            string color = "green";
            string stateName = "Running";

            public override string getColor()
            {
                return color;
            }
        }

        class AlarmState : State
        {
            public override void StateUpdate(State state)
            {
                state = new AlarmState();
            }
            string color = "red";
            string stateName = "Alarmed";

            public override string getColor()
            {
                return color;
            }
        }

        class PauzeState : State
        {
            public override void StateUpdate(State state)
            {
                state = new RunningState();
            }
            string color = "lightblue";
            string stateName = "Pauze";

            public override string getColor()
            {
                return color;
            }

        }
}

