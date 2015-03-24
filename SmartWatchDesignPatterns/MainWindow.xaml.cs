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

namespace SmartWatchDesignPatterns
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /*
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RedditAPI.PostBuilder postBuilder = new RedditAPI.PostBuilder("r/ProgrammerHumor");
            List<RedditSharp.Things.Post> posts = postBuilder.getPosts();

            foreach(var post in posts)
            {
                Console.WriteLine(post.Title);
            }
        }*/
    }
}
