using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditSharp.Things;

namespace SmartWatchDesignPatterns.DesignPatterns.Clock.Iterator
{
    /// <summary>
    /// The 'Iterator' interface
    /// </summary>
    internal interface IAbstractIterator
    {
        Post First();
        Post Next();
        bool IsDone { get; }
        Post CurrentItem { get; }
    }
}
