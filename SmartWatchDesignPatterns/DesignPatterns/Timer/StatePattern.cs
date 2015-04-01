namespace SmartWatchDesignPatterns.DesignPatterns.Timer
{
    public class StatePattern
    {
        
    }

    internal abstract class State
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

    internal class DefaultState : State
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

    internal class RunningState : State
    {
        /// <summary>
        ///     Update the state from a context
        /// </summary>
        /// <param name="context"></param>
        public override void StateUpdate(Context context)
        {
            context.State = new PauzeState();
            context.Color = "pink";
            context.StateName = "Running";
        }

        /// <summary>
        ///     Overload for Stateupdate, with added status string
        /// </summary>
        /// <param name="context"></param>
        /// <param name="status"></param>
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

    internal class AlarmState : State
    {
        /// <summary>
        ///     Update the state from a context
        /// </summary>
        /// <param name="context"></param>
        public override void StateUpdate(Context context)
        {
            context.State = new DefaultState();
            context.Color = "lightblue";
            context.StateName = "Default";
        }

        /// <summary>
        ///     Overload for Stateupdate, with added status string
        /// </summary>
        /// <param name="context"></param>
        /// <param name="status"></param>
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

    internal class PauzeState : State
    {
        /// <summary>
        ///     Update the state from a context
        /// </summary>
        /// <param name="context"></param>
        public override void StateUpdate(Context context)
        {
            context.State = new RunningState();
            context.Color = "green";
            context.StateName = "Running";
        }

        /// <summary>
        ///     Overload for Stateupdate, with added status string
        /// </summary>
        /// <param name="context"></param>
        /// <param name="status"></param>
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

    internal class Context
    {
        public Context(State state)
        {
            State = state;
            Color = "lightblue";
            StateName = "Default";
        }

        public State State { get; set; }
        public string Color { get; set; }
        public string StateName { get; set; }

        public void ChangeState()
        {
            State.StateUpdate(this);
        }

        public void ChangeStateAlarm()
        {
            State.StateUpdate(this, "alarm");
        }

        public void ChangeStateDefault()
        {
            State.StateUpdate(this, "default");
        }
    }
}