# Changelog

All notable changes to **Image to WebP** will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [Unreleased]

### Planned for v0.3
- Folder mode (drop entire folders to process)
- Batch summary statistics
- Output folder selector
- Recursive folder processing option

---

## [0.2.0] – 2025-12-09

### Added
- **Browse button** for file selection (no more drag-only)
- **Results list view** showing all processed files with detailed stats
- **Before/after size display** for each image with compression percentage
- **Progress bar** for visual feedback during batch processing
- **Total statistics display** showing cumulative savings across all processed images
- **Clear results button** to reset the results list
- **Visual drag & drop feedback** (panel changes color when dragging files)
- Professional modern UI with better layout and spacing

### Improved
- **Error handling** now continues processing even if one file fails
- **Drag & drop stability** with better visual feedback
- **File validation** with clear error messages for unsupported formats
- UI is now responsive and properly sized for modern displays

### Fixed
- Processing no longer stops on first error
- Better feedback for users during long operations
- Proper file extension detection

### Changed
- Renamed Form1.cs to MainForm.cs (cleaner codebase)
- Improved code organization and separation of concerns
- Updated output filename to use `_optimized.webp` suffix

### Technical
- Complete UI overhaul using TableLayoutPanel for responsive design
- ListView with 6 columns for detailed results
- Real-time progress tracking
- Better exception handling with user-friendly error messages

---

## [0.1.0] – 2025-12-09

### Added
- Initial release of Image to WebP converter
- Drag & drop support for single and multiple images
- Browse button for file selection
- Automatic WebP conversion with default settings:
  - Max width: 1200px (preserves aspect ratio)
  - Quality: 85%
  - Output: Same folder as source, appends `_optimized.webp`
- Support for JPG, PNG, BMP, GIF input formats
- Single-file EXE distribution (no installation required)
- Windows 10/11 compatibility (.NET 8.0)

### Known Issues
- Drag & drop requires app window to be in focus
- No visual progress indicator for large batches
- Processing stops if a single file fails
- No before/after stats shown
- Settings are hardcoded (no customization)

### Technical
- Built with C# (.NET 8.0) and Windows Forms
- Uses ImageSharp/SkiaSharp for WebP encoding
- Published as single-file executable

---

## Release Tags

- `v0.1.0` – [Initial Utility Release](../../releases/tag/v0.1.0)

---

**Format Notes:**
- `Added` = New features
- `Changed` = Changes to existing functionality
- `Deprecated` = Soon-to-be removed features
- `Removed` = Removed features
- `Fixed` = Bug fixes
- `Security` = Vulnerability patches
