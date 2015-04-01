using System;
using System.Linq;
using RedditSharp;
using RedditSharp.Things;

namespace SmartWatchDesignPatterns.DesignPatterns.Clock.Iterator
{
    internal class PostBuilder
    {
        private readonly Reddit _reddit = new Reddit();
        private readonly Subreddit _subreddit;
        private const int AmountOfPosts = 20;

        /// <summary>
        /// Default overload, takes subreddit as All
        /// </summary>
        public PostBuilder()
        {
            SubredditName = "r/All";
           _subreddit = Subreddit.GetRSlashAll(_reddit);
        }
        
        public String SubredditName { get; set; }

        /// <summary>
        ///     Gets a list of posts from a defined subreddit
        /// </summary>
        /// <returns></returns>
        public Collection GetPosts()
        {
            var posts = _subreddit.Hot.Take(AmountOfPosts).ToList();
            Collection postCollection = new Collection();

            for (int i = 0; i < posts.Count; i++)
            {
                postCollection[i] = posts[i];
            }

            return postCollection;
        }
    }
}