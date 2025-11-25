# MizeKar - Fullscreen Windows Folder Manager

A modern, fullscreen Windows desktop application for managing folder structures with Persian language support, category-based organization, and image display capabilities.

## 🚀 Features

- **Fullscreen Experience** - True fullscreen window with no title bars or borders
- **Smooth Page Navigation** - Flicker-free navigation using WPF Frame-based architecture
- **Persian Language Support** - Full UTF-8 support for Persian folder names and UI elements with Shabnam font
- **Category-Based Organization** - 9 main categories in 3x3 grid layout with colorful backgrounds
- **Colorized Categories** - Each category has a unique color with 70% opacity for visual distinction
- **Watermark Logo** - Subtle logo watermark on content pages for branding
- **Minimize Button** - Window minimize functionality on all pages
- **Dynamic Folder Management** - Real-time updates when folders are added or deleted
- **Input Validation** - Persian-only input with visual feedback for invalid characters
- **Custom Dialogs** - Professional Persian-styled dialogs for all user interactions
- **Exit Confirmation** - Safety confirmation dialog prevents accidental application closure
- **Intuitive Interface** - Clean, modern UI with instant page transitions
- **File System Integration** - Direct integration with Windows Explorer
- **Image Display System** - Special category for displaying and uploading chart images
- **Empty State Handling** - User-friendly messages when categories have no folders
- **Custom Application Icon** - Professional icon for Windows integration
- **Windows Installer** - Professional Inno Setup installer with desktop/start menu shortcuts

## 📸 Screenshots

### Application Flow

| Screen | Description | Screenshot |
|--------|-------------|------------|
| **Splash Screen** | Displays for 5 seconds with app branding<br>Automatic transition to main screen | ![Splash Screen](./docs/Screenshots/splash-screen.png) |
| **Main Screen** | Fullscreen navigation with Persian/English options<br>Login, About Us, Contact Us, and Exit buttons | ![Main Screen](./docs/Screenshots/main.png) |
| **Category Screen** | 3x3 grid layout with 9 main categories<br>Category selection for organized folder management | ![Category Screen](./docs/Screenshots/category.png) |
| **Folder Management** | 4-row optimized display with RTL alignment<br>Category-specific folders with real-time updates | ![Folder Management](./docs/Screenshots/folders.png) |
| **Empty State** | User-friendly message when no folders exist<br>Clear guidance to create first folder | ![Empty Folders](./docs/Screenshots/empty-folders.png) |
| **Image Display** | Chart category with image upload capability<br>Fullscreen viewer for uploaded images | ![Chart Display](./docs/Screenshots/charts.png) |

### Dialog Examples

| Dialog Type | Description | Screenshot |
|-------------|-------------|------------|
| **Create Folder** | Persian input validation with visual feedback<br>Real-time character validation | ![Create Folder](./docs/Screenshots/add-folder.png) |
| **Delete Confirmation** | Safety confirmation for folder deletion<br>Clear information about folder being deleted | ![Delete Folder](./docs/Screenshots/remove-folder.png) |
| **About Us** | Application information and features<br>Professional Persian-styled interface | ![About Us](./docs/Screenshots/about-us.png) |
| **Contact Us** | Support information and contact details<br>Clean, readable design | ![Contact Us](./docs/Screenshots/contact-us.png) |
| **Error Handling** | User-friendly error messages in Persian<br>Consistent with application theme | ![Error Dialog](./docs/Screenshots/error-1.png) |
| **Error Handling 2** | Duplicate folder name error<br>Clear guidance for user | ![Error Dialog 2](./docs/Screenshots/error-2.png) |
| **Exit Confirmation** | Safety confirmation for application exit<br>Prevents accidental closure | ![Exit Dialog](./docs/Screenshots/exit-dialog.png) |
| **Image Upload** | File selection dialog for chart images<br>Real-time status updates | ![Upload Chart](./docs/Screenshots/upload-chart.png) |
| **Input Validation** | Real-time character validation<br>Visual indicators for valid/invalid input | ![Name Validation](./docs/Screenshots/validate-name.png) |


## 🛠️ Technology Stack

- **Framework**: .NET 8.0
- **UI**: WPF (Windows Presentation Foundation)
- **Platform**: Windows Desktop
- **Language**: C# 12.0

## 📁 Project Structure

