using System;
using System.Windows;
using System.Windows.Threading;

namespace MizeKar
{
    public partial class SplashScreen : Window
    {
        private readonly DispatcherTimer _timer;

        public SplashScreen()
        {
            InitializeComponent();
            
            // Set up timer for automatic transition to main screen
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(App.SPLASH_SCREEN_DURATION_MS)
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            
            // Open main screen and close splash screen
            var mainScreen = new MainScreen();
            mainScreen.Show();
            
            this.Close();
        }
    }
}