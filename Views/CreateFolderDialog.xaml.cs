using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

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
                // Validate folder name
                if (IsValidFolderName(FolderNameTextBox.Text.Trim()))
                {
                    FolderName = FolderNameTextBox.Text.Trim();
                    DialogResult = true;
                    this.Close();
                }
                else
                {
                    var errorDialog = new ErrorDialog("نام پوشه فقط می‌تواند شامل حروف فارسی، اعداد، فاصله، خط تیره (-) و زیرخط (_) باشد");
                    errorDialog.Owner = this;
                    errorDialog.ShowDialog();
                    FolderNameTextBox.Focus();
                }
            }
            else
            {
                MessageBox.Show("لطفاً نام پوشه را وارد کنید", 
                              "خطا", 
                              MessageBoxButton.OK, 
                              MessageBoxImage.Warning);
                FolderNameTextBox.Focus();
            }
        }

        private bool IsValidFolderName(string folderName)
        {
            // Persian characters range: \u0600-\u06FF
            // Numbers: 0-9
            // Allowed special characters: - _ and space
            foreach (char c in folderName)
            {
                if (!((c >= '\u0600' && c <= '\u06FF') || // Persian characters
                      (c >= '0' && c <= '9') ||           // Numbers
                      c == '-' ||                         // Hyphen
                      c == '_' ||                         // Underscore
                      c == ' '))                          // Space
                {
                    return false;
                }
            }
            return true;
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

        private void FolderNameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Validate each character as it's being typed
            foreach (char c in e.Text)
            {
                if (!((c >= '\u0600' && c <= '\u06FF') || // Persian characters
                      (c >= '0' && c <= '9') ||           // Numbers
                      c == '-' ||                         // Hyphen
                      c == '_' ||                         // Underscore
                      c == ' '))                          // Space
                {
                    e.Handled = true; // Prevent the character from being entered
                    ShowInvalidCharacterIndicator();
                    return;
                }
            }
        }

        private void ShowInvalidCharacterIndicator()
        {
            // Stop any existing animation first
            InvalidCharIndicator.BeginAnimation(OpacityProperty, null);
            
            // Reset to fully transparent
            InvalidCharIndicator.Opacity = 0;
            
            // Create animation to show the indicator
            var animation = new DoubleAnimation
            {
                From = 0,
                To = 0.8,
                Duration = TimeSpan.FromMilliseconds(150),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(2)
            };
            
            // Set animation completion handler to ensure it returns to transparent
            animation.Completed += (s, e) =>
            {
                InvalidCharIndicator.Opacity = 0;
            };
            
            InvalidCharIndicator.BeginAnimation(OpacityProperty, animation);
        }
    }
}