# Release Process

This document defines how **Image to WebP** releases are created, versioned, and distributed.

---

## Versioning Scheme

We follow [Semantic Versioning](https://semver.org/) (SemVer):

```
MAJOR.MINOR.PATCH
```

- **MAJOR** (e.g., 1.0.0 → 2.0.0) – Breaking changes, incompatible API changes
- **MINOR** (e.g., 0.1.0 → 0.2.0) – New features, backward-compatible
- **PATCH** (e.g., 0.1.0 → 0.1.1) – Bug fixes, backward-compatible

### Pre-1.0 (Experimental Phase)
- **v0.x.x** = Breaking changes allowed, API not stable
- Users should expect rough edges and missing features
- Perfect for gathering feedback and iterating quickly

### Post-1.0 (Stable Phase)
- **v1.x.x** = API is stable, backward-compatible updates only
- Breaking changes require v2.0.0
- Security patches may be backported to older versions

---

## Release Types

### 1. Stable Releases
**Example:** `v0.1.0`, `v0.2.0`, `v1.0.0`

**When:**
- Feature is complete and tested
- No known critical bugs
- Ready for general use

**Process:**
1. Update `CHANGELOG.md` with all changes
2. Update version in `AssemblyInfo.cs` or `.csproj`
3. Build release EXE (see Build Process below)
4. Create Git tag: `git tag v0.1.0`
5. Push tag: `git push origin v0.1.0`
6. Create GitHub Release (see below)
7. Attach compiled EXE to release

**Naming:**
- Tag: `v0.1.0`
- Release title: `v0.1.0 – Initial Utility Release`
- EXE filename: `ImageToWebP-v0.1.0.exe`

---

### 2. Experimental Releases (Optional)
**Example:** `v0.2.0-beta`, `v0.3.0-rc1`

**When:**
- Testing new features before stable release
- Gathering feedback from early adopters
- Not recommended for production use

**Process:**
- Same as stable, but mark as "Pre-release" on GitHub
- Include warning in release notes

**Naming:**
- Tag: `v0.2.0-beta`
- Release title: `v0.2.0-beta – UX Upgrade (Experimental)`
- EXE filename: `ImageToWebP-v0.2.0-beta.exe`

---

## Build Process

### Single-File EXE (Self-Contained)
**Recommended for v0.x releases** (includes .NET runtime, no external dependencies)

```bash
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true
```

**Output:** `bin/Release/net8.0/win-x64/publish/ImageToWebP.exe`

**Pros:**
- Works on any Windows 10/11 system
- No .NET installation required
- Easier for non-technical users

**Cons:**
- Larger file size (~70-100 MB due to bundled runtime)

---

### Framework-Dependent EXE
**Optional for v1.0+** (smaller file, requires .NET 8.0 installed)

```bash
dotnet publish -c Release -r win-x64 --self-contained false /p:PublishSingleFile=true
```

**Output:** `bin/Release/net8.0/win-x64/publish/ImageToWebP.exe`

**Pros:**
- Smaller file size (~5-10 MB)
- Faster startup time

**Cons:**
- Requires user to install .NET 8.0 Runtime

---

## GitHub Release Checklist

### Before Release
- [ ] All planned features complete
- [ ] No known critical bugs
- [ ] Tested on Windows 10 and 11
- [ ] Updated `CHANGELOG.md`
- [ ] Updated version in code
- [ ] Build process verified

### Creating Release
1. **Go to:** [Releases](../../releases) → Draft a new release
2. **Tag:** `v0.1.0` (create new tag)
3. **Title:** `v0.1.0 – Initial Utility Release`
4. **Description:** Copy from `CHANGELOG.md` + add highlights
5. **Attach binaries:**
   - `ImageToWebP-v0.1.0.exe` (self-contained build)
   - Optional: `ImageToWebP-v0.1.0-framework-dependent.exe`
6. **Mark as pre-release** if experimental
7. **Publish release**

### After Release
- [ ] Test download link
- [ ] Verify EXE runs on clean Windows install
- [ ] Update README if needed (e.g., download link)
- [ ] Announce release (optional: Twitter, blog, etc.)

---

## Release Notes Template

```markdown
## v0.2.0 – UX Upgrade Release

**Release Date:** 2025-XX-XX

### What's New
- ✨ Before/after size comparison display
- ✨ Processed files results list
- 🐛 Fixed drag & drop focus issues
- 🐛 Improved error handling (continues on failure)

### Installation
Download `ImageToWebP-v0.2.0.exe` below. No installation required.

**Requirements:** Windows 10/11 (64-bit)

### Known Issues
- Output folder selection not yet available (planned for v0.3)
- Settings still hardcoded (presets planned for v1.0)

### Full Changelog
See [CHANGELOG.md](CHANGELOG.md#020) for details.

---

**SHA256 Checksum:**
```
<hash will be here>
```

Verify integrity: `certutil -hashfile ImageToWebP-v0.2.0.exe SHA256`
```

---

## Security & Code Signing

### v0.x Releases (Current)
- Unsigned binaries (no code signing certificate yet)
- Users may see "Windows protected your PC" SmartScreen warning
- Include SHA256 checksum for manual verification

### v1.0+ Releases (Future)
- **Optional:** Purchase code signing certificate (~$100-300/year)
- Sign EXE with certificate to avoid SmartScreen warnings
- Provides additional trust for users

**Note:** Code signing is NOT required, just improves UX. Many open-source tools ship unsigned.

---

## Distribution Channels

### Primary (Official)
- **GitHub Releases** – [github.com/yourusername/image-to-webp/releases](../../releases)
- All official binaries are published here
- Only source of truth for downloads

### Secondary (Community)
- Users may package for Chocolatey, Scoop, etc.
- Must link back to official GitHub releases
- Not officially supported (we don't maintain these)

### Forbidden
- ❌ No third-party download sites (SourceForge, Download.com, etc.)
- ❌ No bundling with adware or installers
- ❌ No repackaging without clear attribution

---

## Hotfix Process

**When:** Critical bug found in stable release (e.g., crashes, data loss)

**Process:**
1. Create hotfix branch from release tag
2. Fix bug (minimal changes only)
3. Increment PATCH version (e.g., `v0.1.0` → `v0.1.1`)
4. Follow normal release process
5. Update `CHANGELOG.md` with fix details

**Example:**
```
## [0.1.1] – 2025-12-15

### Fixed
- Fixed crash when processing PNG files with alpha channel
- Fixed memory leak in batch processing

### Note
This is a hotfix for v0.1.0. All users should upgrade immediately.
```

---

## Deprecation Policy

**Before v1.0:**
- No deprecation warnings needed (breaking changes allowed)

**After v1.0:**
- Deprecated features must be announced 1 MINOR version in advance
- Remove deprecated features in next MAJOR version
- Example: Deprecated in v1.2.0 → Removed in v2.0.0

---

## Questions?

- **Release issues:** [Open an issue](../../issues)
- **Build problems:** Check [CONTRIBUTING.md](CONTRIBUTING.md)

---

**Last Updated:** 2025-12-09
