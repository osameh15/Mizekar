# Fonts Directory

This directory contains custom fonts for the MizeKar application.

## Current Fonts

### Shabnam Font Family
- **Primary Font**: Shabnam (Persian/Arabic support)
- **Weights Available**:
  - Shabnam (Regular)
  - Shabnam-Thin
  - Shabnam-Light  
  - Shabnam-Medium
  - Shabnam-Bold
- **Formats**: TTF, EOT, WOFF, WOFF2
- **Usage**: Primary Persian font for all UI elements

### Fallback Fonts:
- **Tahoma** - Good Persian support (already in Windows)
- **Arial** - Basic Persian support

## Font File Formats
- `.ttf` - TrueType Font (used by WPF)
- `.eot` - Embedded OpenType
- `.woff` - Web Open Font Format
- `.woff2` - Web Open Font Format 2

## Usage in Application
- Shabnam is set as the default font for all Persian text
- Fonts are embedded in the application as resources
- Automatic fallback to Tahoma if Shabnam is not available

## Adding New Fonts
1. Place font files in this directory
2. Update the project file to include them as resources
3. Update the application styles to use the new fonts