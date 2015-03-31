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
namespace SmartWatchDesignPatterns
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        swdp.Timer.Timer t;

        public MainWindow()
        {
            InitializeComponent();

            timeLabel.Content  ="00:00";

            var datetime = DateTime.Now;
            timeLabel.Content = datetime.Hour + ":" + datetime.Minute;


            SmartWatchDesignPatterns.DesignPatterns.Clock.TimeDisplay _timeDisplay = new TimeDisplay();
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

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Timer_Button_Click(object sender, RoutedEventArgs e)
        {
            //StateNameLabel.Content = t.getColor();
        }

        private void Undo_Timer(object sender, RoutedEventArgs e)
        {

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
