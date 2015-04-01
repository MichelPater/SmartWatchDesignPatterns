using RedditSharp.Things;

namespace SmartWatchDesignPatterns.DesignPatterns.Clock.Iterator
{
    /// <summary>
    ///     The 'Iterator' interface
    /// </summary>
    internal interface IAbstractIterator
    {
        bool IsAtEnd { get; } //get if its at the end
        bool IsAtBegin { get; } //get if its at the begin
        Post CurrentItem { get; }
        Post First(); //first post
        Post Next(); //next post
    }
}