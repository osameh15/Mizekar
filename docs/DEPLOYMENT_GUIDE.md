# MizeKar Deployment Guide

This guide explains how to build, package, and deploy MizeKar releases.

## Prerequisites

- .NET 8.0 SDK installed
- Git for version control
- Windows PowerShell (for packaging)
- Inno Setup 6.0+ (for creating installer) - Download from https://jrsoftware.org/isinfo.php

## Building a Release

### 1. Clean Previous Builds

```bash
dotnet clean
```

This removes all previous build artifacts to ensure a clean release.

### 2. Publish Self-Contained Executable

```bash
dotnet publish -c Release -r win-x64 --self-contained true
```

**Parameters:**
- `-c Release` - Build in Release configuration (optimized)
- `-r win-x64` - Target Windows 64-bit platform
- `--self-contained true` - Include .NET runtime (no installation required)

**Output Location:**
```
bin/Release/net8.0-windows/win-x64/publish/
```

**What Gets Published:**
- `MizeKar.exe` - Main executable
- `*.dll` - Runtime libraries
- `Assets/` - Images, icons, fonts
- Language packs (cs, de, es, fr, it, ja, ko, etc.)

**Total Size:** ~170 MB (unpacked)

## Creating Windows Installer (Recommended)

### Option 1: Professional Installer with Inno Setup

Create a professional Windows installer that allows users to:
- Choose installation directory
- Create Desktop shortcuts
- Create Start Menu shortcuts
- Uninstall cleanly

#### 1. Install Inno Setup

Download and install from: https://jrsoftware.org/isinfo.php

#### 2. Build Release First

Make sure you've published the release:
```bash
dotnet publish -c Release -r win-x64 --self-contained true
```

#### 3. Compile Installer

**Method 1: Using Inno Setup GUI**
1. Open Inno Setup Compiler
2. Open `MizeKar-Setup.iss` file
3. Click **Build** → **Compile**
4. Installer will be created: `MizeKar-Setup-v1.0.0.exe`

**Method 2: Using Command Line**
```bash
"C:\Program Files (x86)\Inno Setup 6\ISCC.exe" MizeKar-Setup.iss
```

#### 4. Output

**Installer File:**
- `MizeKar-Setup-v1.0.0.exe` (~30-35 MB compressed)

**What the installer does:**
- Installs to `C:\Program Files\MizeKar\` (or user-selected directory)
- Creates Start Menu shortcuts
- Creates Desktop shortcut (optional, user choice)
- Creates uninstaller
- Registers in Windows Programs & Features
- Sets proper permissions

#### 5. Test the Installer

```bash
# Run the installer
MizeKar-Setup-v1.0.0.exe

