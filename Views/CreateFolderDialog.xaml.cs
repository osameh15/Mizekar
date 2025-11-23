using System.Windows;
using System.Windows.Input;

namespace MizeKar
{
    public partial class CreateFolderDialog : Window
    {
        public string FolderName { get; private set; } = string.Empty;

        public CreateFolderDialog()
        {
            InitializeComponent();
            FolderNameTextBox.Focus();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FolderNameTextBox.Text))
            {
                FolderName = FolderNameTextBox.Text.Trim();
                DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("لطفاً نام پوشه را وارد کنید.", 
                              "خطا", 
                              MessageBoxButton.OK, 
                              MessageBoxImage.Warning);
                FolderNameTextBox.Focus();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void FolderNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CreateButton_Click(sender, e);
            }
            else if (e.Key == Key.Escape)
            {
                CancelButton_Click(sender, e);
            }
        }
    }
}