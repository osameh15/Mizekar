using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MizeKar.Models;
using MizeKar.Services;

namespace MizeKar.Pages
{
    public partial class CategoryPage : Page
    {
        private readonly FolderService _folderService;
        private readonly ObservableCollection<FolderInfo> _categories;

        public CategoryPage()
        {
            InitializeComponent();

            _folderService = new FolderService();
            _categories = new ObservableCollection<FolderInfo>();

            LoadCategories();

            // Subscribe to folder changes
            _folderService.FoldersChanged += OnCategoriesChanged;
        }

        private void LoadCategories()
        {
            _categories.Clear();
            var categories = _folderService.GetFolders();

            foreach (var category in categories)
            {
                _categories.Add(category);
            }

            CategoriesItemsControl.ItemsSource = _categories;
            UpdateStatus($"تعداد {_categories.Count} دسته‌بندی یافت شد");
        }

        private void OnCategoriesChanged(object? sender, EventArgs e)
        {
            // Use dispatcher to update UI from background thread
            Dispatcher.Invoke(() =>
            {
                LoadCategories();
            });
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back using NavigationService
            NavigationService?.GoBack();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Exit the application
            Application.Current.Shutdown();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is FrameworkElement element && element.Tag is string categoryPath)
            {
                var categoryName = System.IO.Path.GetFileName(categoryPath);

                // Special handling for chart category
                if (categoryName == "چارت عوامل اجرایی، آموزشی و پرورشی")
                {
                    // Navigate to ImageDisplayPage for chart category
                    NavigationService?.Navigate(new ImageDisplayPage(categoryPath));
                }
                else
                {
                    // Navigate to FolderManagementPage with the selected category
                    NavigationService?.Navigate(new FolderManagementPage(categoryPath));
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

            base.OnKeyDown(e);
        }

        // Cleanup when page is unloaded
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            _folderService?.Dispose();
        }
    }
}
