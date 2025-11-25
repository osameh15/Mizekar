# MizeKar v1.1.0 Release Notes

## Release Information

- **Version**: 1.1.0
- **Release Date**: November 25, 2025
- **Platform**: Windows 10/11 (64-bit)
- **Package Size**: ~56 MB (installer) / ~71 MB (portable)

## What's Included

This release package contains:
- `MizeKar-Setup-v1.1.0.exe` - Windows Installer (Recommended)
- `MizeKar-Release-v1.1.0.zip` - Portable ZIP package

## Installation

### Option 1: Installer (Recommended)
1. Run `MizeKar-Setup-v1.1.0.exe`
2. Select installation directory
3. Choose shortcut options (Desktop/Start Menu)
4. Click Install

### Option 2: Portable
1. Extract `MizeKar-Release-v1.1.0.zip` to any folder
2. Run `MizeKar.exe`
3. No installation or .NET runtime required!

## What's New in v1.1.0

### UI Enhancements
- **Exit Confirmation Dialog** - Safety confirmation dialog when clicking exit button on all pages
- **Colorized Categories** - Each of the 9 categories now has a unique color with 70% opacity
- **Watermark Logo** - Subtle logo watermark (30% opacity) on content pages for branding
- **Minimize Button** - Window minimize functionality (کوچک کردن) added to all pages

### Navigation Improvements
- **Home Button** - Now navigates directly to MainPage
- **Categories Button** - Now navigates directly to CategoryPage
- **Category Order** - Categories display in predefined order (consistent across sessions)

### Installer & Storage
- **Windows Installer** - Professional Inno Setup installer with:
  - User-selectable installation directory
  - Desktop and Start Menu shortcuts
  - Proper uninstaller
- **Data Storage** - Application data stored in `%APPDATA%\MizeKar\Data` (no admin required)

### Input Validation
- **Space Character** - Added space character support in folder names

## Features

### Navigation & UI
- **Flicker-Free Navigation** - Smooth, instant page transitions with zero screen flashing
- **Fullscreen Experience** - Immersive fullscreen interface
- **Persian Language Support** - Complete RTL support with Shabnam font
- **Modern UI** - Clean, professional interface with custom dialogs
- **Colorful Categories** - Each category has a unique color for visual distinction

### Folder Management
- **Category-Based Organization** - 9 pre-defined categories in 3×3 grid layout
- **Real-Time Updates** - File system watcher monitors changes automatically
- **Persian Input Validation** - Persian characters, numbers, spaces, hyphens, and underscores allowed
- **Empty State Handling** - Clear messages when categories are empty
- **Windows Explorer Integration** - Open folders directly in Explorer

### Special Features
- **Image Display System** - Chart category displays images with upload capability
- **Fullscreen Image Viewer** - Click images to view fullscreen
- **Custom Dialogs** - Professional Persian-styled dialogs for all interactions
- **Exit Confirmation** - Prevents accidental application closure with confirmation dialog
- **Keyboard Shortcuts**:
  - `Escape` - Go back
  - `Ctrl+N` - Create new folder
  - `Enter` - Confirm actions

## System Requirements

- **OS**: Windows 10 or later (64-bit)
- **RAM**: 256 MB minimum
- **Disk Space**: 200 MB free space
- **Display**: 1024×768 or higher resolution

## Known Issues

None reported in this release.

## Technical Details

- **Framework**: .NET 8.0 (self-contained, no installation required)
- **Architecture**: Single-window Frame-based navigation
- **Language**: C# 12.0
- **UI Framework**: WPF (Windows Presentation Foundation)
- **Installer**: Inno Setup 6

## Support

For issues, questions, or feedback:
- **Email**: osirandoust@gmail.com
- **Telegram**: https://t.me/osameh_ir
- **GitHub**: https://github.com/osameh15/Mizekar

## License

This project is licensed under the MIT License.

---

**MizeKar** - مدیریت آسان پوشه‌ها با پشتیبانی فارسی
