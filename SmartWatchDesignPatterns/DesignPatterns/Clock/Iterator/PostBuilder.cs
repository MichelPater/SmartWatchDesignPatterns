using System;
using System.Collections.Generic;
using System.Linq;
using RedditSharp;
using RedditSharp.Things;

namespace SmartWatchDesignPatterns.DesignPatterns.Clock.Iterator
{
    internal class PostBuilder
    {
        private readonly Reddit _reddit = new Reddit();
        private readonly Subreddit _subreddit;
        private readonly FromTime timePeriod = FromTime.Week;
        private String _subredditName;
        private int _amountOfPosts = 20;

        /// <summary>
        ///     Constructor with changeable subredditname
        /// </summary>
        /// <param name="subbredditName"></param>
        public PostBuilder(String subbredditName)
        {
            _subredditName = subbredditName;
            _subreddit = _reddit.GetSubreddit(_subredditName);
        }

        public String SubredditName
        {
            get { return _subredditName; }
            set { _subredditName = value; }
        }

        public int AmountOfPosts
        {
            get { return _amountOfPosts; }
            set { _amountOfPosts = value; }
        }

        /// <summary>
        ///     Gets a list of posts from a defined subreddit
        /// </summary>
        /// <returns></returns>
        public List<Post> GetPosts()
        {
            var posts = new List<Post>();
            foreach (var post in _subreddit.GetTop(timePeriod).Take(_amountOfPosts))
            {
                posts.Add(post);
            }
            return posts;
        }
    }
}