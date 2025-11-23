using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MizeKar.Models;
using MizeKar.Services;

namespace MizeKar
{
    public partial class FolderManagementScreen : Window
    {
        private readonly FolderService _folderService;
        private readonly ObservableCollection<FolderInfo> _folders;

        public FolderManagementScreen()
        {
            InitializeComponent();
            
            _folderService = new FolderService();
            _folders = new ObservableCollection<FolderInfo>();
            
            LoadFolders();
            
            // Subscribe to folder changes
            _folderService.FoldersChanged += OnFoldersChanged;
        }

        private void LoadFolders()
        {
            _folders.Clear();
            var folders = _folderService.GetFolders();
            
            foreach (var folder in folders)
            {
                _folders.Add(folder);
            }
            
            FoldersItemsControl.ItemsSource = _folders;
            UpdateStatus($"{_folders.Count} پوشه یافت شد");
        }

        private void OnFoldersChanged(object sender, EventArgs e)
        {
            // Use dispatcher to update UI from background thread
            Dispatcher.Invoke(() =>
            {
                LoadFolders();
            });
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainScreen = new MainScreen();
            mainScreen.Show();
            this.Close();
        }

        private void CreateFolderButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CreateFolderDialog();
            dialog.Owner = this;
            
            if (dialog.ShowDialog() == true && !string.IsNullOrWhiteSpace(dialog.FolderName))
            {
                if (_folderService.CreateFolder(dialog.FolderName))
                {
                    UpdateStatus("پوشه با موفقیت ایجاد شد");
                }
                else
                {
                    MessageBox.Show("خطا در ایجاد پوشه. لطفاً نام دیگری انتخاب کنید.", 
                                  "خطا", 
                                  MessageBoxButton.OK, 
                                  MessageBoxImage.Error);
                }
            }
        }

        private void ViewFolder_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is FrameworkElement element && element.Tag is string folderPath)
            {
                _folderService.OpenFolderInExplorer(folderPath);
                UpdateStatus("پوشه در Windows Explorer باز شد");
            }
        }

        private void DeleteFolder_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is FrameworkElement element && element.Tag is string folderPath)
            {
                var folderName = System.IO.Path.GetFileName(folderPath);
                
                var result = MessageBox.Show($"آیا از حذف پوشه '{folderName}' اطمینان دارید؟", 
                                           "تأیید حذف", 
                                           MessageBoxButton.YesNo, 
                                           MessageBoxImage.Warning);
                
                if (result == MessageBoxResult.Yes)
                {
                    if (_folderService.DeleteFolder(folderPath))
                    {
                        UpdateStatus("پوشه با موفقیت حذف شد");
                    }
                    else
                    {
                        MessageBox.Show("خطا در حذف پوشه. لطفاً دوباره تلاش کنید.", 
                                      "خطا", 
                                      MessageBoxButton.OK, 
                                      MessageBoxImage.Error);
                    }
                }
            }
        }

        private void UpdateStatus(string message)
        {
            StatusTextBlock.Text = message;
        }

        protected override void OnClosed(EventArgs e)
        {
            _folderService?.Dispose();
            base.OnClosed(e);
        }

        // Handle keyboard shortcuts
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                BackButton_Click(this, new RoutedEventArgs());
            }
            else if (e.Key == Key.N && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                CreateFolderButton_Click(this, new RoutedEventArgs());
            }
            
            base.OnKeyDown(e);
        }
    }
}