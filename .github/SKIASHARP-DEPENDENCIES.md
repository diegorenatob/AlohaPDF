# SkiaSharp Dependencies - Troubleshooting Guide

## 🎨 About SkiaSharp

AlohaPDF uses SkiaSharp for PDF rendering. SkiaSharp requires native libraries that vary by platform.

## 🐧 Linux Dependencies

### Ubuntu/Debian

```bash
sudo apt-get update
sudo apt-get install -y libfontconfig1 libfreetype6 libx11-6
```

### Fedora/RHEL/CentOS

```bash
sudo dnf install -y fontconfig freetype libX11
```

### Alpine Linux

```bash
apk add --no-cache fontconfig freetype libx11
```

## 🪟 Windows

No additional dependencies required. SkiaSharp works out of the box.

## 🍎 macOS

No additional dependencies required. SkiaSharp works out of the box.

## 📦 NuGet Packages

AlohaPDF includes platform-specific native assets:

```xml
<!-- In AlohaPDF.Tests.csproj -->
<PackageReference Include="SkiaSharp.NativeAssets.Linux" Version="2.88.8" />
```

This package includes the native SkiaSharp binaries for Linux, eliminating the need for manual installation in most cases.

## 🔧 GitHub Actions / CI/CD

The workflow includes automatic installation of dependencies:

```yaml
- name: Install SkiaSharp dependencies
  run: |
    sudo apt-get update
    sudo apt-get install -y libfontconfig1 libfreetype6 libx11-6
```

## 🐳 Docker

If running in Docker, add to your Dockerfile:

```dockerfile
# Ubuntu/Debian base
RUN apt-get update && \
    apt-get install -y libfontconfig1 libfreetype6 libx11-6 && \
    rm -rf /var/lib/apt/lists/*

# Alpine base
RUN apk add --no-cache fontconfig freetype libx11
```

## ❌ Common Errors

### Error: Unable to load shared library 'libSkiaSharp'

**Cause:** Native SkiaSharp library not found.

**Solution:**

1. Install system dependencies:
   ```bash
   sudo apt-get install -y libfontconfig1 libfreetype6 libx11-6
   ```

2. Ensure NuGet package is installed:
   ```bash
   dotnet add package SkiaSharp.NativeAssets.Linux
   ```

3. Restore and rebuild:
   ```bash
   dotnet clean
   dotnet restore
   dotnet build
   ```

### Error: libSkiaSharp.so: cannot open shared object file

**Cause:** Missing system library dependencies.

**Solution:**
```bash
# Check which libraries are missing
ldd /path/to/libSkiaSharp.so

# Install missing dependencies
sudo apt-get install -y libfontconfig1 libfreetype6 libx11-6
```

### Error in GitHub Actions: DllNotFoundException

**Cause:** Runner doesn't have SkiaSharp dependencies.

**Solution:** Already fixed in the workflow! The pipeline now includes:
```yaml
- name: Install SkiaSharp dependencies
  run: |
    sudo apt-get update
    sudo apt-get install -y libfontconfig1 libfreetype6 libx11-6
```

## 🧪 Testing Dependencies

To verify SkiaSharp works correctly:

```bash
# Run a simple test
dotnet test --filter "FullyQualifiedName~Generate_SimpleDocument_ShouldCreatePdfFile"
```

If it passes, SkiaSharp is working correctly!

## 📚 Reference

- [SkiaSharp Documentation](https://github.com/mono/SkiaSharp)
- [SkiaSharp Linux Dependencies](https://github.com/mono/SkiaSharp/wiki/Linux)
- [AlohaPDF CI/CD Setup](.github/SETUP.md)

## 💡 Platform Detection

AlohaPDF automatically uses the correct native libraries for each platform:

- **Windows**: SkiaSharp.dll (bundled)
- **Linux**: libSkiaSharp.so (from NativeAssets.Linux package + system libs)
- **macOS**: libSkiaSharp.dylib (bundled)

## 🆘 Still Having Issues?

1. Check your .NET version: `dotnet --version` (must be 9.0+)
2. Clean and rebuild: `dotnet clean && dotnet restore && dotnet build`
3. Verify package installation: `dotnet list package | grep SkiaSharp`
4. Check system libraries: `ldconfig -p | grep -E "fontconfig|freetype|libX11"`
5. Open an issue: [GitHub Issues](https://github.com/diegorenatob/AlohaPDF/issues)

---

**Last Updated:** 2025-01-XX  
**SkiaSharp Version:** 2.88.8  
**AlohaPDF Version:** 1.0.0
