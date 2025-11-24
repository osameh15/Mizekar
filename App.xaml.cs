using System;
using System.Windows;

namespace MizeKar
{
    public partial class App : Application
    {
        // Application-level constants and configuration
        public const string DATA_FOLDER_NAME = "Data";
        public const int SPLASH_SCREEN_DURATION_MS = 5000;
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            // Ensure Data folder and categories exist
            EnsureDataFolderExists();
            EnsureCategoriesExist();
        }
        
        private void EnsureDataFolderExists()
        {
            string dataFolderPath = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, 
                DATA_FOLDER_NAME);
                
            if (!System.IO.Directory.Exists(dataFolderPath))
            {
                System.IO.Directory.CreateDirectory(dataFolderPath);
            }
        }
        
        private void EnsureCategoriesExist()
        {
            string dataFolderPath = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, 
                DATA_FOLDER_NAME);
                
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
                string categoryPath = System.IO.Path.Combine(dataFolderPath, category);
                if (!System.IO.Directory.Exists(categoryPath))
                {
                    System.IO.Directory.CreateDirectory(categoryPath);
                }
            }
        }
    }
}