using System.Windows;
using System.Windows.Input;

namespace MizeKar
{
    public partial class ExitConfirmDialog : Window
    {
        public bool ExitConfirmed { get; private set; } = false;

        public ExitConfirmDialog()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            ExitConfirmed = true;
            DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ExitConfirmed = false;
            DialogResult = false;
            this.Close();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ExitButton_Click(this, e);
            }
            else if (e.Key == Key.Escape)
            {
                CancelButton_Click(this, e);
            }

            base.OnKeyDown(e);
        }
    }
}
