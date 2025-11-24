# MizeKar Project Guidelines

## Project Structure
- Main application: WPF/.NET 8.0 Windows desktop application
- Navigation: Single-window Frame-based architecture with Pages
- Source code in root directory with organized folders:
  - `Pages/` - Navigation pages (Frame-based WPF Pages)
  - `Views/` - Dialogs and modal windows
  - `Models/` - Data models
  - `Services/` - Business logic and file system operations
- Main window: `MainWindow.xaml` - Single container window with Frame
- Documentation in `docs/` directory
- Images and assets in `Assets/` directory

## Build/Test Commands
- **Build:** `dotnet build`
- **Run:** `dotnet run`
- **Clean:** `dotnet clean`
- **Publish:** `dotnet publish -c Release -r win-x64 --self-contained`

## Code Style Guidelines
- Use C# 12.0 features with nullable reference types enabled
- Follow Page-based navigation pattern for WPF applications
- Use WPF built-in NavigationService for page transitions
- Use descriptive names with proper casing:
  - Classes: PascalCase
  - Methods: PascalCase
  - Variables: camelCase
  - Constants: PascalCase
- Use dependency injection for services
- Separate UI logic from business logic
- Pages should use `NavigationService?.Navigate()` for navigation
- Pages should use `NavigationService?.GoBack()` for back navigation

## Technology Stack
- **Framework:** .NET 8.0
- **UI:** WPF (Windows Presentation Foundation)
- **Platform:** Windows desktop
- **Language:** C# 12.0

## Key Features Implemented
- Fullscreen window management with single-window Frame architecture
- Flicker-free page navigation using WPF NavigationService
- Persian language support (UTF-8) with Shabnam font
- File system watcher for real-time updates
- Folder creation, deletion, and management
- Splash page with automatic transition (5 seconds)
- Page-based navigation with instant transitions
- Dialog-based modal interactions
- Font management system with automatic Persian text detection
- Empty state messages for categories with no folders
- Automatic category folder creation on application startup

## General Development Guidelines
- Use descriptive file and directory names
- Document major features in the docs directory
- Follow WPF/XAML conventions
- Maintain consistent naming conventions across the project
- Use proper error handling and user feedback

## Architecture Notes
- Application name: MizeKar
- Root namespace: MizeKar
- Main namespace for Pages: MizeKar.Pages
- Navigation pattern: Single MainWindow with Frame containing Pages
- Data folder: "Data" (created automatically)
- Supports Persian folder names and UI elements
- Splash duration: 5000ms (5 seconds)

## Navigation Implementation
- All navigation screens are WPF Pages (not Windows)
- Main container: `MainWindow.xaml` with Frame control
- Page navigation: Use `NavigationService?.Navigate(new PageName())`
- Back navigation: Use `NavigationService?.GoBack()`
- Dialog windows: Use traditional Window.ShowDialog() for modal dialogs
- Navigation is instant with zero flicker or screen flash