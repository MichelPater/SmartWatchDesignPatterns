namespace SmartWatchDesignPatterns.DesignPatterns.Clock.Chain_of_Responsibility
{
    class SecondHandler : TimeHandler
    {
        public int Second
        {
            get { return _second; }
            set { _second = value; }
        }

        private  int _second = 0;

        public override void Tick()
        {
            if (_second <= 59)
            {
                _second++;
            }
            else if (succesor != null)
            {
                Tick();
                _second = 0;
            }
            
        }
    }
}
