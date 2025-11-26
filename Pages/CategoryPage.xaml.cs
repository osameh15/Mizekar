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

        // Colors for each category (9 distinct colors with 0.7 opacity)
        private static readonly string[] CategoryColors = new[]
        {
            "#B300BCD4", // Cyan - پرورشی
            "#B33498DB", // Blue - آموزشی
            "#B32ECC71", // Green - یادواره شهداء
            "#B39B59B6", // Purple - مشاوره
            "#B3F39C12", // Orange - انجمن اولیاء
            "#B31ABC9C", // Teal - بهداشت
            "#B3E91E63", // Pink - ورزش
            "#B3607D8B", // Gray - چارت عوامل اجرایی
            "#B3E74C3C" // Red - سایر
        };

        private void LoadCategories()
        {
            _categories.Clear();
            var categories = _folderService.GetFolders();

            int colorIndex = 0;
            foreach (var category in categories)
            {
                category.Color = CategoryColors[colorIndex % CategoryColors.Length];
                _categories.Add(category);
                colorIndex++;
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
            // Navigate to MainPage (Home)
            NavigationService?.Navigate(new MainPage());
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

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is FrameworkElement element && element.Tag is string categoryPath)
            {
                var categoryName = System.IO.Path.GetFileName(categoryPath);

                // Find the category color
                string? categoryColor = null;
                foreach (var category in _categories)
                {
                    if (category.Path == categoryPath)
                    {
                        categoryColor = category.Color;
                        break;
                    }
                }

                // Special handling for chart category
                if (categoryName == "چارت عوامل اجرایی، آموزشی و پرورشی")
                {
                    // Navigate to ImageDisplayPage for chart category
                    NavigationService?.Navigate(new ImageDisplayPage(categoryPath));
                }
                else
                {
                    // Navigate to FolderManagementPage with the selected category and color
                    NavigationService?.Navigate(new FolderManagementPage(categoryPath, categoryColor));
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
