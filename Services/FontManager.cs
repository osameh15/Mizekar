using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media;

namespace MizeKar.Services
{
    public class FontManager
    {
        private static readonly FontManager _instance = new FontManager();
        public static FontManager Instance => _instance;

        private readonly Dictionary<string, FontFamily> _loadedFonts;
        private FontFamily? _primaryPersianFont;
        private FontFamily? _fallbackFont;

        public FontFamily PrimaryPersianFont => _primaryPersianFont ?? (_fallbackFont ?? new FontFamily("Tahoma"));
        public FontFamily FallbackFont => _fallbackFont ?? new FontFamily("Tahoma");

        private FontManager()
        {
            _loadedFonts = new Dictionary<string, FontFamily>();
            InitializeFonts();
        }

        private void InitializeFonts()
        {
            // Set fallback font (Tahoma has good Persian support)
            _fallbackFont = new FontFamily("Tahoma");

            // Try to load embedded fonts
            LoadEmbeddedFonts();

            // Set primary Persian font
            SetPrimaryPersianFont();
        }

        private void LoadEmbeddedFonts()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceNames = assembly.GetManifestResourceNames();

                foreach (var resourceName in resourceNames)
                {
                    if (resourceName.EndsWith(".ttf") || resourceName.EndsWith(".otf"))
                    {
                        LoadEmbeddedFont(assembly, resourceName);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading embedded fonts: {ex.Message}");
            }
        }

        private void LoadEmbeddedFont(Assembly assembly, string resourceName)
        {
            try
            {
                using var stream = assembly.GetManifestResourceStream(resourceName);
                if (stream != null)
                {
                    // For embedded fonts, we would need to extract and install them
                    // For now, we'll rely on system fonts
                    System.Diagnostics.Debug.WriteLine($"Found embedded font: {resourceName}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading font {resourceName}: {ex.Message}");
            }
        }

        private void SetPrimaryPersianFont()
        {
            // Try to find the best available Persian font
            var preferredFonts = new[]
            {
                "Shabnam",        // Primary Persian font from assets
                "B Nazanin",      // Popular Persian font
                "B Yekan",        // Modern Persian font  
                "B Mitra",        // Traditional Persian font
                "Iranian Sans",   // Good Persian support
                "Tahoma",         // Good Persian support in Windows
                "Arial"           // Basic Persian support
            };

            foreach (var fontName in preferredFonts)
            {
                if (IsFontAvailable(fontName))
                {
                    _primaryPersianFont = new FontFamily(fontName);
                    System.Diagnostics.Debug.WriteLine($"Using Persian font: {fontName}");
                    return;
                }
            }

            // Fallback to system default
            _primaryPersianFont = _fallbackFont;
            System.Diagnostics.Debug.WriteLine("Using fallback font for Persian text");
        }

        private bool IsFontAvailable(string fontName)
        {
            try
            {
                var font = new FontFamily(fontName);
                // Try to create a typeface to verify the font exists
                var typeface = new Typeface(font, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
                return typeface.TryGetGlyphTypeface(out _);
            }
            catch
            {
                return false;
            }
        }

        public FontFamily GetFontForLanguage(string text)
        {
            // Simple heuristic to detect Persian text
            if (ContainsPersianCharacters(text))
            {
                return PrimaryPersianFont;
            }
            
            return _fallbackFont ?? new FontFamily("Tahoma");
        }

        private bool ContainsPersianCharacters(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            // Persian/Arabic character ranges
            foreach (char c in text)
            {
                // Persian/Arabic characters
                if ((c >= '\u0600' && c <= '\u06FF') ||  // Arabic block
                    (c >= '\u0750' && c <= '\u077F') ||  // Arabic Supplement
                    (c >= '\u08A0' && c <= '\u08FF') ||  // Arabic Extended-A
                    (c >= '\uFB50' && c <= '\uFDFF') ||  // Arabic Presentation Forms-A
                    (c >= '\uFE70' && c <= '\uFEFF'))    // Arabic Presentation Forms-B
                {
                    return true;
                }
            }
            
            return false;
        }

        public void ApplyFontToTextBlock(System.Windows.Controls.TextBlock textBlock)
        {
            var font = GetFontForLanguage(textBlock.Text);
            textBlock.FontFamily = font;
        }

        public void ApplyFontToButton(System.Windows.Controls.Button button)
        {
            var font = GetFontForLanguage(button.Content?.ToString() ?? "");
            button.FontFamily = font;
        }

        public void ApplyFontToLabel(System.Windows.Controls.Label label)
        {
            var font = GetFontForLanguage(label.Content?.ToString() ?? "");
            label.FontFamily = font;
        }
    }
}