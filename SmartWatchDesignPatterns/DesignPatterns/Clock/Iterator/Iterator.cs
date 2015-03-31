using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditSharp.Things;

namespace SmartWatchDesignPatterns.DesignPatterns.Clock.Iterator
{
     /// <summary>
    /// The 'ConcreteIterator' class
    /// </summary>
    class Iterator : IAbstractIterator
    {
        private Collection _collection;
        private int _current = 0;
        private int _step = 1;
 
        public Iterator(Collection collection)
        {
            this._collection = collection;
        }
 
        // Gets first item
        public Post First()
        {
            _current = 0;
            return _collection[_current] as Post;
        }

         public Post Last()
         {
             _current = _collection.Count - 1;
             return _collection[_current] as Post;
         }

 
        // Gets next item
        public Post Next()
        {
            _current += _step;
            if (!IsAtEnd)
                return _collection[_current] as Post;
            else
            {
                return null;
            }
        }

         public Post Previous()
         {
             _current -= _step;
             if (!IsAtBegin)
             {
                 return _collection[_current] as Post;
             }
             else
             {
                 return null;
             }
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
 
        // Gets whether iteration is complete
        public bool IsAtEnd
        {
            get { return _current >= _collection.Count; }
        }

         public bool IsAtBegin
         {
             get { return _current < 0; }
         }
    }
}
