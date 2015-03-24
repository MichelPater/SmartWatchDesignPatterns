using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditSharp.Things;
using RedditSharp;


namespace SmartWatchDesignPatterns.RedditAPI
{
    class PostBuilder
    {
        private String subredditName = String.Empty;
        private Reddit reddit = new RedditSharp.Reddit();
        private Subreddit subreddit;
        private int amountOfPosts = 20;
        private FromTime timePeriod = FromTime.Week;

          
        /// <summary>
        /// Constructor with changeable subredditname
        /// </summary>
        /// <param name="subbredditName"></param>
        public PostBuilder(String subbredditName)
        {
            this.subredditName = subbredditName;
            subreddit = reddit.GetSubreddit(subredditName);
        }


        /// <summary>
        /// Gets a list of posts from a defined subreddit
        /// </summary>
        /// <returns></returns>
        public List<Post> getPosts()
        {
            List<Post> posts =new List<Post>();
            foreach (Post post in subreddit.GetTop(timePeriod).Take(amountOfPosts))
            {
                posts.Add(post);
            }
            return posts;
        }
    }
}
