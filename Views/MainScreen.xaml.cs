using System.Windows;

namespace MizeKar
{
    public partial class MainScreen : Window
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to folder management screen
            var folderScreen = new FolderManagementScreen();
            folderScreen.Show();
            this.Close();
        }

        private void AboutUsButton_Click(object sender, RoutedEventArgs e)
        {
            var aboutDialog = new AboutUsDialog();
            aboutDialog.Owner = this;
            aboutDialog.ShowDialog();
        }

        private void ContactUsButton_Click(object sender, RoutedEventArgs e)
        {
            var contactDialog = new ContactUsDialog();
            contactDialog.Owner = this;
            contactDialog.ShowDialog();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}