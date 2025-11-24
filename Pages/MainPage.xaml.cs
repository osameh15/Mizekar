using System.Windows;
using System.Windows.Controls;

namespace MizeKar.Pages
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to category page - INSTANT, NO FLICKER!
            NavigationService?.Navigate(new CategoryPage());
        }

        private void AboutUsButton_Click(object sender, RoutedEventArgs e)
        {
            var aboutDialog = new AboutUsDialog();
            aboutDialog.Owner = Window.GetWindow(this);
            aboutDialog.ShowDialog();
        }

        private void ContactUsButton_Click(object sender, RoutedEventArgs e)
        {
            var contactDialog = new ContactUsDialog();
            contactDialog.Owner = Window.GetWindow(this);
            contactDialog.ShowDialog();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
