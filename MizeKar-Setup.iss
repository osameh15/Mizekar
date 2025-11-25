; MizeKar Inno Setup Script
; This script creates a Windows installer for MizeKar application
; Requires Inno Setup 6.0 or later: https://jrsoftware.org/isinfo.php

#define MyAppName "MizeKar"
#define MyAppVersion "1.1.0"
#define MyAppPublisher "Eagle Team"
#define MyAppURL "https://github.com/osameh15/Mizekar"
#define MyAppExeName "MizeKar.exe"
#define MyAppSupportURL "https://t.me/osameh_ir"

[Setup]
; Application information
AppId={{A8B9C0D1-E2F3-4567-8901-234567890ABC}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppSupportURL}
AppUpdatesURL={#MyAppURL}
AppCopyright=Copyright (C) 2025 {#MyAppPublisher}

; Default installation directory
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
CreateAppDir=yes

; Allow user to change installation directory
DisableDirPage=no
DisableProgramGroupPage=no

; Output configuration
OutputDir=.
OutputBaseFilename=MizeKar-Setup-v{#MyAppVersion}
SetupIconFile=Assets\logo.ico
UninstallDisplayIcon={app}\{#MyAppExeName}

; License file
LicenseFile=LICENSE.txt

; Compression
Compression=lzma2/max
SolidCompression=yes

; Privileges
PrivilegesRequired=admin
PrivilegesRequiredOverridesAllowed=dialog

; Wizard appearance
WizardStyle=modern
; Using default modern wizard images (WizModern images not available in this Inno Setup version)

; Architecture
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible

; Version info
VersionInfoVersion=1.1.0.0
VersionInfoCompany={#MyAppPublisher}
VersionInfoDescription={#MyAppName} Setup
VersionInfoCopyright=Copyright (C) 2025
VersionInfoProductName={#MyAppName}
VersionInfoProductVersion=1.1.0.0

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
; Note: Farsi.isl not available in this Inno Setup version
; You can download it from: https://github.com/jrsoftware/issrc/tree/main/Files/Languages/Unofficial

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 6.1; Check: not IsAdminInstallMode

[Dirs]
; Create application directory with full permissions
Name: "{app}"; Permissions: users-full

[Files]
; Main executable and all files from publish folder
Source: "bin\Release\net8.0-windows\win-x64\publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
; Start Menu shortcuts
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\Assets\logo.ico"; Comment: "مدیریت پوشه‌ها با پشتیبانی فارسی"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"; IconFilename: "{app}\Assets\logo.ico"

; Desktop shortcut (if selected)
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\Assets\logo.ico"; Tasks: desktopicon; Comment: "مدیریت پوشه‌ها با پشتیبانی فارسی"

; Quick Launch shortcut (if selected, Windows 7 and below)
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\Assets\logo.ico"; Tasks: quicklaunchicon

[Run]
; Option to launch application after installation
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[UninstallDelete]
; Delete Data folder on uninstall (optional - ask user)
Type: filesandordirs; Name: "{app}\Data"

[Code]
// Custom installer code (Pascal Script)

var
  DataDirPage: TInputDirWizardPage;

procedure InitializeWizard;
begin
  // Create custom page asking about Data folder location
  DataDirPage := CreateInputDirPage(wpSelectDir,
    'Select Data Folder Location',
    'Where should application data be stored?',
    'MizeKar stores folders and images in a Data directory. ' +
    'Select where you want this data to be stored, then click Next.' +
    'Default: Same as application folder (recommended)',
    False, '');
  DataDirPage.Add('');
  // Note: Don't use {app} here - it's not initialized yet in InitializeWizard
  // Default value will be set later if this page is enabled
  DataDirPage.Values[0] := 'C:\Program Files\MizeKar\Data';
end;

function ShouldSkipPage(PageID: Integer): Boolean;
begin
  // Skip data directory page for now (use default location)
  // Can be enabled in future versions
  Result := (PageID = DataDirPage.ID);
end;

// Show welcome message
function GetWelcomeMessage(Param: String): String;
begin
  Result := 'Welcome to MizeKar Setup';
end;

[Messages]
; Custom messages
WelcomeLabel2=This will install [name/ver] on your computer.%n%nMizeKar Features:%n%n- Fullscreen folder manager with Persian language support%n- Category-based organization (9 colorful categories)%n- Flicker-free page navigation%n- Watermark branding on pages%n- Minimize button on all pages%n- Real-time folder updates%n- Image display system for charts%n- Custom Persian dialogs%n- Keyboard shortcuts support%n%nIt is recommended that you close all other applications before continuing.
FinishedLabel=MizeKar has been successfully installed on your computer.%n%nYou can now launch the application from the Start Menu or Desktop shortcut.%n%nData will be stored in: %APPDATA%\MizeKar\Data

[CustomMessages]
; Additional custom messages
english.DataFolder=Data Folder
