# MizeKar - Release v1.0.0

## 📋 Release Information
- **Version**: 1.0.0
- **Release Date**: $(date)
- **Platform**: Windows x64
- **Framework**: .NET 8.0 (Self-Contained)

## 🚀 Features

### Core Features
- Fullscreen Persian folder management application
- 9 pre-defined categories with automatic setup
- Right-to-left (RTL) Persian interface
- Image display system for chart category
- Real-time folder monitoring
- Custom Persian-styled dialogs

### Category System
1. آموزشی (Educational)
2. پرورشی (Developmental)
3. انجمن اولیاء (Parents Association)
4. یادواره شهداء (Martyrs Memorial)
5. چارت عوامل اجرایی، آموزشی و پرورشی (Chart Display)
6. ورزش (Sports)
7. بهداشت (Health)
8. مشاوره (Counseling)
9. سایر (Other)

### Technical Features
- Automatic category folder creation on first run
- Persian input validation with visual feedback
- Empty state messages for user guidance
- Custom application icon
- Fullscreen window management
- Keyboard shortcuts support

## 📦 Installation

### System Requirements
- **OS**: Windows 10 or later
- **Architecture**: x64
- **No Dependencies**: Self-contained application

### Quick Start
1. Extract the release files to your desired location
2. Run `MizeKar.exe`
3. The application will automatically create the Data folder and categories
4. Use the interface to manage folders within categories

## 🎯 Usage

### Navigation
- **Login Button**: Access category selection
- **Category Selection**: 3x3 grid layout
- **Folder Management**: Create, delete, and view folders
- **Image Display**: Special handling for chart category
- **Keyboard Shortcuts**: 
  - `Escape`: Go back
  - `Ctrl+N`: Create new folder

### Folder Operations
- **Create**: Persian-only folder names with validation
- **Delete**: Confirmation dialog for safety
- **View**: Open folders in Windows Explorer
- **Refresh**: Manual folder list updates

## 🔧 Technical Details

### Build Information
- **Framework**: .NET 8.0
- **UI**: WPF (Windows Presentation Foundation)
- **Language**: C# 12.0
- **Architecture**: x64
- **Self-Contained**: No .NET runtime required

### File Structure
```
Release/
├── MizeKar.exe          # Main executable
├── Assets/              # Application assets
│   ├── images/          # Background images
│   ├── icons/           # UI icons
│   └── logo.ico         # Application icon
├── Data/                # Created automatically
│   └── [9 Categories]   # Category folders
└── [Runtime Files]      # .NET runtime components
```

## 📞 Support

For support and questions:
- Email: osirandoust@gmail.com
- Contact: [Telegram](https://t.me/osameh_ir)

## 📄 License

This project is licensed under the MIT License.

---
**MizeKar** - مدیریت آسان پوشه‌ها با پشتیبانی فارسی