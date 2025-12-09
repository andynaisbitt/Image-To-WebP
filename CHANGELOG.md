# Changelog

All notable changes to **Image to WebP** will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [Unreleased]

### Planned for v0.2
- Before/after size comparison display
- Processed files results list
- Improved drag & drop stability
- Progress indicators for batch processing
- Better error handling (continue on failure)

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
