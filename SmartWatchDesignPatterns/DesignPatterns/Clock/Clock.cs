using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using RedditSharp.Things;
using SmartWatchDesignPatterns.DesignPatterns.Clock.Iterator;


namespace SmartWatchDesignPatterns.DesignPatterns.Clock
{
   public class Clock
    {
        private TimeSingelton _timeSingelton = TimeSingelton.UniqueInstance;
        private Iterator.Iterator _iterator;
        public Iterator.Iterator Iterator
        {
            get { return _iterator; }
            set { _iterator = value; }
        }
        private Post post;

        public Clock()
        {
            var datetime = DateTime.Now;

            TimeDisplay _timeDisplay = new TimeDisplay();
            CreatePost();
        }

        private void CreatePost()
        {
            PostBuilder postBuilder = new PostBuilder("r/ProgrammerHumor");
            Collection posts = postBuilder.GetPosts();

            _iterator = new Iterator.Iterator(posts);
            post = _iterator.CurrentItem;
        }



        private void UpdateClock()
        {
            
            _timeSingelton.GetTime();
        }
    }
}
