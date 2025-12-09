# Image to WebP – Lightweight Image Optimiser

A fast, offline Windows tool that converts images to WebP format with automatic resizing and compression. Drop images in, get optimized files out. No bloat, no cloud, no telemetry.

---

## What Problem Does This Solve?

- **Blog images are too large** – 5MB photos slow down your site
- **CMS upload limits** – Hosting providers cap file sizes
- **Bandwidth costs** – Large images waste server resources and mobile data
- **Manual resizing is tedious** – Photoshop is overkill for bulk optimization

This tool solves **one problem extremely well**: converting images to web-ready WebP files with sensible defaults.

---

## Who Is This For?

- **Bloggers** who need to optimize images before uploading to WordPress/Ghost/Hugo
- **Developers** who want a quick local tool without installing bloated software
- **Content teams** who process dozens of images daily
- **Anyone** who values speed, simplicity, and offline-first tools

---

## What It Does

✅ **Converts** JPG, PNG, BMP, GIF → WebP
✅ **Resizes** to a maximum width (default: 1200px, preserves aspect ratio)
✅ **Compresses** with web-optimized quality settings (default: 85%)
✅ **Outputs** to the same folder as originals (appends `_optimized.webp`)
✅ **Works offline** – No internet, accounts, or cloud dependencies

---

## What It Is NOT

❌ Not a photo editor (use GIMP/Photoshop for that)
❌ Not an all-in-one image suite
❌ Not trying to replace ImageMagick/FFmpeg for power users
❌ Not a SaaS product with subscriptions or accounts
❌ Not bloated with AI, presets, filters, or plugins

**Philosophy:** Solve one problem, solve it well, stay fast.

---

## Current Version: v0.2

**Status:** UX upgrade complete – polished and production-ready

### Features
- ✅ Drag & drop with visual feedback (panel highlights on hover)
- ✅ Browse button for easy file selection
- ✅ Results list showing all processed files with detailed stats
- ✅ Before/after size display with compression percentage
- ✅ Progress bar for batch operations
- ✅ Total statistics (cumulative savings across all images)
- ✅ Error handling that continues on failure
- ✅ Clear results button
- ✅ Automatic WebP conversion with optimized settings
  - Max width: 1200px (preserves aspect ratio)
  - Quality: 85%
  - Output: Same folder as source, appends `_optimized.webp`

### Remaining Limitations
- No output folder selection (saves next to originals) – coming in v0.3
- No settings customization (quality/width locked) – coming in v1.0
- No folder mode (must select individual files) – coming in v0.3

---

## Installation

1. **Download** the latest `ImageToWebP.exe` from [Releases](../../releases)
2. **Run** the EXE (no installation required)
3. **Optional:** Pin to taskbar or create desktop shortcut

**Requirements:**
- Windows 10/11 (64-bit)
- .NET 8.0 Runtime (usually pre-installed, [download here](https://dotnet.microsoft.com/download/dotnet/8.0) if needed)

---

## Usage

### Method 1: Drag & Drop
1. Open `ImageToWebP.exe`
2. Drag one or more images from Windows Explorer into the app window
3. Wait for processing (progress shown in console/UI)
4. Find optimized files in the same folder as originals

### Method 2: Browse
1. Click "Browse" button
2. Select images (Ctrl+Click for multiple)
3. Click "Open"
4. Files process automatically

### Output Behavior
```
Input:  C:\Photos\vacation.jpg (3.2 MB)
Output: C:\Photos\vacation_optimized.webp (287 KB)

Input:  C:\Blog\screenshot.png (1.8 MB)
Output: C:\Blog\screenshot_optimized.webp (142 KB)
```

**Safety:** Original files are **never modified or deleted**. Only new `_optimized.webp` files are created.

---

## Screenshots

> Placeholder – Screenshots will be added in v0.2 after UI polish

---

## Roadmap

See [ROADMAP.md](docs/ROADMAP.md) for the full development plan.

**Upcoming:**
- **v0.2** – Improved UX (before/after stats, results list, drag/drop stability)
- **v0.3** – Batch processing (folder mode, output folder selector)
- **v1.0** – Power user features (presets, shell integration, optional installer)

---

## Known Issues

- **No folder mode yet** – You must select individual files, can't drop entire folders (coming in v0.3)
- **Output location fixed** – Files are saved next to originals, no folder picker yet (coming in v0.3)
- **Settings are hardcoded** – Quality and max width can't be customized yet (coming in v1.0)

Report bugs via [GitHub Issues](../../issues).

---

## Technical Stack

- **Language:** C# (.NET 8.0)
- **UI:** Windows Forms (WinForms) – chosen for speed and simplicity
- **WebP Encoding:** [ImageSharp](https://github.com/SixLabors/ImageSharp) or [SkiaSharp](https://github.com/mono/SkiaSharp)
- **Build:** Published as a single-file EXE (self-contained or framework-dependent)

---

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.

**TL;DR:**
- Feature requests must align with the "minimal utility" philosophy
- No feature creep – this is not Photoshop
- Bug reports welcome, PRs appreciated

---

## License

MIT License – See [LICENSE](LICENSE) for details.

Free to use, modify, and distribute. No warranty provided.

---

## Why This Tool Exists

Modern image editors are powerful but **overkill** for simple web optimization. Cloud tools require **internet** and **upload your files**. Command-line tools like ImageMagick are **intimidating** for non-technical users.

This tool fills the gap: **a Windows GUI that does one thing well, stays offline, and respects your privacy.**

No analytics. No accounts. No upsells. Just a tool that works.

---

**Made by developers, for developers (and anyone who hates bloated software).**
