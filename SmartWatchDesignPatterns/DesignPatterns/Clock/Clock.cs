using System;
using RedditSharp.Things;
using SmartWatchDesignPatterns.DesignPatterns.Clock.Iterator;

namespace SmartWatchDesignPatterns.DesignPatterns.Clock
{
    public class Clock : ITime
    {
        private readonly TimeSingelton _timeSingelton = TimeSingelton.UniqueInstance;

        /// <summary>
        ///     Inistialize the clock and create posts
        /// </summary>
        public Clock()
        {
            CreatePost();
        }

        public Iterator.Iterator Iterator { get; set; }
        public Post Post { get; set; }

        public string getTitle()
        {
            return "Clock";
        }

        /// <summary>
        ///     Get the RedditPosts
        /// </summary>
        private void CreatePost()
        {
            var postBuilder = new PostBuilder();
            var posts = postBuilder.GetPosts();

            Iterator = new Iterator.Iterator(posts);
            Post = Iterator.CurrentItem;
        }

        /// <summary>
        ///     Get a formatted Time String from a DateTime
        /// </summary>
        /// <returns></returns>
        public String GetStringFormattedTime()
        {
            return _timeSingelton.GetTime().ToString("HH:mm:ss");
        }

        /// <summary>
        ///     Refresh the Posts
        /// </summary>
        public void RefreshPosts()
        {
            CreatePost();
        }
    }
}