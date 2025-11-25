# Quick Start: Creating MizeKar Installer

This guide shows you how to create a professional Windows installer for MizeKar in 5 simple steps.

## What You'll Get

- Professional Windows installer (`.exe` file)
- ~30-35 MB compressed file
- Users can choose installation directory
- Automatic Desktop and Start Menu shortcuts
- Proper uninstaller
- Registered in Windows "Programs & Features"

## Prerequisites

1. **Inno Setup** - Free installer creator
   - Download: https://jrsoftware.org/isinfo.php
   - Install it (takes 1 minute)

## 5 Steps to Create Installer

### Step 1: Build the Release

Open PowerShell in the MizeKar folder and run:

```powershell
dotnet clean
dotnet publish -c Release -r win-x64 --self-contained true
```

This creates all files in: `bin/Release/net8.0-windows/win-x64/publish/`

### Step 2: Open Inno Setup

1. Launch **Inno Setup Compiler** from Start Menu
2. Click **File** → **Open**
3. Select `MizeKar-Setup.iss` from the MizeKar folder

### Step 3: Compile the Installer

1. Click **Build** → **Compile** (or press Ctrl+F9)
2. Wait ~30 seconds while it compiles
3. Done! You'll see "Compile successful"

### Step 4: Find Your Installer

The installer is created in the MizeKar root folder:
- **File**: `MizeKar-Setup-v1.0.0.exe`
- **Size**: ~30-35 MB
- **Ready to distribute!**

### Step 5: Test the Installer

Double-click `MizeKar-Setup-v1.0.0.exe` to test:
1. Choose installation directory
2. Select Desktop shortcut (optional)
3. Click Install
4. Launch MizeKar
5. Test it works!
6. Test uninstall from Control Panel → Programs

## Using Command Line (Optional)

If you prefer command line:

```powershell
# Navigate to MizeKar folder
cd C:\Users\osira\Projects\Mizekar

# Build release
dotnet publish -c Release -r win-x64 --self-contained true

# Compile installer
& "C:\Program Files (x86)\Inno Setup 6\ISCC.exe" MizeKar-Setup.iss

# Done! Installer created: MizeKar-Setup-v1.0.0.exe
```

## Distributing the Installer

### Option 1: GitHub Release (Recommended)

1. Go to: https://github.com/osameh15/Mizekar/releases/new
2. Select tag `v1.0.0`
3. Upload `MizeKar-Setup-v1.0.0.exe`
4. Publish release
5. Users download and run the installer!

### Option 2: Direct Distribution

Simply give users the `MizeKar-Setup-v1.0.0.exe` file:
- Email it
- Upload to file sharing
- Put on USB drive
- Users just run it!

## What the Installer Does

When users run your installer:

1. **Welcome Screen**: Shows app info
2. **License Agreement**: (if you add LICENSE.txt)
3. **Select Destination**: Choose where to install
4. **Select Components**: Choose Desktop/Start Menu shortcuts
5. **Installing**: Copies files, creates shortcuts
6. **Finish**: Option to launch app immediately

## Installer Features

✅ **For Users:**
- No .NET installation needed (self-contained)
- Choose where to install
- Desktop shortcut (optional)
- Start Menu shortcuts
- Easy uninstall from Control Panel
- Proper Windows integration

✅ **For You:**
- Professional looking installer
- One `.exe` file to distribute
- Smaller than ZIP (30 MB vs 75 MB)
- Better user experience
- Tracks installations

## Customizing for Future Versions

### Update Version Number

Edit `MizeKar-Setup.iss` line 6:

```pascal
#define MyAppVersion "1.0.0"  ← Change this
```

Then rebuild the installer.

### Change Default Install Location

Edit `MizeKar-Setup.iss` around line 20:

```pascal
DefaultDirName={autopf}\{#MyAppName}
```

Options:
- `{autopf}` = Program Files
- `{autosd}` = System Drive (C:\)
- `{userdocs}` = User Documents
- Or use absolute path like `C:\MyApp`

### Add Your License

1. Create `LICENSE.txt` in the MizeKar folder
2. Edit `MizeKar-Setup.iss`, add after line 29:

```pascal
LicenseFile=LICENSE.txt
```

Installer will show license agreement screen.

## Troubleshooting

### "Cannot find publish folder"

Make sure you ran:
```powershell
dotnet publish -c Release -r win-x64 --self-contained true
```

### "Inno Setup not found"

Download and install from: https://jrsoftware.org/isinfo.php

### "Access denied" error

Run Inno Setup as Administrator.

### Installer is too large

This is normal for self-contained apps (includes .NET runtime).
30-35 MB is expected and reasonable.

### Want to include Data folder

Edit `MizeKar-Setup.iss`, add to [Files] section:

```pascal
Source: "Data\*"; DestDir: "{app}\Data"; Flags: ignoreversion recursesubdirs
```

## Need Help?

- Full guide: See `docs/DEPLOYMENT_GUIDE.md`
- Inno Setup docs: https://jrsoftware.org/ishelp/
- Support: osirandoust@gmail.com

---

**That's it! You now have a professional Windows installer for MizeKar!** 🎉
