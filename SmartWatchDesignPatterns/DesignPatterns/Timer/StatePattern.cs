namespace SmartWatchDesignPatterns.DesignPatterns.Timer
{
    public class StatePattern
    {
        //Context c = new Context(new DefaultState());        
    }
        abstract class State
        {
            public abstract void StateUpdate(Context context);
            public abstract void StateUpdate(Context context, string status);
        }

    /*Alle states die worden gebruikt
        * Default voor de start waarbij de tijd wordt opgegeven
        * Alarmed voor wanneer de tijd op is
        * Running voor lopend
        * Pauze voor pauze
        */
    class DefaultState : State
    {

        public override void StateUpdate(Context context)
        {
            context.State = new RunningState();
            context.Color = "green";
            context.StateName = "Running";
        }

         public override void StateUpdate(Context context, string status)
        {
            switch (status)
            {
                case "alarm":
                    context.State = new AlarmState();
                    context.Color = "red";
                    context.StateName = "Alarmed";
                    break;
                case "default":
                    context.State = new DefaultState();
                    context.Color = "lightblue";
                    context.StateName = "Default";
                    break;
            }
        }
    }
    class RunningState : State
    {
        
        public override void StateUpdate(Context context)
        {
            context.State = new PauzeState();
            context.Color = "pink";
            context.StateName = "Running";
        }

        public override void StateUpdate(Context context, string status)
        {
            switch(status){
                case "alarm":
                    context.State = new AlarmState();
                    context.Color = "red";
                    context.StateName = "Alarmed";
                    break;
                case "default":
                    context.State = new DefaultState();
                    context.Color = "lightblue";
                    context.StateName = "Default";
                    break;
            }
        }
    }
    class AlarmState : State
    {
        public override void StateUpdate(Context context)
        {
            context.State = new DefaultState();
            context.Color = "lightblue";
            context.StateName = "Default";
        }

        public override void StateUpdate(Context context, string status)
        {
            switch(status){
                case "alarm":
                    context.State = new AlarmState();
                    context.Color = "red";
                    context.StateName = "Alarmed";
                    break;
                case "default":
                    context.State = new DefaultState();
                    context.Color = "lightblue";
                    context.StateName = "Default";
                    break;
            }
        }
    }

    class PauzeState : State
    {
        public override void StateUpdate(Context context)
        {
            context.State = new RunningState();
            context.Color = "green";
            context.StateName = "Running";
        }

        public override void StateUpdate(Context context, string status)
        {
            switch(status){
                case "alarm":
                    context.State = new AlarmState();
                    context.Color = "red";
                    context.StateName = "Alarmed";
                    break;
                case "default":
                    context.State = new DefaultState();
                    context.Color = "lightblue";
                    context.StateName = "Default";
                    break;
            }
         }
    }

    class Context
    {
        private State state;
        private string color;
        private string stateName;

        public Context(State state)
        {
            this.state = state;
            color = "lightblue";
            stateName = "Default";
        }

        public State State
        {
            get { return state; }
            set { state = value; }

        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string StateName
        {
            get { return stateName; }
            set { stateName = value; }
        }

        public void ChangeState()
        {
            state.StateUpdate(this);
        }

        public void ChangeStateAlarm()
        {
            state.StateUpdate(this, "alarm");
        }

        public void ChangeStateDefault()
        {
            state.StateUpdate(this, "default");
        }
    }
}

