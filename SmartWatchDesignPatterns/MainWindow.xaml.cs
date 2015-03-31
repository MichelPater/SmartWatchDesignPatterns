using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RedditSharp.Things;
using SmartWatchDesignPatterns.DesignPatterns.Clock;
using SmartWatchDesignPatterns.DesignPatterns.Clock.Iterator;
using swdp = SmartWatchDesignPatterns.DesignPatterns;
using System.Windows.Threading;

namespace SmartWatchDesignPatterns
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private swdp.Timer.Timer t;
        private Iterator iterator;
        private Post post;
        private Storyboard storyboard = new Storyboard();

        //DispatcherTimer benodigdheden
        private DispatcherTimer Ttimer;

        public MainWindow()
        {
            InitializeComponent();

            timeLabel.Content = "00:00";

            var datetime = DateTime.Now;

            timeLabel.Content = datetime.Hour + ":" + datetime.Minute;


            //Constructor voor DispatcherTimer
            Ttimer = new DispatcherTimer();
            Ttimer.Interval = new TimeSpan(0, 0, 1);
            Ttimer.Tick += new EventHandler(Timer_Tick);


            // SmartWatchDesignPatterns.DesignPatterns.Clock.TimeDisplay _timeDisplay = new TimeDisplay();
            CreatePost();

        }

        //Buttons voor Timer afdeling

        private void Set_Timer(object sender, RoutedEventArgs e)
        {
            t = new swdp.Timer.Timer(Int32.Parse(minutebox.Text), Int32.Parse(secondbox.Text));
            minutebox.Text = "";
            secondbox.Text = "";
            MinuteLabel.Content = t.Minute;
            SecondLabel.Content = t.Second;
        }

        private void Start_Timer(object sender, RoutedEventArgs e)
        {
            t.Context.ChangeState();
            Ttimer.Start();
        }

        private void Pauze_Timer(object sender, RoutedEventArgs e)
        {
            t.Context.ChangeState();
            Ttimer.Stop();

        }

        private void Undo_Timer(object sender, RoutedEventArgs e)
        {
            Ttimer.Stop();
            MinuteLabel.Content = "";
            SecondLabel.Content = "";
        }

        //DispatcherTimer Tick Methodes
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (t.Second >= 1)
            {
                --t.Second;
            }
            else
            {
                t.Second = 59;
                --t.Minute;
            }
            MinuteLabel.Content = t.Minute;
            SecondLabel.Content = t.Second;

        }
        
        private void CreatePost()
        {
            PostBuilder postBuilder = new PostBuilder("r/ProgrammerHumor");
            Collection posts = postBuilder.GetPosts();

            iterator = new Iterator(posts);
            post = iterator.CurrentItem;
            MyWipedText.Text = post.Title;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (!iterator.IsAtEnd)
            {
                Post _tempPost = iterator.Next();
                if (_tempPost != null)
                {
                    post = _tempPost;
                }
            }
            MyWipedText.Text = post.Title;
            //StartFadeInAnimation();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (!iterator.IsAtBegin)
            {
                Post _tempPost = iterator.Previous();
                if (_tempPost != null)
                {
                    post = _tempPost;
                }
            }
            MyWipedText.Text = post.Title;
            //StartFadeInAnimation();

        }


        private void StartFadeInAnimation()
        {
            storyboard.Stop();
            storyboard.Children.Add(FadeInAnimation);
            storyboard.Begin(MyWipedText);
        }
        }
}
