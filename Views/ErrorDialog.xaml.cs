using System.Windows;
using System.Windows.Input;

namespace MizeKar
{
    public partial class ErrorDialog : Window
    {
        public ErrorDialog(string errorMessage)
        {
            InitializeComponent();
            
            // Set the error message
            ErrorMessageTextBlock.Text = errorMessage;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Escape)
            {
                OkButton_Click(this, e);
            }
            
            base.OnKeyDown(e);
        }
    }
}