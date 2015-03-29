﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wTimer = System.Windows.Forms.Timer;

namespace SmartWatchDesignPatterns.DesignPatterns.Timer
{

    interface State
    {
        void StateUpdate(Timer timer);

        string getColor();
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
            timer.State = new DefaultState();
        }

        string color = "blue";
        string stateName = "Default";

        public override string getColor()
        {
            return color;
        }

    }

    class RunningState : State
    {
        public override void StateUpdate(Timer timer)
        {
            timer.State = new PauzeState();
        }
        string color = "green";
        string stateName = "Running";
    }

    class AlarmState : State
    {
        public override void StateUpdate(Timer timer)
        {
            timer.State = new AlarmState();
        }
        string color = "red";
        string stateName = "Alarmed";
    }

    class PauzeState : State
    {
        public override void StateUpdate(Timer timer)
        {
            timer.State = new RunningState();
        }
        string color = "lightblue";
        string stateName = "Pauze";

    }

    /*Timer Class
     * Bevat start tijd en benodigdheden voor de States
     * Logica moet voor timer moet worden toegevoegd
     */
    class Timer
    {
        private int second;
        private int minute;
        private State _state;

        public Timer(State state, int minute, int second)
        {
            this.State = state;
            this.minute = minute;
            this.second = second;
        }

        public State State
        {
            get { return _state; }
            set { _state = value; }
        }

        public void StateUpdate()
        {
            _state.StateUpdate(this);
        }

    }


}