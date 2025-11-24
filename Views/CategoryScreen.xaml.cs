using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MizeKar.Models;
using MizeKar.Services;

namespace MizeKar
{
    public partial class CategoryScreen : Window
    {
        private readonly FolderService _folderService;
        private readonly ObservableCollection<FolderInfo> _categories;

        public CategoryScreen()
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
            var mainScreen = new MainScreen();
            mainScreen.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is FrameworkElement element && element.Tag is string categoryPath)
            {
                var categoryName = System.IO.Path.GetFileName(categoryPath);
                
                // Navigate to FolderManagementScreen with the selected category
                var folderScreen = new FolderManagementScreen(categoryPath);
                folderScreen.Show();
                this.Close();
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
            
            base.OnKeyDown(e);
        }
    }
}