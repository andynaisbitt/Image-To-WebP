# Repository Structure

Complete guide to the **Image to WebP** repository layout.

---

## Root Files

### Documentation
| File | Purpose |
|------|---------|
| `README.md` | Main project overview, installation, usage instructions |
| `CHANGELOG.md` | Version history and release notes |
| `ROADMAP.md` | Planned features and development timeline |
| `PHILOSOPHY.md` | Project principles and design decisions |
| `CONTRIBUTING.md` | Contribution guidelines and code standards |
| `RELEASE_PROCESS.md` | How releases are created and distributed |
| `REPOSITORY_STRUCTURE.md` | This file – explains repo layout |

### Legal
| File | Purpose |
|------|---------|
| `LICENSE` | MIT License – legal terms for usage and distribution |

### Code (when added)
| File/Folder | Purpose |
|-------------|---------|
| `Program.cs` | Main application entry point |
| `*.csproj` | C# project file (build configuration) |
| `Properties/` | Assembly info and app settings |
| `/bin/` | Compiled binaries (gitignored) |
| `/obj/` | Build intermediate files (gitignored) |

---

## Folders

### `/docs/`
**Purpose:** Additional documentation beyond main README

**Contents (planned):**
- `USER_GUIDE.md` – Detailed usage instructions
- `ARCHITECTURE.md` – Technical codebase overview
- `FAQ.md` – Frequently asked questions
- `TROUBLESHOOTING.md` – Common issues and solutions

**Current status:** Placeholder README exists, full docs coming in v0.2+

---

### `/assets/`
**Purpose:** Screenshots, images, and branding for documentation

**Contents (planned):**
- Screenshots of the application UI
- Before/after compression examples
- Application icon and logo (if created)
- Demo images

**Current status:** Placeholder README exists, screenshots coming in v0.2+

---

### `/releases/`
**Purpose:** Build scripts and release metadata (NOT for binaries)

**Contents:**
- Build scripts for creating releases
- SHA256 checksums archive
- Code signing certificates (future)

**What it's NOT for:**
- Compiled EXE files (use GitHub Releases instead)
- Installers or packaged releases
- User-downloadable binaries

**Current status:** Placeholder README exists

---

### `/.github/`
**Purpose:** GitHub-specific configuration and templates

**Contents:**
| File/Folder | Purpose |
|-------------|---------|
| `ISSUE_TEMPLATE/bug_report.md` | Bug report template |
| `ISSUE_TEMPLATE/feature_request.md` | Feature request template |
| `PULL_REQUEST_TEMPLATE.md` | Pull request template |
| `FUNDING.yml` | Donation/sponsorship config (currently disabled) |

**Future additions:**
- `workflows/` – GitHub Actions (CI/CD, automated builds)
- `dependabot.yml` – Automated dependency updates

---

## File Purposes Explained

### Why separate PHILOSOPHY.md from README?
- Keeps README concise and actionable
- Allows deep-dive into design decisions without cluttering main docs
- Helps contributors understand "why" before proposing features

### Why RELEASE_PROCESS.md?
- Documents build commands for maintainers
- Ensures consistent release naming and tagging
- Prevents mistakes during release creation

### Why REPOSITORY_STRUCTURE.md?
- Onboarding guide for new contributors
- Reference for maintainers
- Explains why files exist (not just what they contain)

---

## Gitignore Recommendations

**Should be ignored (not committed to Git):**
```gitignore
# Build outputs
bin/
obj/
*.exe
*.dll
*.pdb

# User-specific files
*.user
*.suo
.vs/

# OS files
Thumbs.db
.DS_Store

# Compiled releases (use GitHub Releases instead)
releases/*.exe
releases/*.zip
```

**Should be committed:**
- All `.md` documentation files
- `.csproj` project files
- Source code (`.cs` files)
- GitHub templates (`.github/`)
- License and legal files

---

## Repository Evolution

### v0.1 (Current)
- Core documentation complete
- Folder structure established
- GitHub templates ready
- Source code coming soon

### v0.2 (Planned)
- Add screenshots to `/assets/`
- Populate `/docs/` with user guides
- Add GitHub Actions workflow (optional)

### v1.0 (Stable)
- Complete architecture documentation
- Installer scripts (if implemented)
- Comprehensive troubleshooting guides

---

## For Contributors

### Where to add...

**A bug fix:**
1. Fix the code
2. Update `CHANGELOG.md` (under "Unreleased")
3. Submit PR with bug report reference

**A new feature:**
1. Discuss in an issue first
2. Implement the code
3. Update `README.md` if it changes usage
4. Update `CHANGELOG.md`
5. Update `ROADMAP.md` if it affects future plans
6. Submit PR

**Documentation improvements:**
- README fixes → Edit `README.md`
- New guides → Add to `/docs/`
- Screenshots → Add to `/assets/`
- Philosophy clarifications → Edit `PHILOSOPHY.md`

**Examples or tutorials:**
- Add to `/docs/` as separate markdown files
- Link from main README

---

## Questions?

- **"Why so many markdown files?"** – Clear documentation prevents confusion and bad PRs
- **"Can I reorganize this?"** – Open an issue first to discuss
- **"Where's the code?"** – Coming soon (documentation-first approach)

---

**Last Updated:** 2025-12-09
