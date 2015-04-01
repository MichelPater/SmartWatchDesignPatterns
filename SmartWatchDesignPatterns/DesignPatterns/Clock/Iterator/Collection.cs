using System.Collections;

namespace SmartWatchDesignPatterns.DesignPatterns.Clock.Iterator
{
    /// <summary>
    /// The 'ConcreteAggregate' class
    /// </summary>
    public class Collection : IAbstractCollection
    {
        private ArrayList _posts = new ArrayList();

        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        // Gets item count
        public int Count
        {
            get { return _posts.Count; }
        }

        // Indexer
        public object this[int index]
        {
            get { return _posts[index]; }
            set { _posts.Add(value); }
        }
    }
}
