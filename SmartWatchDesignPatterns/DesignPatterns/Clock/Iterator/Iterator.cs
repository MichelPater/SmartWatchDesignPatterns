using RedditSharp.Things;

namespace SmartWatchDesignPatterns.DesignPatterns.Clock.Iterator
{
    /// <summary>
    /// The 'ConcreteIterator' class
    /// </summary>
    public class Iterator : IAbstractIterator
    {
        private Collection _collection;
        public int CurrentIndex
        {
            get { return _current; }
        }
        private int _current;
        private int _step = 1;

        public Iterator(Collection collection)
        {
            _collection = collection;
        }

        // Gets first item
        public Post First()
        {
            _current = 0;
            return _collection[_current] as Post;
        }

        //GetLast
        public Post Last()
        {
            _current = _collection.Count - 1;
            return _collection[_current] as Post;
        }


        // Gets next item
        public Post Next()
        {
            if (!IsAtEnd)
            {
                _current += _step;
                return _collection[_current] as Post;
            }
            return null;
        }

        //Gets previous item
        public Post Previous()
        {
            if (!IsAtBegin)
            {
                _current -= _step;
                return _collection[_current] as Post;
            }
            return null;
        }

        // Gets or sets stepsize
        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }

        // Gets current iterator item
        public Post CurrentItem
        {
            get { return _collection[_current] as Post; }
        }

        // Gets whether iteration is at the end
        public bool IsAtEnd
        {
            get { return _current >= _collection.Count - 1; }
        }

        //Get wheter iteration is at begin
        public bool IsAtBegin
        {
            get { return _current <= 0; }
        }
    }
}
