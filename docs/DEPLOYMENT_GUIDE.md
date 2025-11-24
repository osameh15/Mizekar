# MizeKar - Deployment Guide

## 🚀 Quick Deployment

### Option 1: Ready-to-Run Package
1. Download `MizeKar-Release-v1.0.0.zip`
2. Extract to desired location
3. Run `MizeKar.exe`

### Option 2: Build from Source
```bash
# Clone or download source code
git clone [repository-url]
cd MizeKar

# Build release version
dotnet build -c Release

# Create self-contained package
dotnet publish -c Release -r win-x64 --self-contained
```

## 📋 System Requirements

- **Operating System**: Windows 10 or later
- **Architecture**: x64 (64-bit)
- **Storage**: ~100MB free space
- **No Additional Dependencies**: Self-contained .NET 8.0 application

## 🔧 Installation Steps

### Step 1: Extract Files
```
Extract MizeKar-Release-v1.0.0.zip to:
C:\Program Files\MizeKar\  (recommended)
OR
Any user-accessible directory
```

### Step 2: First Run
1. Double-click `MizeKar.exe`
2. Application will automatically:
   - Create `Data` folder
   - Create 9 category folders
   - Show splash screen
   - Open main interface

### Step 3: Verify Installation
- Check that `Data` folder exists with 9 subfolders
- Test navigation between screens
- Create test folders in categories

## 🎯 User Onboarding

### For End Users
1. **Launch Application**: Run `MizeKar.exe`
2. **Navigate**: Click "ورود" (Login) to access categories
3. **Select Category**: Choose from 3x3 grid
4. **Manage Folders**: Create, view, or delete folders
5. **Special Features**: 
   - Chart category for image display
   - Persian-only folder names
   - Real-time folder monitoring

### For Administrators
1. **Deploy**: Copy release folder to target machines
2. **Permissions**: Ensure write access to application directory
3. **Backup**: Regularly backup the `Data` folder
4. **Updates**: Replace entire release folder for updates

## 📊 Performance Notes

- **First Run**: May take 2-3 seconds to initialize categories
- **Subsequent Runs**: Instant startup
- **Memory Usage**: ~50-100MB typical
- **Storage**: Application + Data typically < 50MB

## 🔒 Security Considerations

- **Local Data**: All data stored locally in `Data` folder
- **No Network**: Application operates offline
- **File Permissions**: Uses standard Windows file permissions
- **No Sensitive Data**: Only folder names and images stored

## 🛠️ Troubleshooting

### Common Issues

**Application Won't Start**
- Verify Windows 10+ and x64 architecture
- Check antivirus isn't blocking execution
- Ensure sufficient disk space

**Categories Not Created**
- Check write permissions in application directory
- Run application as administrator (if permission issues)
- Verify `Data` folder creation

**Performance Issues**
- Close other applications if system resources low
- Ensure adequate RAM (4GB+ recommended)

### Logs and Diagnostics
- Check Windows Event Viewer for .NET errors
- Application creates debug output in console (if launched from command line)

## 📞 Support

For deployment assistance:
- Email: osirandoust@gmail.com
- Contact: [Telegram](https://t.me/osameh_ir)

---
**MizeKar** - Ready for Deployment