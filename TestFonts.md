# Font Testing Instructions

To test if the Shabnam fonts are working correctly in the MizeKar application:

## 1. Visual Test
- Run the application: `dotnet run`
- Observe the splash screen text "مدیریت پوشه‌ها" - it should display in Shabnam font
- Check the main screen buttons with Persian text: "ورود", "درباره ما", "ارتباط با ما"

## 2. Font Fallback Test
- If Shabnam is not available, the application should fall back to Tahoma
- You can verify this by checking the font rendering quality

## 3. Folder Creation Test
- Navigate to the folder management screen
- Create a folder with Persian name like "پوشه آزمایشی"
- The folder name should display correctly in the UI

## 4. Debug Output
- Check the debug output in Visual Studio or console for font loading messages
- Look for messages like "Using Persian font: Shabnam"

## Troubleshooting
- If fonts don't display correctly, ensure the Shabnam font files are properly embedded
- Check that the project file includes the font resources correctly
- Verify that the App.xaml styles are applying the Shabnam font family