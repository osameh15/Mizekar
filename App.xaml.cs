using System;
using System.Windows;

namespace MizeKar
{
    public partial class App : Application
    {
        // Application-level constants and configuration
        public const string DATA_FOLDER_NAME = "Data";
        public const int SPLASH_SCREEN_DURATION_MS = 5000;

        // Centralized data folder path - uses AppData for user-writable location
        public static string DataFolderPath => System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "MizeKar",
            DATA_FOLDER_NAME);
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            // Ensure Data folder and categories exist
            EnsureDataFolderExists();
            EnsureCategoriesExist();
        }
        
        private void EnsureDataFolderExists()
        {
            if (!System.IO.Directory.Exists(DataFolderPath))
            {
                System.IO.Directory.CreateDirectory(DataFolderPath);
            }
        }
        
        private void EnsureCategoriesExist()
        {
            // Define the 9 main categories
            string[] categories = new[]
            {
                "آموزشی",
                "پرورشی", 
                "انجمن اولیاء",
                "یادواره شهداء",
                "چارت عوامل اجرایی، آموزشی و پرورشی",
                "ورزش",
                "بهداشت",
                "مشاوره",
                "سایر"
            };
            
            // Create each category folder if it doesn't exist
            foreach (string category in categories)
            {
                string categoryPath = System.IO.Path.Combine(DataFolderPath, category);
                if (!System.IO.Directory.Exists(categoryPath))
                {
                    System.IO.Directory.CreateDirectory(categoryPath);
                }
            }
        }
    }
}