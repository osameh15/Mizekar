@echo off
REM MizeKar - Build and Create Installer Script
REM This script automates the process of building the release and creating the installer

echo ========================================
echo MizeKar Installer Builder
echo ========================================
echo.

REM Check if Inno Setup is installed
set INNO_PATH=C:\Program Files (x86)\Inno Setup 6\ISCC.exe
if not exist "%INNO_PATH%" (
    echo ERROR: Inno Setup not found!
    echo Please install Inno Setup from: https://jrsoftware.org/isinfo.php
    echo.
    pause
    exit /b 1
)

echo Step 1: Cleaning previous builds...
dotnet clean
if errorlevel 1 (
    echo ERROR: Clean failed!
    pause
    exit /b 1
)
echo [OK] Clean completed
echo.

echo Step 2: Publishing release build...
dotnet publish -c Release -r win-x64 --self-contained true
if errorlevel 1 (
    echo ERROR: Publish failed!
    pause
    exit /b 1
)
echo [OK] Publish completed
echo.

echo Step 3: Compiling installer...
"%INNO_PATH%" MizeKar-Setup.iss
if errorlevel 1 (
    echo ERROR: Installer compilation failed!
    pause
    exit /b 1
)
echo [OK] Installer created successfully!
echo.

echo ========================================
echo SUCCESS!
echo ========================================
echo.
echo Installer created: MizeKar-Setup-v1.0.0.exe
echo.
echo Next steps:
echo 1. Test the installer
echo 2. Generate SHA256 checksum (optional)
echo 3. Upload to GitHub releases
echo.

REM Optional: Generate SHA256 checksum
choice /C YN /M "Generate SHA256 checksum"
if errorlevel 2 goto skip_checksum
if errorlevel 1 goto generate_checksum

:generate_checksum
echo.
echo Generating SHA256 checksum...
powershell -Command "Get-FileHash MizeKar-Setup-v1.0.0.exe -Algorithm SHA256 | Select-Object -ExpandProperty Hash" > MizeKar-Setup-v1.0.0.sha256
echo [OK] Checksum saved to: MizeKar-Setup-v1.0.0.sha256
echo.
type MizeKar-Setup-v1.0.0.sha256
echo.

:skip_checksum
echo.
pause
