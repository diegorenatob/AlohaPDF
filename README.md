<div align="center">

# 🌺 AlohaPDF

### *Create Beautiful PDFs with Aloha Spirit*

[![Build and Test](https://github.com/diegorenatob/AlohaPDF/actions/workflows/ci.yml/badge.svg)](https://github.com/diegorenatob/AlohaPDF/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/AlohaPDF.svg?style=flat-square&logo=nuget)](https://www.nuget.org/packages/AlohaPDF/)
[![Downloads](https://img.shields.io/nuget/dt/AlohaPDF.svg?style=flat-square&logo=nuget)](https://www.nuget.org/packages/AlohaPDF/)
[![License: MIT](https://img.shields.io/badge/License-MIT-orange.svg?style=flat-square)](LICENSE)
[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![codecov](https://codecov.io/gh/diegorenatob/AlohaPDF/branch/master/graph/badge.svg)](https://codecov.io/gh/diegorenatob/AlohaPDF)

A modern, intuitive PDF generator for .NET MAUI with tropical vibes.  
Perfect for cross-platform mobile and desktop applications.

[Getting Started](#-getting-started) • [Examples](#-examples) • [Docs](#-documentation) • [Contribute](#-contributing)

</div>

---

## ✨ Why AlohaPDF?

> **The Aloha Spirit** - Creating PDFs should be welcoming, simple, and joyful. AlohaPDF brings that spirit to .NET MAUI.

- 🌺 **Simple & Intuitive** - Fluent API that feels natural
- 🎨 **Beautiful by Default** - Tropical color palette inspired design
- 📱 **Mobile-First** - Built specifically for .NET MAUI
- ⚡ **Lightning Fast** - Optimized for mobile performance  
- 🆓 **100% Open Source** - MIT licensed, free forever
- 🌴 **Modern Design** - Contemporary styling out of the box

## 🚀 Quick Start

### Installation

```bash
dotnet add package AlohaPDF
```

### Your First PDF

```csharp
using AlohaPDF;
using AlohaPDF.Core;

var pdf = new AlohaPdfDocument();

pdf.Initialize(new PdfDocumentOptions 
{
    Title = "Welcome to AlohaPDF",
    Subtitle = "Creating PDFs with Aloha Spirit",
    PageSize = PageSize.A4,  // A4, Letter, Legal, A3, A5, Tabloid, Executive, B4, B5
    Orientation = PageOrientation.Portrait,  // Portrait or Landscape
    Info = new DocumentInfo
    {
        Author = "Your Name",
        CreatedDate = DateTime.Now
        // Displays as simple one-line: "Your Name • Created on Feb 11, 2025"
    }
});

pdf
    .AddSection("Aloha!")
    .AddParagraph("Welcome to the easiest way to create PDFs in .NET MAUI!")
    .AddTable(
        headers: new[] { "Feature", "Status" },
        rows: new[]
        {
            new[] { "Beautiful Design", "✓" },
            new[] { "Easy to Use", "✓" },
            new[] { "Open Source", "✓" }
        },
        headerStyle: TableHeaderStyle.Primary
    );

pdf.Generate("aloha.pdf");
```

**That's it!** 🌺 You just created a beautiful PDF.

## 🎯 Key Features

<table>
<tr>
<td width="50%">

### 📄 Rich Content
- ✅ Sections & Subtitles
- ✅ Paragraphs with styling
- ✅ Tables (4 beautiful styles)
- ✅ Lists (bullet & numbered)
- ✅ Custom spacing
- ✅ Lines & dividers

</td>
<td width="50%">

### 🎨 Tropical Design
- ✅ Coral, ocean, palm colors
- ✅ Modern typography
- ✅ Custom fonts support
- ✅ SVG/PNG/JPG logos
- ✅ Zebra-striped tables
- ✅ Rounded corners

</td>
</tr>
<tr>
<td>

### 🔄 Smart Layout
- ✅ Auto page breaks
- ✅ Text wrapping
- ✅ Repeating headers
- ✅ Dynamic spacing
- ✅ Multi-page support
- ✅ Mobile-optimized

</td>
<td>

### 💻 Developer Joy
- ✅ Fluent, chainable API
- ✅ IntelliSense support
- ✅ XML documentation
- ✅ Type-safe options
- ✅ Zero setup
- ✅ .NET 9 ready

</td>
</tr>
</table>

## 📱 Platform Support

| Platform | Status |
|----------|--------|
| 🍎 iOS | ✅ Fully Supported |
| 🤖 Android | ✅ Fully Supported |
| 🪟 Windows | ✅ Fully Supported |
| 🍎 macOS | ✅ Fully Supported |

## 💡 Examples

### Tropical Color Tables

```csharp
// Coral primary header
pdf.AddTable(headers, rows, headerStyle: TableHeaderStyle.Primary);

// Ocean blue accent
pdf.AddTable(headers, rows, headerStyle: TableHeaderStyle.Secondary);

// Dark professional
pdf.AddTable(headers, rows, headerStyle: TableHeaderStyle.Dark);

// Clean minimal
pdf.AddTable(headers, rows, headerStyle: TableHeaderStyle.Minimal);
```

### Custom Fonts

```csharp
var options = new PdfDocumentOptions
{
    Title = "Custom Font Report",
    Fonts = new FontOptions
    {
        Regular = await FileSystem.OpenAppPackageFileAsync("Fonts/Inter-Regular.ttf"),
        Bold = await FileSystem.OpenAppPackageFileAsync("Fonts/Inter-Bold.ttf")
    }
};
```

### Logos

```csharp
var options = new PdfDocumentOptions
{
    Title = "Company Report",
    HeaderLogo = await FileSystem.OpenAppPackageFileAsync("Images/logo.svg"),
    FooterLogo = await FileSystem.OpenAppPackageFileAsync("Images/logo-gray.svg")
};
```

## 🎨 Color Palette

AlohaPDF uses a tropical-inspired color scheme:

- **Primary (Coral)**: `#FF6B35` - Warm and welcoming
- **Secondary (Ocean)**: `#00A8CC` - Professional and calm
- **Accent (Palm)**: `#6BBF59` - Fresh and vibrant

## 📖 Documentation

### Core Methods

| Method | Description |
|--------|-------------|
| `Initialize(options)` | Set up your PDF |
| `AddSection(text, pill)` | Add numbered section |
| `AddSubtitle(text, pill)` | Add subtitle |
| `AddParagraph(text, ...)` | Add text with wrapping |
| `AddTable(headers, rows, ...)` | Add data table |
| `AddList(items, ...)` | Add bullet/numbered list |
| `Generate(path)` | Create the PDF file |

### Table Styles

- `Primary` - Coral header (warm & inviting)
- `Secondary` - Ocean header (professional)
- `Dark` - Dark header (elegant)
- `Light` - Light header (clean)
- `Minimal` - Bottom border only

## 🏝️ Real-World Examples

Check out `/samples` for complete examples:

- **Sales Report** - Professional business reports
- **Invoice** - Beautiful invoices  
- **Meeting Notes** - Structured documents
- **Product Catalog** - Multi-column layouts

## 🤝 Contributing

Aloha! We welcome contributions with open arms! 🤗

1. 🐛 **Report bugs** - Help us improve
2. 💡 **Suggest features** - Share your ideas
3. 📝 **Improve docs** - Make it easier for others
4. 🔧 **Submit PRs** - Code with Aloha spirit

See [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.

## 📄 License

MIT License - Copyright (c) 2025 Diego Belapatiño Farias

## 🙏 Acknowledgments

- Built with [SkiaSharp](https://github.com/mono/SkiaSharp)
- SVG support by [Svg.Skia](https://github.com/wieslawsoltes/Svg.Skia)
- Inspired by tropical paradise 🏝️

## ⭐ Show Your Support

If AlohaPDF brings Aloha spirit to your project:
- ⭐ Star this repository
- 🐦 Share on social media
- 📝 Write about it
- 💬 Spread the Aloha!

---

<div align="center">

**Made with 🌺 Aloha Spirit by [Diego Belapatiño Farias](https://github.com/diegobelapatinofariasTKE)**

*Create PDFs with joy, not frustration* 😊

[Report Bug](https://github.com/diegorenatob/AlohaPDF/issues) • [Request Feature](https://github.com/diegorenatob/AlohaPDF/issues) • [Say Aloha](https://github.com/diegorenatob/AlohaPDF/discussions)

</div>
