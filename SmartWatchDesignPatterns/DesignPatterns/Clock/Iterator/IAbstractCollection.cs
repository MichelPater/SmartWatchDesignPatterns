namespace SmartWatchDesignPatterns.DesignPatterns.Clock.Iterator
{
    /// <summary>
    /// The 'Aggregate' interface
    /// </summary>
    interface IAbstractCollection
    {
        Iterator CreateIterator();
    }
}
