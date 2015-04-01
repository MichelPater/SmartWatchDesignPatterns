namespace SmartWatchDesignPatterns.DesignPatterns.Timer
{
    /*Timer Class
     * Bevat start tijd en benodigdheden voor de States
     * Logica moet voor timer moet worden toegevoegd
     */

    internal class Timer : ITime
    {
        public Timer(int minute, int second)
        {
            Context = new Context(new DefaultState());
            Minute = minute;
            Second = second;
        }

        public Context Context { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public string getTitle()
        {
            return "Timer";
        }
    }
}