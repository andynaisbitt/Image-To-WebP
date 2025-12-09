# Roadmap

This roadmap defines planned features for **Image to WebP**. All releases prioritize **simplicity, speed, and minimal bloat**.

---

## v0.1 – Initial Utility Release ✅

**Status:** Released

**Goal:** Ship a working tool that solves the core problem

### Features
- Drag & drop image conversion
- Browse button for file selection
- WebP encoding with default settings (1200px max width, 85% quality)
- Output to same folder as source files
- Single-file EXE distribution

### Intentional Limitations
- No customization (hardcoded settings)
- No before/after stats
- No batch summary
- Basic UI (functional, not polished)

**Philosophy:** Prove the concept, get feedback, iterate.

---

## v0.2 – UX Upgrade Release

**Target:** Q1 2025 (or when v0.1 feedback stabilizes)

**Goal:** Make the tool feel polished and provide user feedback

### Planned Features
- **Before/After Size Display** – Show original vs optimized file sizes (e.g., "3.2 MB → 287 KB (91% reduction)")
- **Results List** – Display processed files with success/failure status
- **Drag & Drop Stability** – Improve drop zone visibility and focus handling
- **Progress Indicators** – Show processing status for large batches
- **Error Handling** – Continue processing if one file fails, show errors in results
- **File Format Validation** – Warn if unsupported files are dropped

### Out of Scope for v0.2
- Settings customization (still hardcoded)
- Output folder selection (still saves next to originals)
- Folder/batch mode (single files only)

---

## v0.3 – Power User Batch Release

**Target:** Q2 2025

**Goal:** Enable bulk workflows for content teams

### Planned Features
- **Folder Mode** – Drop an entire folder to process all images inside
- **Batch Summary** – Show total files processed, total size saved, average compression ratio
- **Output Folder Selector** – Choose where optimized files are saved (default: source folder, option: custom folder)
- **Recursive Folder Processing** – Option to process subfolders (off by default)
- **File Naming Options** – Choose suffix (e.g., `_optimized`, `_webp`, or custom)

### Out of Scope for v0.3
- Presets or custom quality settings (still hardcoded)
- Shell integration
- Auto-update

---

## v1.0 – Stable Utility Release

**Target:** Mid 2025

**Goal:** Feature-complete, production-ready, stable release

### Planned Features
- **Windows Shell Integration** – Right-click images/folders → "Convert to WebP"
- **Presets** – Quick-select profiles:
  - **Blog (default):** 1200px, 85% quality
  - **Thumbnail:** 600px, 80% quality
  - **High Quality:** 1920px, 90% quality
  - **Custom:** Manual width/quality sliders
- **Optional Auto-Update** – Check for new releases (opt-in, not forced)
- **Optional Installer** – Choice between portable EXE or traditional installer (Start Menu, uninstaller, etc.)
- **Settings Persistence** – Remember last-used preset, output folder, etc.

### Out of Scope for v1.0
- Advanced editing (crop, filters, adjustments)
- Cloud sync or upload
- Batch renaming/organization
- Video/GIF support
- Plugins or extensions

---

## Features That Will NEVER Be Added

To keep this tool **focused, fast, and bloat-free**, the following are **explicitly out of scope**:

❌ **Photo editing tools** (crop, rotate, filters, adjustments) – Use GIMP, Photoshop, or Paint.NET
❌ **Cloud upload/sync** – This is an offline-first tool
❌ **Accounts or logins** – No tracking, no user data, no servers
❌ **Telemetry or analytics** – We don't collect usage data
❌ **AI features** – No auto-tagging, content-aware resizing, or upscaling
❌ **Paid tiers or subscriptions** – Free forever, MIT licensed
❌ **Plugin system** – Keeps codebase simple and secure
❌ **Background services** – No always-running processes
❌ **Video/GIF conversion** – Use FFmpeg or dedicated tools
❌ **Format zoo** – WebP output only (use other tools for AVIF, JPEG XL, etc.)

**Why?** Every feature has a maintenance cost. Bloat kills tools. We solve **one problem well** instead of ten problems poorly.

---

## Contributing Ideas

Have a feature request? **Read this first:**

1. Does it align with the "minimal utility" philosophy?
2. Can it be implemented without bloating the UI or codebase?
3. Is it solving a **real problem** or just "nice to have"?

If yes to all three, [open an issue](../../issues) and we'll discuss.

**Examples of GOOD requests:**
- "Add JPG output option alongside WebP"
- "Remember last-used output folder between sessions"
- "Add keyboard shortcut for Browse (Ctrl+O)"

**Examples of BAD requests:**
- "Add filters and adjustments like Instagram"
- "Integrate with Dropbox/Google Photos"
- "Add AI-powered background removal"

---

## Release Philosophy

- **v0.x** = Experimental, breaking changes allowed
- **v1.0** = Stable API, backward-compatible updates
- **v2.0+** = Only if fundamental architecture changes are needed

**No endless version inflation.** If v1.0 solves the problem, we maintain it, not endlessly ship v2, v3, v4 for marketing.

---

**Last Updated:** 2025-12-09
