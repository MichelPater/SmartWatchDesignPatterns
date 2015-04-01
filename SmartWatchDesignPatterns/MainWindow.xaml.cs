using System;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using RedditSharp.Things;
using SmartWatchDesignPatterns.DesignPatterns;
using Clock = SmartWatchDesignPatterns.DesignPatterns.Clock.Clock;
using Stopwatch = SmartWatchDesignPatterns.DesignPatterns.Stopwatch.Stopwatch;
using Timer = SmartWatchDesignPatterns.DesignPatterns.Timer.Timer;

namespace SmartWatchDesignPatterns
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Timer _timer;
        private readonly Storyboard _storyboard = new Storyboard();
        private readonly TimeCreator _timec = new TimeCreator();
        private Clock _clock = new TimeCreator().CreateClock();
        private readonly Stopwatch _stopWatch = new TimeCreator().CreateStopwatch();
        private readonly System.Timers.Timer _clockTimer = new System.Timers.Timer(500);
        private readonly System.Timers.Timer _stopwatchTimer = new System.Timers.Timer(1);
        private readonly System.Timers.Timer _timerTimer = new System.Timers.Timer(1000);
        private TimeSpan _ts;
        private bool _isTimerRunning, _isStopwatchRunning;
        private int _minutes, _seconds;


        //Benodigd voor StatePattern color verandering
        BrushConverter _conv = new BrushConverter();

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
            if (_isTimerRunning == false)
            {
                _isTimerRunning = true;

                _timer = _timec.CreateTimer(_minutes, _seconds);
                MinuteLabel.Content = _timer.Minute;
                SecondLabel.Content = _timer.Second;
                _timer.Context.ChangeState();
                _timerTimer.Start();
                //changeColorGrid();
            }

            else
            {
                _isTimerRunning = false;

                _minutes = _timer.Minute;
                _seconds = _timer.Second;

                _timer.Context.ChangeState();
                _timerTimer.Stop();
                //changeColorGrid();
            }
        }


        private void Undo_Timer(object sender, RoutedEventArgs e)
        {
            _minutes = 0;
            _seconds = 0;
            _timerTimer.Stop();
            MinuteLabel.Content = _minutes;
            SecondLabel.Content = _seconds;

            if (_timer != null)
            {
                _timer.Context.ChangeStateDefault();
            }

        }
        #endregion

        private void Start_Stopwatch(object sender, RoutedEventArgs e)
        {
            if (_isStopwatchRunning == false)
            {
                _isStopwatchRunning = true;
                _stopWatch.wStopwatch.Start();
                _stopwatchTimer.Start();
            }
            else
            {
                _isStopwatchRunning = false;
                _stopWatch.wStopwatch.Stop();
                _stopwatchTimer.Stop();
            }
        }

       
        private void Save_Time(object sender, RoutedEventArgs e)
        {
            _stopWatch.Originator.savedTime = swLabel.Content.ToString();
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
        /*
        private void changeColorGrid()
        {

            SolidColorBrush brush = conv.ConvertFromString(timer.Context.Color) as SolidColorBrush;
            MainGrid.Background = brush;
            MinuteLabel.Content = timer.Minute;
            SecondLabel.Content = timer.Second;
        }*/

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_clock.Iterator.IsAtEnd)
            {
                Post tempPost = _clock.Iterator.Next();
                if (tempPost != null)
                {
                    _clock.Post = tempPost;
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
                Post tempPost = _clock.Iterator.Previous();
                if (tempPost != null)
                {
                    _clock.Post = tempPost;
                }
            }
            SetWipedText();
            StartFadeInAnimation();
        }

        private void StartFadeInAnimation()
        {
            _storyboard.Stop();
            _storyboard.Children.Add(FadeInAnimation);
            _storyboard.Begin(MyWipedText);
        }

        #region TimerTickEvents
        private void ClockTimerElapsedEvent(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(delegate {
                                           timeLabel.Content = _clock.GetStringFormattedTime();
            });
        }

        private void StopWatchTimerEvent(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(delegate
            {
                _ts = _stopWatch.wStopwatch.Elapsed;

                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", _ts.Hours, _ts.Minutes, _ts.Seconds, _ts.Milliseconds / 10);

                swLabel.Content = elapsedTime;
            });
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Dispatcher.Invoke(delegate
            {

                if (_timer.Minute == 0 && _timer.Second == 0)
                {
                    _timerTimer.Stop();
                    _timer.Context.ChangeStateAlarm();
                }
                else
                {

                    if (_timer.Second >= 1)
                    {
                        --_timer.Second;
                    }
                    else
                    {
                        _timer.Second = 59;
                        --_timer.Minute;
                    }
                    MinuteLabel.Content = _timer.Minute;
                    SecondLabel.Content = _timer.Second;
                }
            });
        }

        #endregion
        private void Image_KeyDown(object sender, KeyEventArgs e)
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
            _minutes += 1;
            MinuteLabel.Content = _minutes;
        }

        private void SecondButton_Click(object sender, RoutedEventArgs e)
        {
            if (_seconds < 59)
            {
                _seconds += 1;
            }
            SecondLabel.Content = _seconds;
        }

        private void MyWipedText_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try

                
            {
                Process.Start("www.reddit.com"+ _clock.Iterator.CurrentItem.Permalink.OriginalString);
            }
            catch { }
        }



    }
}

