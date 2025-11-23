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
            
            // Ensure Data folder exists
            EnsureDataFolderExists();
        }
        
        private void EnsureDataFolderExists()
        {
            string dataFolderPath = System.IO.Path.Combine(
                System.IO.Directory.GetCurrentDirectory(), 
                DATA_FOLDER_NAME);
                
            if (!System.IO.Directory.Exists(dataFolderPath))
            {
                System.IO.Directory.CreateDirectory(dataFolderPath);
            }
        }
    }
}