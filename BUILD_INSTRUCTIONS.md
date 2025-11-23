# MizeKar - Build and Run Instructions

## Prerequisites
- Windows 10 or later
- .NET 6.0 SDK or later
- Visual Studio 2022 or Visual Studio Code (recommended)

## Building the Application

### Using Visual Studio
1. Open `FullscreenFolderManager.sln` in Visual Studio
2. Build the solution (Ctrl+Shift+B)
3. Run the application (F5)

### Using Command Line
```bash
# Navigate to the project directory
cd MizeKar

# Restore dependencies
dotnet restore

# Build the application
dotnet build

# Run the application
dotnet run
```

### Creating a Release Build
```bash
# Create release build
dotnet build -c Release

# Publish as self-contained executable
dotnet publish -c Release -r win-x64 --self-contained
```

## Application Features

### Splash Screen
- Displays for exactly 2 seconds
- Shows "MizeKar" app name in both English and Persian
- Automatically transitions to main screen

### Main Screen
- Fullscreen window with no title bar or borders
- Navigation buttons in Persian:
  - ورود (Login) - Opens folder management screen
  - درباره ما (About Us) - Shows app information
  - ارتباط با ما (Contact Us) - Shows contact information
  - خروج (Exit) - Closes the application

### Folder Management
- Creates and uses a "Data" folder in the application directory
- Supports Persian folder names with UTF-8 encoding
- Real-time updates when folders are added/deleted
- Folder operations:
  - Create new folders with Persian names
  - Delete folders with confirmation
  - Open folders in Windows Explorer

## File Structure
```
MizeKar/
├── App.xaml/.cs              # Application entry point and configuration
├── Views/
│   ├── SplashScreen.xaml/.cs # 2-second splash screen
│   ├── MainScreen.xaml/.cs   # Main navigation screen
│   ├── FolderManagementScreen.xaml/.cs # Folder management interface
│   ├── AboutUsDialog.xaml/.cs # About information dialog
│   ├── ContactUsDialog.xaml/.cs # Contact information dialog
│   └── CreateFolderDialog.xaml/.cs # Folder creation dialog
├── Models/
│   └── FolderInfo.cs         # Folder data model
├── Services/
│   └── FolderService.cs      # File system operations and watcher
└── Data/                     # Created automatically - contains user folders
```

## Configuration
Key configuration constants in `App.xaml.cs`:
- `DATA_FOLDER_NAME = "Data"` - Root data folder name
- `SPLASH_SCREEN_DURATION_MS = 2000` - Splash screen duration

## Keyboard Shortcuts
- `Escape` - Go back to previous screen
- `Ctrl+N` - Create new folder
- `Enter` - Confirm dialog actions

## Testing
Test the following features:
1. Fullscreen behavior on different screen resolutions
2. Persian folder name creation and display
3. Real-time folder updates (add/delete folders externally)
4. Folder operations (create, delete, open in Explorer)
5. Splash screen timing and transitions

## Troubleshooting
- Ensure .NET 6.0+ is installed
- Check file permissions for Data folder operations
- Verify Persian font support in Windows
- For build errors, try cleaning and rebuilding the solution