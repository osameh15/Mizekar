using System.Windows;
using System.Windows.Input;

namespace MizeKar
{
    public partial class DeleteConfirmDialog : Window
    {
        public bool DeleteConfirmed { get; private set; } = false;

        public DeleteConfirmDialog(string folderName)
        {
            InitializeComponent();
            
            // Set the message with the folder name
            MessageTextBlock.Text = $"آیا از حذف پوشه '{folderName}' اطمینان دارید؟";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteConfirmed = true;
            DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteConfirmed = false;
            DialogResult = false;
            this.Close();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DeleteButton_Click(this, e);
            }
            else if (e.Key == Key.Escape)
            {
                CancelButton_Click(this, e);
            }
            
            base.OnKeyDown(e);
        }
    }
}