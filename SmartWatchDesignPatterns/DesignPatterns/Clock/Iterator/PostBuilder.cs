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
        private int _amountOfPosts = 20;

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
            var posts = new List<Post>();
            foreach (var post in _subreddit.Hot.Take(_amountOfPosts))
            {
                posts.Add(post);
            }
            Collection postCollection = new Collection();

            for (int i = 0; i < posts.Count; i++)
            {
                postCollection[i] = posts[i];
            }

            return postCollection;
        }
    }
}