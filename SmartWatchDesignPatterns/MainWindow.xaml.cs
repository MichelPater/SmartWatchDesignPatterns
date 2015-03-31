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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RedditSharp.Things;
using SmartWatchDesignPatterns.DesignPatterns.Clock;
using SmartWatchDesignPatterns.DesignPatterns.Clock.Iterator;
using swdp = SmartWatchDesignPatterns.DesignPatterns;

namespace SmartWatchDesignPatterns
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private swdp.Timer.Timer t;

        public MainWindow()
        {
            InitializeComponent();

            timeLabel.Content = "00:00";

            var datetime = DateTime.Now;

            timeLabel.Content = datetime.Hour + ":" + datetime.Minute;

            // SmartWatchDesignPatterns.DesignPatterns.Clock.TimeDisplay _timeDisplay = new TimeDisplay();
            CreatePost();
        }

        private void Set_Timer(object sender, RoutedEventArgs e)
        {
            t = new swdp.Timer.Timer(Int32.Parse(minutebox.Text), Int32.Parse(secondbox.Text));
            minutebox.Text = "";
            secondbox.Text = "";
            StateNameLabel.Content = t.getSecond();
            StateColorLabel.Content = t.getMinute();
        }

        private void Start_Timer(object sender, RoutedEventArgs e)
        {
            t.Context.ChangeState();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Timer_Button_Click(object sender, RoutedEventArgs e)
        {
            StateNameLabel.Content = t.Context.Color;
        }

        private void Undo_Timer(object sender, RoutedEventArgs e)
        {

        }



        private void CreatePost()
        {
            PostBuilder postBuilder = new PostBuilder("r/ProgrammerHumor");
            Collection posts = postBuilder.GetPosts();

            Iterator iterator = new Iterator(posts);

            for (Post post = iterator.First(); !iterator.IsAtEnd; post = iterator.Next())
            {
                Console.WriteLine(post.Title);
            }
        }
    }
}