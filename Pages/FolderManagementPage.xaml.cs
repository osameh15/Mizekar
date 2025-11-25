using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MizeKar.Models;
using MizeKar.Services;

namespace MizeKar.Pages
{
    public partial class FolderManagementPage : Page
    {
        private readonly FolderService _folderService;
        private readonly ObservableCollection<FolderInfo> _folders;
        private readonly string? _categoryPath;

        public FolderManagementPage() : this(null)
        {
        }

        public FolderManagementPage(string? categoryPath)
        {
            InitializeComponent();

            _categoryPath = categoryPath;
            _folderService = new FolderService();
            _folders = new ObservableCollection<FolderInfo>();

            // Update title if in category mode
            if (_categoryPath != null)
            {
                var categoryName = System.IO.Path.GetFileName(_categoryPath);
                TitleTextBlock.Text = $"مدیریت پوشه‌ها - {categoryName}";

                // Start category-specific watching
                _folderService.StartCategoryWatching(_categoryPath);
            }

            LoadFolders();

            // Subscribe to folder changes
            _folderService.FoldersChanged += OnFoldersChanged;
        }

        private void LoadFolders()
        {
            _folders.Clear();

            List<FolderInfo> folders;
            if (_categoryPath != null)
            {
                // Load folders from specific category
                folders = _folderService.GetFoldersFromCategory(_categoryPath);
                var categoryName = System.IO.Path.GetFileName(_categoryPath);
                UpdateStatus($"تعداد {folders.Count} پوشه در دسته '{categoryName}' یافت شد");
            }
            else
            {
                // Load all folders from root (for backward compatibility)
                folders = _folderService.GetFolders();
                UpdateStatus($"تعداد {folders.Count} پوشه یافت شد");
            }

            foreach (var folder in folders)
            {
                _folders.Add(folder);
            }

            FoldersItemsControl.ItemsSource = _folders;

            // Show/hide empty state message
            if (_folders.Count == 0)
            {
                EmptyStateTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                EmptyStateTextBlock.Visibility = Visibility.Collapsed;
            }
        }

        private void OnFoldersChanged(object? sender, EventArgs e)
        {
            // Use dispatcher to update UI from background thread
            Dispatcher.Invoke(() =>
            {
                LoadFolders();
            });
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to MainPage (Home)
            NavigationService?.Navigate(new MainPage());
        }

        private void BackToCategories_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to CategoryPage
            NavigationService?.Navigate(new CategoryPage());
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadFolders();
            UpdateStatus("لیست پوشه‌ها بارگذاری شد");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var exitDialog = new ExitConfirmDialog();
            exitDialog.Owner = Window.GetWindow(this);

            if (exitDialog.ShowDialog() == true && exitDialog.ExitConfirmed)
            {
                Application.Current.Shutdown();
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

        private void CreateFolderButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CreateFolderDialog();

            // Try to get the parent window for the dialog owner
            Window? parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                dialog.Owner = parentWindow;
            }

            if (dialog.ShowDialog() == true && !string.IsNullOrWhiteSpace(dialog.FolderName))
            {
                if (_folderService.CreateFolder(dialog.FolderName, _categoryPath))
                {
                    UpdateStatus("پوشه با موفقیت ایجاد شد");
                }
                else
                {
                    var errorDialog = new ErrorDialog("خطا در ایجاد پوشه، لطفاً نام دیگری انتخاب کنید");
                    if (parentWindow != null)
                    {
                        errorDialog.Owner = parentWindow;
                    }
                    errorDialog.ShowDialog();
                }
            }
        }

        private void ViewFolder_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is FrameworkElement element && element.Tag is string folderPath)
            {
                var folderName = System.IO.Path.GetFileName(folderPath);

                _folderService.OpenFolderInExplorer(folderPath);
                UpdateStatus($"پوشه {folderName} با موفقیت باز شد");
            }
        }

        private void DeleteFolder_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is FrameworkElement element && element.Tag is string folderPath)
            {
                var folderName = System.IO.Path.GetFileName(folderPath);

                // Show delete confirmation dialog
                var confirmDialog = new DeleteConfirmDialog(folderName);

                // Try to get the parent window for the dialog owner
                Window? parentWindow = Window.GetWindow(this);
                if (parentWindow != null)
                {
                    confirmDialog.Owner = parentWindow;
                }

                if (confirmDialog.ShowDialog() == true && confirmDialog.DeleteConfirmed)
                {
                    if (_folderService.DeleteFolder(folderPath))
                    {
                        UpdateStatus("پوشه با موفقیت حذف شد");
                    }
                    else
                    {
                        var errorDialog = new ErrorDialog("خطا در حذف پوشه. لطفاً دوباره تلاش کنید");
                        if (parentWindow != null)
                        {
                            errorDialog.Owner = parentWindow;
                        }
                        errorDialog.ShowDialog();
                    }
                }
            }
        }

        private void UpdateStatus(string message)
        {
            StatusTextBlock.Text = message;
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

        // Cleanup when page is unloaded
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            _folderService?.Dispose();
        }
    }
}
