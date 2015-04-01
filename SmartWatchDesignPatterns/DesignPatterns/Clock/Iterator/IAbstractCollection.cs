namespace SmartWatchDesignPatterns.DesignPatterns.Clock.Iterator
{
    /// <summary>
    ///     The 'Aggregate' interface
    /// </summary>
    internal interface IAbstractCollection
    {
        Iterator CreateIterator();
    }
}