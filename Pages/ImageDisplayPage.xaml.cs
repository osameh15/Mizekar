using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace MizeKar.Pages
{
    public partial class ImageDisplayPage : Page
    {
        private readonly string _categoryPath;
        private readonly string _imageFilePath;

        public ImageDisplayPage(string categoryPath)
        {
            InitializeComponent();

            _categoryPath = categoryPath;
            _imageFilePath = Path.Combine(_categoryPath, "chart.png");

            LoadImage();
        }

        private void LoadImage()
        {
            try
            {
                // First try to load the uploaded image
                if (File.Exists(_imageFilePath))
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(_imageFilePath);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    DisplayImage.Source = bitmap;
                    UpdateStatus("چارت سازمانی بارگذاری شد");
                }
                else
                {
                    // Load default chart image from assets
                    var defaultImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Images", "chart.png");
                    if (File.Exists(defaultImagePath))
                    {
                        var bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(defaultImagePath);
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();
                        DisplayImage.Source = bitmap;
                        UpdateStatus("تصویر پیش‌فرض بارگذاری شد");
                    }
                    else
                    {
                        UpdateStatus("تصویری برای نمایش وجود ندارد");
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateStatus("خطا در بارگذاری چارت سازمانی");
                System.Diagnostics.Debug.WriteLine($"Error loading image: {ex.Message}");
            }
        }

        private void UploadImageButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp",
                Title = "انتخاب چارت سازمانی"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Delete previous image if exists
                    if (File.Exists(_imageFilePath))
                    {
                        File.Delete(_imageFilePath);
                    }

                    // Copy new image to category folder
                    File.Copy(openFileDialog.FileName, _imageFilePath, true);

                    // Reload the image
                    LoadImage();
                    UpdateStatus("چارت سازمانی با موفقیت آپلود شد");
                }
                catch (Exception ex)
                {
                    var errorDialog = new ErrorDialog("خطا در آپلود چارت سازمانی. لطفاً دوباره تلاش کنید");

                    // Try to get the parent window for the dialog owner
                    Window? parentWindow = Window.GetWindow(this);
                    if (parentWindow != null)
                    {
                        errorDialog.Owner = parentWindow;
                    }

                    errorDialog.ShowDialog();
                    System.Diagnostics.Debug.WriteLine($"Error uploading image: {ex.Message}");
                }
            }
        }

        private void DisplayImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Toggle fullscreen for the image
            if (DisplayImage.Source != null)
            {
                var fullscreenWindow = new ImageFullscreenWindow(DisplayImage.Source);
                fullscreenWindow.ShowDialog();
            }
        }

        private void BackToCategories_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to CategoryPage
            NavigationService?.Navigate(new CategoryPage());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to MainPage (Home)
            NavigationService?.Navigate(new MainPage());
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

        private void UpdateStatus(string message)
        {
            StatusTextBlock.Text = message;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                BackToCategories_Click(this, new RoutedEventArgs());
            }

            base.OnKeyDown(e);
        }
    }
}
