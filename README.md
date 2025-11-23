# MizeKar - Fullscreen Windows Folder Manager

A modern, fullscreen Windows desktop application for managing folder structures with Persian language support.

## 🚀 Features

- **Fullscreen Experience** - True fullscreen window with no title bars or borders
- **Persian Language Support** - Full UTF-8 support for Persian folder names and UI elements with Shabnam font
- **Dynamic Folder Management** - Real-time updates when folders are added or deleted
- **Intuitive Interface** - Clean, modern UI with smooth navigation
- **File System Integration** - Direct integration with Windows Explorer

## 📸 Screenshots

### Splash Screen
- Displays for 2 seconds with app branding
- Automatic transition to main screen

### Main Screen
- Fullscreen navigation with Persian/English options
- Login, About Us, Contact Us, and Exit buttons

### Folder Management
- Dynamic display of folder structure
- Create, delete, and open folders
- Real-time updates with file system watcher

## 🛠️ Technology Stack

- **Framework**: .NET 8.0
- **UI**: WPF (Windows Presentation Foundation)
- **Platform**: Windows Desktop
- **Language**: C# 12.0

## 📁 Project Structure

```
MizeKar/
├── Views/                 # XAML windows and dialogs
│   ├── SplashScreen.xaml  # 2-second splash screen
│   ├── MainScreen.xaml    # Main navigation screen
│   ├── FolderManagementScreen.xaml  # Folder management interface
│   ├── AboutUsDialog.xaml # About information dialog
│   ├── ContactUsDialog.xaml # Contact information dialog
│   └── CreateFolderDialog.xaml # Folder creation dialog
├── Models/                # Data models
│   └── FolderInfo.cs      # Folder data model
├── Services/              # Business logic
│   ├── FolderService.cs   # File system operations and watcher
│   └── FontManager.cs     # Font management and Persian text support
├── Assets/                # Application assets
│   └── fonts/             # Font files
│       └── Shabnam/       # Shabnam Persian font family
├── App.xaml               # Application entry point
├── MizeKar.csproj         # Project configuration
└── MizeKar.sln            # Solution file
```

## 🚀 Getting Started

### Prerequisites
- Windows 10 or later
- .NET 8.0 SDK or later
- Visual Studio 2022 or Visual Studio Code (recommended)

### Building the Application

#### Using Visual Studio
1. Open `MizeKar.sln` in Visual Studio
2. Build the solution (Ctrl+Shift+B)
3. Run the application (F5)

#### Using Command Line
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

## 📋 Usage

### Splash Screen
- Application starts with a 2-second splash screen
- Automatically transitions to main screen

### Main Navigation
- **ورود (Login)** - Opens folder management screen
- **درباره ما (About Us)** - Shows application information
- **ارتباط با ما (Contact Us)** - Shows contact information
- **خروج (Exit)** - Closes the application

### Folder Management
- **Data Folder**: Application creates a "Data" folder in the application directory
- **Persian Support**: Full support for Persian folder names using UTF-8 encoding
- **Real-time Updates**: UI updates immediately when folders are added or deleted
- **Folder Operations**:
  - Create new folders with Persian names
  - Delete folders with confirmation dialog
  - Open folders in Windows Explorer

### Keyboard Shortcuts
- `Escape` - Go back to previous screen
- `Ctrl+N` - Create new folder
- `Enter` - Confirm dialog actions

## 🔧 Configuration

Key configuration constants in `App.xaml.cs`:
- `DATA_FOLDER_NAME = "Data"` - Root data folder name
- `SPLASH_SCREEN_DURATION_MS = 2000` - Splash screen duration

## 🧪 Testing

Test the following features:
1. **Fullscreen behavior** on different screen resolutions
2. **Persian folder name** creation and display
3. **Real-time folder updates** (add/delete folders externally)
4. **Folder operations** (create, delete, open in Explorer)
5. **Splash screen timing** and transitions

## 🐛 Troubleshooting

- **Build errors**: Ensure .NET 8.0+ is installed
- **File permissions**: Check permissions for Data folder operations
- **Persian fonts**: Verify Persian font support in Windows
- **Clean build**: Try `dotnet clean` then `dotnet build`

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🤝 Contributing

1. Fork the project
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📞 Support

For support and questions:
- Email: support@mizekar.com
- Website: www.mizekar.com

## 🗂️ Related Projects

- [Project Documentation](./docs/)
- [Build Instructions](./BUILD_INSTRUCTIONS.md)

---

**MizeKar** - مدیریت آسان پوشه‌ها با پشتیبانی فارسی