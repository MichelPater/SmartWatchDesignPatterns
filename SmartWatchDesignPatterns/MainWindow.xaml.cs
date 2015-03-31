using System;
using System.Timers;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using RedditSharp.Things;
using System.Windows.Media;
using SmartWatchDesignPatterns.DesignPatterns;


namespace SmartWatchDesignPatterns
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DesignPatterns.Timer.Timer t;
        private Storyboard storyboard = new Storyboard();
        private TimeCreator timec = new TimeCreator();
        private DesignPatterns.Clock.Clock _clock = new TimeCreator().CreateClock();
        private DesignPatterns.Stopwatch.Stopwatch _stopWatch = new TimeCreator().CreateStopwatch();
        private System.Timers.Timer _clockTimer = new System.Timers.Timer(500);
        private System.Timers.Timer _stopwatchTimer = new System.Timers.Timer(50);
        private System.Timers.Timer _timerTimer = new System.Timers.Timer(1000);
        private TimeSpan ts = new TimeSpan();

        private int minutes = 0;
        private int seconds = 0;

       
        //Benodigd voor StatePattern color verandering
        BrushConverter conv = new BrushConverter();

        public MainWindow()
        {
            InitializeComponent();

            timeLabel.Content = "00:00";

            var datetime = DateTime.Now;

            timeLabel.Content = datetime.Hour + ":" + datetime.Minute;

            _clockTimer.Elapsed += ClockTimerElapsedEvent;
            _clockTimer.Start();

            _stopwatchTimer.Elapsed += StopWatchTimerEvent;

            _timerTimer.Elapsed += Timer_Tick;

            UpdateMementoLabel();

        }

        #region Timerbuttons
        //Buttons voor Timer afdeling

        private void Start_Timer(object sender, RoutedEventArgs e)
        {
            t = timec.CreateTimer(minutes, seconds);
            MinuteLabel.Content = t.Minute;
            SecondLabel.Content = t.Second;


            t.Context.ChangeState();
            _timerTimer.Start();
            //changeColorGrid();
        }

        private void Pauze_Timer(object sender, RoutedEventArgs e)
        {
            t.Context.ChangeState();
            _timerTimer.Stop();
            //changeColorGrid();
        }

        private void Undo_Timer(object sender, RoutedEventArgs e)
        {
            minutes = 0;
            seconds = 0;
            _timerTimer.Stop();
            MinuteLabel.Content = minutes;
            SecondLabel.Content = seconds;
            t.Context.ChangeStateDefault();
        }
        #endregion

        private void Start_Stopwatch(object sender, RoutedEventArgs e)
        {
            _stopWatch.wStopwatch.Start();
            _stopwatchTimer.Start();
        }

        private void Stop_Stopwatch(object sender, RoutedEventArgs e)
        {
            _stopWatch.wStopwatch.Stop();
            _stopwatchTimer.Stop();
        }

        private void Save_Time(object sender, RoutedEventArgs e)
        {
            ts = _stopWatch.wStopwatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            _stopWatch.Originator.savedTime = elapsedTime;
            _stopWatch.Memento = _stopWatch.Originator.CreateMemento();
            _stopWatch.MementoList.Dequeue();
            _stopWatch.MementoList.Enqueue(_stopWatch.Memento.savedTime);

            UpdateMementoLabel();
        }

        private void UpdateMementoLabel()
        {
            mementoLabel1.Content = _stopWatch.getMementoFromQueue(0);
            mementoLabel2.Content = _stopWatch.getMementoFromQueue(1);
            mementoLabel3.Content = _stopWatch.getMementoFromQueue(2);
            mementoLabel4.Content = _stopWatch.getMementoFromQueue(3);
            mementoLabel5.Content = _stopWatch.getMementoFromQueue(4);


        }
        private void changeColorGrid()
        {

            SolidColorBrush brush = conv.ConvertFromString(t.Context.Color) as SolidColorBrush;
            MainGrid.Background = brush;
            MinuteLabel.Content = t.Minute;
            SecondLabel.Content = t.Second;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_clock.Iterator.IsAtEnd)
            {
                Post _tempPost = _clock.Iterator.Next();
                if (_tempPost != null)
                {
                    _clock.Post = _tempPost;
                }
            }
            MyWipedText.Text = _clock.Post.Title;
            MyWipedText.ToolTip = _clock.Post.Title;
            StartFadeInAnimation();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_clock.Iterator.IsAtBegin)
            {
                Post _tempPost = _clock.Iterator.Previous();
                if (_tempPost != null)
                {
                    _clock.Post = _tempPost;
                }
            }
            SetWipedText();
            StartFadeInAnimation();
        }

        private void StartFadeInAnimation()
        {
            storyboard.Stop();
            storyboard.Children.Add(FadeInAnimation);
            storyboard.Begin(MyWipedText);
        }

        #region TimerTickEvents
        private void ClockTimerElapsedEvent(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(new Action(delegate()
            {
                timeLabel.Content = _clock.GetStringFormattedTime();
            }));
        }

        private void StopWatchTimerEvent(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(new Action(delegate()
                {
                    ts = _stopWatch.wStopwatch.Elapsed;

                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

                    swLabel.Content = elapsedTime;
                }));
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Dispatcher.Invoke(new Action(delegate()
            {

                if (t.Minute == 0 && t.Second == 0)
                {
                    _timerTimer.Stop();
                    t.Context.ChangeStateAlarm();
                }
                else
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
            }));
        }

        #endregion
        private void Image_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            _clock.RefreshPosts();
            SetWipedText();
            StartFadeInAnimation();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetWipedText();
            StartFadeInAnimation();
        }

        /// <summary>
        /// Sets the WipedTextblock
        /// </summary>
        private void SetWipedText()
        {
            MyWipedText.Text = _clock.Post.Title;
            MyWipedText.ToolTip = _clock.Post.Title;
        }

        private void MinuteButton_Click(object sender, RoutedEventArgs e)
        {
            minutes += 1;
            MinuteLabel.Content = minutes;
        }

        private void SecondButton_Click(object sender, RoutedEventArgs e)
        {
            if (seconds < 59)
            {
                seconds += 1;
            }
            SecondLabel.Content = seconds;
        }



    }
}

