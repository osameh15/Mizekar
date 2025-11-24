using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MizeKar
{
    public partial class ImageFullscreenWindow : Window
    {
        public ImageFullscreenWindow(ImageSource imageSource)
        {
            InitializeComponent();
            FullscreenImage.Source = imageSource;
        }

        private void FullscreenImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Close the fullscreen window when clicked
            this.Close();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
            
            base.OnKeyDown(e);
        }
    }
}