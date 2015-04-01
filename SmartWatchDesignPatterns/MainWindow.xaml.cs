using System;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using SmartWatchDesignPatterns.DesignPatterns;
using Clock = SmartWatchDesignPatterns.DesignPatterns.Clock.Clock;
using Stopwatch = SmartWatchDesignPatterns.DesignPatterns.Stopwatch.Stopwatch;
using Timer = SmartWatchDesignPatterns.DesignPatterns.Timer.Timer;

namespace SmartWatchDesignPatterns
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly Clock _clock = new TimeCreator().CreateClock();
        private readonly System.Timers.Timer _clockTimer = new System.Timers.Timer(500);
        private readonly Stopwatch _stopWatch = new TimeCreator().CreateStopwatch();
        private readonly System.Timers.Timer _stopwatchTimer = new System.Timers.Timer(1);
        private readonly Storyboard _storyboard = new Storyboard();
        private readonly TimeCreator _timec = new TimeCreator();
        private readonly System.Timers.Timer _timerTimer = new System.Timers.Timer(1000);
        //Benodigd voor StatePattern color verandering
        //private BrushConverter _conv = new BrushConverter();
        private bool _isTimerRunning, _isStopwatchRunning;
        private int _minutes, _seconds;
        private Timer _timer;
        private TimeSpan _ts;

        public MainWindow()
        {
            InitializeComponent();

            //init timers
            _clockTimer.Elapsed += ClockTimerElapsedEvent;
            _clockTimer.Start();

            _stopwatchTimer.Elapsed += StopWatchTimerEvent;

            _timerTimer.Elapsed += Timer_Tick;

            //Init MementoLabel
            UpdateMementoLabel();
        }

        /// <summary>
        /// Start / pause the stopwatch class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Stopwatch(object sender, RoutedEventArgs e)
        {
            //Stopwatch is paused so start it
            if (_isStopwatchRunning == false)
            {
                _isStopwatchRunning = true;
                _stopWatch.WStopwatch.Start();
                _stopwatchTimer.Start();
            }
            //Stopwatch is running so pause it
            else
            {
                _isStopwatchRunning = false;
                _stopWatch.WStopwatch.Stop();
                _stopwatchTimer.Stop();
            }
        }

        /// <summary>
        /// Save the time from the stopwatch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Time(object sender, RoutedEventArgs e)
        {
            _stopWatch.Originator.savedTime = SwLabel.Content.ToString();
            _stopWatch.Memento = _stopWatch.Originator.CreateMemento();
            _stopWatch.MementoList.Dequeue();
            _stopWatch.MementoList.Enqueue(_stopWatch.Memento.SavedTime);

            UpdateMementoLabel();
        }

        /// <summary>
        /// Update the MementoLabel to the correct data
        /// </summary>
        private void UpdateMementoLabel()
        {
            MementoLabel1.Content = _stopWatch.GetMementoFromQueue(0);
            MementoLabel2.Content = _stopWatch.GetMementoFromQueue(1);
            MementoLabel3.Content = _stopWatch.GetMementoFromQueue(2);
            MementoLabel4.Content = _stopWatch.GetMementoFromQueue(3);
            MementoLabel5.Content = _stopWatch.GetMementoFromQueue(4);
        }

        /*
        private void changeColorGrid()
        {

            SolidColorBrush brush = conv.ConvertFromString(timer.Context.Color) as SolidColorBrush;
            MainGrid.Background = brush;
            MinuteLabel.Content = timer.Minute;
            SecondLabel.Content = timer.Second;
        }*/

        /// <summary>
        /// Get the next Reddit post
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            //itterator is not at end
            if (!_clock.Iterator.IsAtEnd)
            {
                var tempPost = _clock.Iterator.Next();
                //post is not null
                if (tempPost != null)
                {
                    _clock.Post = tempPost;
                }
            }
            MyWipedText.Text = _clock.Post.Title;
            MyWipedText.ToolTip = _clock.Post.Title;
            StartFadeInAnimation();
        }

        /// <summary>
        /// Get the previous Reddit Post
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            //itterator is not at end
            if (!_clock.Iterator.IsAtBegin)
            {
                var tempPost = _clock.Iterator.Previous();
                //post is not null
                if (tempPost != null)
                {
                    _clock.Post = tempPost;
                }
            }
            SetWipedText();
            StartFadeInAnimation();
        }

        /// <summary>
        /// Start the TextBox Fade In Animation
        /// </summary>
        private void StartFadeInAnimation()
        {
            _storyboard.Stop();
            _storyboard.Children.Add(FadeInAnimation);
            _storyboard.Begin(MyWipedText);
        }


        /// <summary>
        /// When the window is loaded set a post and begin animating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetWipedText();
            StartFadeInAnimation();
        }

        /// <summary>
        ///     Sets the WipedTextblock
        /// </summary>
        private void SetWipedText()
        {
            MyWipedText.Text = _clock.Post.Title;
            MyWipedText.ToolTip = _clock.Post.Title;
        }

        /// <summary>
        /// Increment the minute counter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinuteButton_Click(object sender, RoutedEventArgs e)
        {
            _minutes++;
            MinuteLabel.Content = _minutes;
        }

        /// <summary>
        /// Increment the second counter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecondButton_Click(object sender, RoutedEventArgs e)
        {
            if (_seconds < 59)
            {
                _seconds++;
            }
            SecondLabel.Content = _seconds;
        }

        /// <summary>
        /// Try to open a url from a redditpost
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyWipedText_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Process.Start("www.reddit.com" + _clock.Iterator.CurrentItem.Permalink.OriginalString);
            }
            catch
            {
                // ignored
            }
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

        /// <summary>
        /// Undo / Clear the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #region TimerTickEvents
        /// <summary>
        /// Update the Clock gui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClockTimerElapsedEvent(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(delegate { TimeLabel.Content = _clock.GetStringFormattedTime(); });
        }

        /// <summary>
        /// Updates the Stopwatch gui Elements on Timer Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopWatchTimerEvent(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(delegate
            {
                _ts = _stopWatch.WStopwatch.Elapsed;

                var elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", _ts.Hours, _ts.Minutes, _ts.Seconds,
                    _ts.Milliseconds / 10);

                SwLabel.Content = elapsedTime;
            });
        }

        /// <summary>
        /// Ticks the timer and updates the gui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Refresh the RedditPosts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            _clock.RefreshPosts();
            SetWipedText();
            StartFadeInAnimation();
        }
    }
}