```
MizeKar/
├── Pages/                 # Navigation pages (Frame-based)
│   ├── SplashPage.xaml    # 5-second splash page
│   ├── MainPage.xaml      # Main navigation page
│   ├── CategoryPage.xaml  # Category selection page (3x3 grid)
│   ├── FolderManagementPage.xaml  # Folder management page
│   └── ImageDisplayPage.xaml # Image display for chart category
├── Views/                 # Dialogs and windows
│   ├── AboutUsDialog.xaml # About information dialog
│   ├── ContactUsDialog.xaml # Contact information dialog
│   ├── CreateFolderDialog.xaml # Folder creation dialog
│   ├── DeleteConfirmDialog.xaml # Folder deletion confirmation
│   ├── ExitConfirmDialog.xaml # Application exit confirmation
│   ├── ErrorDialog.xaml   # Error message display
│   └── ImageFullscreenWindow.xaml # Fullscreen image viewer
├── Models/                # Data models
│   └── FolderInfo.cs      # Folder data model
├── Services/              # Business logic
│   ├── FolderService.cs   # File system operations and watcher
│   └── FontManager.cs     # Font management and Persian text support
├── Assets/                # Application assets
│   ├── fonts/             # Font files
│   │   └── Shabnam/       # Shabnam Persian font family
│   ├── images/            # Background images
│   │   ├── background.png # Main application background
│   │   ├── splash.png     # Splash page background
│   │   ├── dialog-background.jpg # Dialog window background
│   │   └── chart.png      # Default chart image for display
│   └── icons/             # Application icons
│       ├── about-us.png, add-folder.png, close.png, confirm.png
│       ├── contact-us.png, enter.png, exit.png, home.png
│       ├── remove.png, setting.png, stat.png, view.png
│       ├── refresh.png, categories.png, minimize.png
│   └── logo.ico           # Application icon for Windows
├── docs/                  # Documentation and resources
│   ├── BUILD_INSTRUCTIONS.md  # Detailed build instructions
│   ├── CRUSh.md           # Project guidelines and structure
│   └── Screenshots/       # Application screenshots
│       ├── splash-screen.png, main.png, category.png
│       ├── folders.png, empty-folders.png, charts.png
│       ├── add-folder.png, remove-folder.png, upload-chart.png
│       ├── about-us.png, contact-us.png, exit-dialog.png
│       ├── error-1.png, error-2.png
│       └── validate-name.png
├── MainWindow.xaml        # Main application window with Frame
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

- Application starts with a 5-second splash screen
- Automatically transitions to main page with smooth animation

### Main Navigation

- **خروج (Exit)** - Shows confirmation dialog before closing the application
- **کوچک کردن (Minimize)** - Minimizes the window to taskbar
- **ورود (Login)** - Opens category selection screen
- **درباره ما (About Us)** - Shows application information
- **ارتباط با ما (Contact Us)** - Shows contact information

### Category Selection

- **9 Main Categories** - Pre-defined categories in 3x3 grid layout with unique colors
- **Colorful Design** - Each category has a distinct color with 70% opacity
- **Watermark Logo** - Subtle branding watermark visible behind categories
- **Category Access** - Click any category to manage its folders
- **Structured Hierarchy** - All folders are organized under categories
- **Predefined Order** - Categories always display in consistent order

### Folder Management

- **Data Folder**: Application creates a "Data" folder in `%APPDATA%\MizeKar\Data`
- **Category-Based**: Folders are created within selected categories only
- **Automatic Setup**: 9 main categories are automatically created on first run
- **Persian Support**: Full support for Persian folder names using UTF-8 encoding
- **Input Validation**: Only Persian characters, numbers, hyphen (-), underscore (_), and space allowed
- **Real-time Updates**: UI updates immediately when folders are added or deleted
- **Empty State Messages**: Clear "پوشه‌ای وجود ندارد. یک پوشه ایجاد کنید" message when no folders exist
- **Folder Operations**:
  - Create new folders with validated Persian names
  - Delete folders with custom confirmation dialog
  - Open folders in Windows Explorer
  - Manual refresh with refresh button

### Image Display System

- **Chart Category**: "چارت عوامل اجرایی، آموزشی و پرورشی" category displays images instead of folders
- **Image Upload**: Click "آپلود تصویر" to upload and replace chart images
- **Fullscreen Viewer**: Click displayed image to view in fullscreen mode
- **Default Chart**: Pre-loaded default chart.png for immediate display
- **Status Updates**: Real-time status messages for image operations

### Keyboard Shortcuts

- `Escape` - Go back to previous screen
- `Ctrl+N` - Create new folder
- `Enter` - Confirm dialog actions
- **Dialog Navigation**: Enter to confirm, Escape to cancel in all dialogs

## 🔧 Configuration

Key configuration constants in `App.xaml.cs`:

- `DATA_FOLDER_NAME = "Data"` - Root data folder name
- `SPLASH_SCREEN_DURATION_MS = 5000` - Splash screen duration (5 seconds)
- `Categories` - Array defining the 9 main categories in display order
- `DataFolderPath` - Returns `%APPDATA%\MizeKar\Data` for user-writable storage

## 🧪 Testing

Test the following features:

1. **Fullscreen behavior** on different screen resolutions
2. **Category navigation** - flow from Main → Categories → Folder Management
3. **Persian folder name** creation with input validation
4. **Input validation** - try typing English characters (should be blocked with visual feedback)
5. **Custom dialogs** - create, delete, and error dialogs
6. **Real-time folder updates** (add/delete folders externally)
7. **Folder operations** (create, delete, open in Explorer)
8. **Manual refresh** - use refresh button to reload folder list
9. **Splash screen timing** and transitions
10. **Right-to-left alignment** in folder management screen
11. **Empty state messages** - verify message appears when categories have no folders
12. **Image display system** - test chart category image upload and fullscreen viewing
13. **Application icon** - verify custom icon appears in Windows taskbar and file explorer

## 🐛 Troubleshooting

- **Build errors**: Ensure .NET 8.0+ is installed
- **File permissions**: Check permissions for Data folder operations
- **Persian fonts**: Verify Persian font support in Windows
- **Clean build**: Try `dotnet clean` then `dotnet build`
- **Input issues**: Only Persian characters, numbers, - and _ are allowed for folder names
- **Animation stuck**: Rapid typing may cause visual feedback to remain - fixed in latest version
- **Image loading**: If chart image doesn't load, rebuild project to ensure assets are copied
- **Icon not showing**: Verify `logo.ico` is included in Assets directory and project file

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

- Email: osirandoust@gmail.com
- Contact Us: [Telegram](https://t.me/osameh_ir)

## 🔄 Recent Updates

### Version 1.1.0 - UI Enhancements & Installer

- **Exit Confirmation Dialog**: Safety confirmation dialog when clicking exit button on all pages
- **Colorized Categories**: Each of the 9 categories now has a unique color with 70% opacity
- **Watermark Logo**: Subtle logo watermark (30% opacity) on Category, Folder Management, and Image Display pages
- **Minimize Button**: Added window minimize functionality to all pages (کوچک کردن)
- **Improved Navigation**: Home button navigates to MainPage, Categories button navigates to CategoryPage
- **Category Order**: Categories now display in predefined order (not by creation time)
- **Windows Installer**: Professional Inno Setup installer with:
  - User-selectable installation directory
  - Desktop and Start Menu shortcuts
  - Proper uninstaller
- **Data Storage**: Application data stored in `%APPDATA%\MizeKar\Data` for proper permissions

### Version 1.0.0 - Initial Release

- **Page-Based Navigation**: Flicker-free navigation using WPF Frame-based architecture
- **Single Window Design**: One main window with Page navigation for zero screen flashing
- **Instant Transitions**: Smooth, instant page transitions with no desktop background showing
- **Image Display System**: Special chart category for image upload and display
- **Empty State Handling**: User-friendly messages for categories with no folders
- **Custom Application Icon**: Professional icon for Windows integration
- **Fullscreen Image Viewer**: Click images to view in fullscreen mode
- **Category-Based Organization**: 9 main categories in 3x3 grid layout
- **Custom Persian Dialogs**: Professional dialogs for all user interactions
- **Input Validation**: Persian-only input with visual feedback
- **Right-to-Left Layout**: Natural Persian reading direction
- **Manual Refresh**: Refresh button for immediate updates

### Technical Features

- **Page-Based Architecture**: Modern WPF navigation pattern using Frame and Page
- **File System Watcher**: Category-specific monitoring
- **Animation System**: Smooth visual feedback for user actions
- **Error Handling**: Comprehensive error management with custom dialogs
- **Input Security**: Protected against invalid character input
- **Asset Deployment**: Automatic copying of all assets to output directory

## 🗂️ Related Projects

- [Project Documentation](./docs/)
- [Build Instructions](./docs/BUILD_INSTRUCTIONS.md)
- [Application Screenshots](./docs/Screenshots/)

---

**MizeKar** - مدیریت آسان پوشه‌ها با پشتیبانی فارسی
