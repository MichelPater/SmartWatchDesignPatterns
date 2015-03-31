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
using SmartWatchDesignPatterns.DesignPatterns.Clock;
using swdp = SmartWatchDesignPatterns.DesignPatterns;
using System.Windows.Threading;
namespace SmartWatchDesignPatterns
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        swdp.Timer.Timer t;

        //DispatcherTimer benodigdheden
        private DispatcherTimer Ttimer;

        public MainWindow()
        {
            InitializeComponent();

            timeLabel.Content  ="00:00";

            var datetime = DateTime.Now;

            timeLabel.Content = datetime.Hour + ":" + datetime.Minute;     

            SmartWatchDesignPatterns.DesignPatterns.Clock.TimeDisplay _timeDisplay = new TimeDisplay();

            //Constructor voor DispatcherTimer
            Ttimer = new DispatcherTimer();
            Ttimer.Interval = new TimeSpan(0, 0, 1);
            Ttimer.Tick += new EventHandler(Timer_Tick);

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


        
        /*
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RedditAPI.PostBuilder postBuilder = new RedditAPI.PostBuilder("r/ProgrammerHumor");
            List<RedditSharp.Things.Post> posts = postBuilder.GetPosts();

            foreach(var post in posts)
            {
                Console.WriteLine(post.Title);
            }
        }*/
    }
}
