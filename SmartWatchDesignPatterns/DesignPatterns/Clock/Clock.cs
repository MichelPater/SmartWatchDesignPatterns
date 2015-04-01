using System;
using RedditSharp.Things;
using SmartWatchDesignPatterns.DesignPatterns.Clock.Iterator;

namespace SmartWatchDesignPatterns.DesignPatterns.Clock
{
   public class Clock : ITime
    {
        private readonly TimeSingelton _timeSingelton = TimeSingelton.UniqueInstance;
        private Iterator.Iterator _iterator;
        
       public Iterator.Iterator Iterator
        {
            get { return _iterator; }
            set { _iterator = value; }
        }
        private Post _post;
        
       public Post Post
        {
            get { return _post; }
            set { _post = value; }
        }
       /// <summary>
       /// Inistialize the clock and create posts
       /// </summary>
        public Clock()
        {
            CreatePost();
        }

       /// <summary>
       /// Get the RedditPosts
       /// </summary>
        private void CreatePost()
        {
            PostBuilder postBuilder = new PostBuilder();
            Collection posts = postBuilder.GetPosts();

            _iterator = new Iterator.Iterator(posts);
            _post = _iterator.CurrentItem;
        }
       /// <summary>
       /// Get a formatted Time String from a DateTime
       /// </summary>
       /// <returns></returns>
        public String GetStringFormattedTime()
        {
            return _timeSingelton.GetTime().ToString("HH:mm:ss");
        }

       /// <summary>
       /// Refresh the Posts
       /// </summary>
       public void RefreshPosts()
       {
           CreatePost();
       }

       public string getTitle()
       {
           return "Clock";
       }
    }
}
