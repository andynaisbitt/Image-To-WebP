# Contributing to Image to WebP

Thank you for considering contributing! This project values **simplicity, focus, and minimal bloat** above all else.

---

## Philosophy First

Before contributing, understand the project's core principles:

1. **Solve one problem well** – This is not an all-in-one image suite
2. **No feature creep** – Every feature has a maintenance cost
3. **Offline-first** – No cloud, accounts, or telemetry
4. **Speed over features** – A fast, simple tool beats a slow, bloated one
5. **Respect user agency** – No forced updates, no background services, no dark patterns

**If your contribution violates these principles, it will be rejected.**

---

## How to Contribute

### 1. Reporting Bugs

**Before opening an issue:**
- Check [existing issues](../../issues) to avoid duplicates
- Verify you're using the latest release
- Test with a fresh download (not a modified build)

**When reporting:**
- Describe what happened vs. what you expected
- Include steps to reproduce
- Specify Windows version and .NET runtime version
- Attach example images if relevant (compress them first!)
- Include any error messages or crash logs

**Example:**
```
**Bug:** App crashes when dropping PNG files

**Steps:**
1. Open ImageToWebP.exe
2. Drag a PNG file from Desktop
3. App crashes with error "System.NullReferenceException"

**Environment:**
- Windows 11 23H2
- .NET 8.0.1
- ImageToWebP v0.1.0

**Attachment:** crash_log.txt
```

---

### 2. Suggesting Features

**Before requesting:**
- Read [ROADMAP.md](ROADMAP.md) – your idea might already be planned
- Check the "Features That Will NEVER Be Added" section
- Ask yourself: "Does this align with the minimal utility philosophy?"

**Good feature requests:**
- Solve a real problem (not just "nice to have")
- Keep the UI simple
- Don't require cloud services or external dependencies
- Are feasible to implement without major refactoring

**Examples:**

✅ **GOOD:**
- "Add option to output JPG alongside WebP"
- "Remember last-used output folder"
- "Add Ctrl+O keyboard shortcut for Browse"

❌ **BAD:**
- "Add Instagram-style filters" (use a photo editor)
- "Integrate with Google Drive" (offline-first principle)
- "Add AI upscaling" (bloat, external dependencies)

---

### 3. Submitting Code (Pull Requests)

**Before writing code:**
1. Open an issue first to discuss the feature/fix
2. Wait for maintainer approval (avoids wasted effort)
3. Fork the repository

**Code standards:**
- **C# conventions:** Follow [Microsoft C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- **Keep it simple:** Prefer readability over cleverness
- **No external bloat:** Avoid adding unnecessary NuGet packages
- **Comment complex logic:** Explain "why", not "what"
- **Test before submitting:** Verify your changes on Windows 10 and 11

**PR guidelines:**
- One feature/fix per PR (no "mega PRs" with 10 changes)
- Write a clear description of what changed and why
- Reference the related issue (e.g., "Fixes #42")
- Update `CHANGELOG.md` if adding features
- Update `README.md` if changing usage instructions

**Example PR:**
```
**Title:** Add before/after size comparison display

**Description:**
Implements feature requested in #15. Displays original and optimized file sizes after processing, with percentage reduction.

**Changes:**
- Added `FileSizeComparer` class to calculate size differences
- Updated UI to show results in a list view
- Added unit tests for size calculation

**Testing:**
- Tested on Windows 10 and 11
- Verified with JPG, PNG, BMP files
- Checked edge cases (empty files, corrupted images)

Closes #15
```

---

### 4. Documentation Improvements

Documentation contributions are **highly valued**:
- Fix typos, grammar, or unclear instructions
- Add missing examples or screenshots
- Improve README clarity for non-technical users

**No approval needed** – just submit a PR with clear changes.

---

## What We DON'T Want

### No Feature Creep
- Image editing tools (crop, rotate, filters)
- Video/GIF conversion
- Cloud upload/sync
- Paid features or subscriptions
- Telemetry or analytics
- Plugin systems

### No UI Wars
- Don't rewrite the entire UI without discussion
- Don't add themes, skins, or customization just because you prefer it
- Keep the UI functional, not flashy

### No External Dependencies Without Justification
- Don't add NuGet packages for trivial tasks
- Don't integrate APIs or web services
- Don't require internet connectivity

---

## Binary Release Rules

**Only maintainers publish official releases.**

Why?
- Prevents malware-infected EXEs from spreading
- Ensures code signing consistency
- Maintains trust in the official distribution

**If you want to distribute a fork:**
- Rename the project (don't call it "Image to WebP")
- Clearly state it's unofficial
- Link back to the original repository

---

## Code of Conduct

**TL;DR: Be respectful, professional, and collaborative.**

- Assume good intent
- Focus on technical merit, not personal attacks
- Disagree respectfully
- Accept maintainer decisions gracefully

**We reject:**
- Harassment, discrimination, or toxicity
- Entitled demands ("add this NOW or I'll fork")
- Spam, advertising, or self-promotion

Violations may result in being blocked from the repository.

---

## Questions?

- **General questions:** [Open a discussion](../../discussions)
- **Bug reports:** [Open an issue](../../issues)
- **Security issues:** [Open an issue](../../issues) with "SECURITY" in the title

---

## License

By contributing, you agree that your contributions will be licensed under the **MIT License** (same as the project).

---

**Thank you for helping make Image to WebP better while keeping it simple!**
