using System.Windows;

namespace MizeKar
{
    public partial class ContactUsDialog : Window
    {
        public ContactUsDialog()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}