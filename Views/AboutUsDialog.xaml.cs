using System.Windows;

namespace MizeKar
{
    public partial class AboutUsDialog : Window
    {
        public AboutUsDialog()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}