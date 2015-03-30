namespace SmartWatchDesignPatterns.DesignPatterns.Clock.Chain_of_Responsibility
{
    abstract class TimeHandler
    {
        protected TimeHandler succesor;

        public void SetSuccesor(TimeHandler succesor)
        {
            this.succesor = succesor;
        }

        /// <summary>
        /// Ticking of clock, which will be chained 
        /// </summary>
        public abstract void Tick();
    }
}
