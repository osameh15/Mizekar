using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MizeKar.Pages
{
    public partial class SplashPage : Page
    {
        private readonly DispatcherTimer _timer;

        public SplashPage()
        {
            InitializeComponent();

            // Set up timer for automatic transition to main page
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(App.SPLASH_SCREEN_DURATION_MS)
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            _timer.Stop();

            // Navigate to main page - INSTANT, NO FLICKER!
            NavigationService?.Navigate(new MainPage());
        }
    }
}
