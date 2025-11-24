using System.Windows;

namespace MizeKar
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Start with splash screen page
            MainFrame.Navigate(new Pages.SplashPage());
        }
    }
}