# Test installation:
# 1. Choose installation directory
# 2. Select Desktop/Start Menu shortcuts
# 3. Complete installation
# 4. Launch application
# 5. Test uninstall from Control Panel
```

### Installer Features

The Inno Setup script (`MizeKar-Setup.iss`) provides:

✅ **User Choices:**
- Installation directory selection
- Desktop shortcut (optional)
- Start Menu shortcuts
- Quick Launch shortcut (Windows 7 and below)

✅ **Professional Features:**
- Modern wizard interface
- English and Persian language support
- Custom application icon
- Proper uninstaller
- Admin privileges handling
- 64-bit architecture detection

✅ **Post-Installation:**
- Option to launch app immediately
- Proper Windows integration
- Clean uninstallation

### Customizing the Installer

Edit `MizeKar-Setup.iss` to customize:

**Change version:**
```pascal
#define MyAppVersion "1.0.0"  // Change this
```

**Change default install directory:**
```pascal
DefaultDirName={autopf}\{#MyAppName}  // {autopf} = Program Files
```

**Add/remove shortcuts:**
```pascal
[Tasks]
Name: "desktopicon"; Description: "Create Desktop Icon";
```

**Change compression:**
```pascal
Compression=lzma2/max  // Maximum compression
```

## Creating Release Package (ZIP - Alternative)

### 1. Create ZIP Archive

```bash
cd bin/Release/net8.0-windows/win-x64/publish/
powershell -Command "Compress-Archive -Path * -DestinationPath ../../../../../MizeKar-Release-v1.0.0.zip -Force"
```

Replace `v1.0.0` with your actual version number.

**Package Size:** ~75 MB (compressed)

### 2. Generate SHA256 Checksum

```bash
powershell -Command "Get-FileHash MizeKar-Release-v1.0.0.zip -Algorithm SHA256 | Select-Object -ExpandProperty Hash" > MizeKar-Release-v1.0.0.sha256
```

**What is SHA256?**

SHA256 is a cryptographic hash function that creates a unique "fingerprint" for your file:
- **Purpose**: Verify file integrity and authenticity
- **How it works**: Any change to the file produces a completely different hash
- **Use case**: Users can verify their download matches your original file

**Example:**
```
File: MizeKar-Release-v1.0.0.zip
SHA256: 7D75F1A4C3B0A95CC4BB265ECB8E81A97E90AA95D87B98479B2D4AE74393FFA7
```

**How Users Verify:**

Windows PowerShell:
```powershell
Get-FileHash MizeKar-Release-v1.0.0.zip -Algorithm SHA256
```

Linux/Mac:
```bash
sha256sum MizeKar-Release-v1.0.0.zip
```

They compare the output with your published SHA256. If they match = file is original and safe ✅

## Version Control & Tagging

### 1. Check Git Status

```bash
git status
```

### 2. Commit Changes (if any)

```bash
git add .
git commit -m "chore: Prepare v1.0.0 release"
```

### 3. Create Annotated Tag

```bash
git tag -a v1.0.0 -m "Release v1.0.0 - Page-Based Navigation Architecture

Major Features:
- Flicker-free navigation using WPF Frame-based architecture
- Single-window design with instant page transitions
- Persian language support with Shabnam font
- Category-based folder organization (9 categories)
- Real-time folder management with file system watcher
- Image display system for chart category
- Custom Persian dialogs and input validation
- Empty state handling
- Fullscreen experience

Technical Highlights:
- .NET 8.0 / WPF / C# 12.0
- Page-based navigation pattern
- Frame control with NavigationService
- Zero navigation flicker or delays
- Optimized performance with page caching"
```

### 4. Push Tag to Remote

```bash
git push origin v1.0.0
```

### 5. Verify Tag on Remote

```bash
git ls-remote --tags origin | grep v1.0.0
```

## Creating GitHub Release

### Option 1: GitHub Web Interface

1. Go to: `https://github.com/YOUR_USERNAME/Mizekar/releases/new`
2. Click "Choose a tag" and select `v1.0.0`
3. Fill in release details:
   - **Release title**: `MizeKar v1.0.0 - Page-Based Navigation`
   - **Description**: Copy from `RELEASE_NOTES.md`
4. Upload release files:
   - `MizeKar-Release-v1.0.0.zip`
   - `MizeKar-Release-v1.0.0.sha256`
5. Check "Set as the latest release"
6. Click "Publish release"

### Option 2: GitHub CLI (gh)

```bash
gh release create v1.0.0 \
  MizeKar-Release-v1.0.0.zip \
  MizeKar-Release-v1.0.0.sha256 \
  --title "MizeKar v1.0.0 - Page-Based Navigation" \
  --notes-file RELEASE_NOTES.md
```

## Release Checklist

Before publishing a release, verify:

- [ ] Version number updated in all relevant files
- [ ] Version updated in `MizeKar-Setup.iss`
- [ ] `RELEASE_NOTES.md` created and updated
- [ ] All tests pass
- [ ] Clean build successful
- [ ] Self-contained publish successful
- [ ] **Installer created** (`MizeKar-Setup-v1.0.0.exe`) - **RECOMMENDED**
- [ ] ZIP package created (alternative/optional)
- [ ] SHA256 checksum generated (for ZIP and/or installer)
- [ ] Installer tested (install, run, uninstall)
- [ ] Git tag created
- [ ] Tag pushed to remote
- [ ] Release files uploaded to GitHub (installer + optional ZIP)
- [ ] Release notes added
- [ ] Release published

## Version Numbering

Follow [Semantic Versioning](https://semver.org/):

- **MAJOR.MINOR.PATCH** (e.g., 1.0.0)
  - **MAJOR**: Breaking changes or major new features
  - **MINOR**: New features, backward compatible
  - **PATCH**: Bug fixes, backward compatible

Examples:
- `v1.0.0` - Initial release
- `v1.1.0` - Added new feature
- `v1.1.1` - Bug fix
- `v2.0.0` - Major redesign with breaking changes

## User Installation Guide

### System Requirements

- **OS**: Windows 10 or later (64-bit)
- **RAM**: 256 MB minimum
- **Disk Space**: 200 MB free space
- **Display**: 1024×768 or higher resolution
- **.NET Runtime**: Not required (self-contained)

### Installation Instructions for Users

**Method 1: Using Installer (Recommended)**
1. Download `MizeKar-Setup-v1.0.0.exe`
2. Run the installer
3. Choose installation directory
4. Select shortcut options (Desktop, Start Menu)
5. Click Install
6. Done! Launch from shortcuts

**Method 2: Using ZIP (Manual)**
1. Download `MizeKar-Release-v1.0.0.zip`
2. (Optional) Verify SHA256 checksum
3. Extract ZIP to any folder (e.g., `C:\Program Files\MizeKar\`)
4. Run `MizeKar.exe`
5. Manually create shortcuts if needed

### First Run

Application will automatically:
- Create `Data` folder
- Create 9 category folders
- Show splash screen (5 seconds)
- Open main interface

## Troubleshooting

### Build Errors

**Issue**: Build fails with errors
```bash
dotnet clean
dotnet restore
dotnet build -c Release
```

**Issue**: Missing assets in publish folder
- Verify `Assets/` folder is included in project file
- Check `.csproj` for `<Content Include="Assets/**/*" CopyToOutputDirectory="PreserveNewest" />`

### Executable Not Running

**Issue**: "MizeKar.exe is not a valid Win32 application"
- Ensure you published for correct platform: `win-x64`
- Don't use `-p:PublishSingleFile=true` (known WPF compatibility issues)

**Issue**: Missing DLL errors
- Use `--self-contained true` to include all dependencies
- Don't use framework-dependent publish

**Issue**: Application won't start
- Verify Windows 10+ and x64 architecture
- Check antivirus isn't blocking execution
- Ensure sufficient disk space

### Deployment Issues

**Issue**: Categories not created
- Check write permissions in application directory
- Run application as administrator (if permission issues)
- Verify `Data` folder creation

**Issue**: Performance issues
- Close other applications if system resources low
- Ensure adequate RAM (4GB+ recommended)

### ZIP Packaging

**Issue**: ZIP too large
- Normal for self-contained apps (~75 MB compressed)
- Includes entire .NET runtime and dependencies
- This is expected behavior

**Issue**: Missing files in ZIP
- Ensure you ZIP from inside the `publish/` folder
- Use wildcard `*` to include all files: `Compress-Archive -Path *`

## Advanced: Framework-Dependent Build

If you want a smaller package and users have .NET 8.0 installed:

```bash
dotnet publish -c Release -r win-x64 --self-contained false
```

**Advantages:**
- Much smaller package (~5 MB)

**Disadvantages:**
- Users must install .NET 8.0 runtime
- Less convenient for end users

**Recommendation:** Use self-contained for better user experience.

## Files Generated

After completing the deployment process, you'll have:

```
MizeKar/
├── MizeKar-Setup-v1.0.0.exe          # Windows installer (30-35 MB) ✨ RECOMMENDED
├── MizeKar-Setup-v1.0.0.sha256       # Installer checksum (optional)
├── MizeKar-Release-v1.0.0.zip        # ZIP package (75 MB) - Alternative
├── MizeKar-Release-v1.0.0.sha256     # ZIP checksum (optional)
├── MizeKar-Setup.iss                 # Installer script
├── RELEASE_NOTES.md                  # Release documentation
└── bin/Release/net8.0-windows/win-x64/publish/  # Published files (170 MB)
```

**Recommended for GitHub Release:**
- `MizeKar-Setup-v1.0.0.exe` - Primary distribution method
- `MizeKar-Release-v1.0.0.zip` - Alternative for advanced users

## Performance Notes

- **First Run**: May take 2-3 seconds to initialize categories
- **Subsequent Runs**: Instant startup
- **Memory Usage**: ~50-100MB typical
- **Storage**: Application + Data typically < 200MB

## Security Considerations

- **Local Data**: All data stored locally in `Data` folder
- **No Network**: Application operates offline
- **File Permissions**: Uses standard Windows file permissions
- **No Sensitive Data**: Only folder names and images stored
- **SHA256 Verification**: Ensures download integrity

## Support & Contact

For deployment issues or questions:
- **Email**: osirandoust@gmail.com
- **Telegram**: https://t.me/osameh_ir
- **GitHub Issues**: https://github.com/osameh15/Mizekar/issues

---

**Last Updated**: November 25, 2025 - Version 1.0.0