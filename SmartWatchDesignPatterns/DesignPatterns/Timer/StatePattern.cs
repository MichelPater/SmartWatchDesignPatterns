using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWatchDesignPatterns.DesignPatterns.Timer
{
    class StatePattern
    {
        State state = new DefaultState();


        abstract class State
        {
            public State state;
            public abstract void StateUpdate(Timer timer);
            public string color;
        }

        /*Alle states die worden gebruikt
         * Default voor de start waarbij de tijd wordt opgegeven
         * Alarmed voor wanneer de tijd op is
         * Running voor lopend
         * Pauze voor pauze
         */
        class DefaultState : State
        {
            public override void StateUpdate(Timer timer)
            {
                state = new DefaultState();
            }

            new string color = "blue";
            string stateName = "Default";

        }

        class RunningState : State
        {
            public override void StateUpdate(Timer timer)
            {
                state = new PauzeState();
            }
            new string color = "green";
            string stateName = "Running";
        }

        class AlarmState : State
        {
            public override void StateUpdate(Timer timer)
            {
                state = new AlarmState();
            }
            new string color = "red";
            string stateName = "Alarmed";
        }

        class PauzeState : State
        {
            public override void StateUpdate(Timer timer)
            {
                state = new RunningState();
            }
            new string color = "lightblue";
            string stateName = "Pauze";

        }
    }
}
