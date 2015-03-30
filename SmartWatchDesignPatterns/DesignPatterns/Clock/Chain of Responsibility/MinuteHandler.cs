namespace SmartWatchDesignPatterns.DesignPatterns.Clock.Chain_of_Responsibility
{
    class MinuteHandler : TimeHandler
    {
        public int Minute {
            get { return _minute; } 
            set { _minute = value; } 
        }

        private int _minute;

        public override void Tick()
        {
            if (_minute < 59)
            {
                _minute++;
            }
            else if (succesor != null)
            {
                Tick();
                _minute = 0;
            }
        }
    }
}
