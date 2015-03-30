namespace SmartWatchDesignPatterns.DesignPatterns.Clock.Chain_of_Responsibility
{
    class HourHandler : TimeHandler
    {
        public int Hour
        {
            get { return _hour; }
            set { _hour = value; }
        }

        private int _hour;

        public override void Tick()
        {
            if (_hour <= 23)
            {
                _hour++;
            }
            else if (succesor != null)
            {
                Tick();
                _hour = 0;
            }
        }
    }
}
