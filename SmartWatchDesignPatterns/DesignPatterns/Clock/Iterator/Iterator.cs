using RedditSharp.Things;

namespace SmartWatchDesignPatterns.DesignPatterns.Clock.Iterator
{
    /// <summary>
    ///     The 'ConcreteIterator' class
    /// </summary>
    public class Iterator : IAbstractIterator
    {
        private readonly Collection _collection;
        private int _step = 1;

        public Iterator(Collection collection)
        {
            _collection = collection;
        }

        public int CurrentIndex { get; private set; }
        // Gets or sets stepsize
        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }

        // Gets first item
        public Post First()
        {
            CurrentIndex = 0;
            return _collection[CurrentIndex] as Post;
        }

        // Gets next item
        public Post Next()
        {
            if (!IsAtEnd)
            {
                CurrentIndex += _step;
                return _collection[CurrentIndex] as Post;
            }
            return null;
        }

        // Gets current iterator item
        public Post CurrentItem
        {
            get { return _collection[CurrentIndex] as Post; }
        }

        // Gets whether iteration is at the end
        public bool IsAtEnd
        {
            get { return CurrentIndex >= _collection.Count - 1; }
        }

        //Get wheter iteration is at begin
        public bool IsAtBegin
        {
            get { return CurrentIndex <= 0; }
        }

        //GetLast
        public Post Last()
        {
            CurrentIndex = _collection.Count - 1;
            return _collection[CurrentIndex] as Post;
        }

        //Gets previous item
        public Post Previous()
        {
            if (!IsAtBegin)
            {
                CurrentIndex -= _step;
                return _collection[CurrentIndex] as Post;
            }
            return null;
        }
    }
}