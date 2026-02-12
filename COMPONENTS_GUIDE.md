# 📚 AlohaPDF - Components Guide

Quick reference for all AlohaPDF elements with examples.

---

## 📊 Table Component

**Purpose**: Display data in rows and columns with customizable headers and styling.

### Basic Usage

```csharp
pdf.AddTable(
    headers: new[] { "Name", "Age", "City" },
    rows: new[]
    {
        new[] { "John", "30", "NYC" },
        new[] { "Jane", "25", "LA" }
    }
);
```

### With Styling

```csharp
pdf.AddTable(
    headers: new[] { "Product", "Price", "Stock" },
    rows: data,
    alternateRows: true,              // Zebra striping
    headerStyle: TableHeaderStyle.Primary,  // Coral header
    leftMargin: 24f,                  // Indent 24 points
    rightMargin: 0f
);
```

### Header Styles

| Style | Description | Use Case |
|-------|-------------|----------|
| `Primary` | Coral (#FF6B35) | Warm, inviting tables |
| `Secondary` | Ocean (#00A8CC) | Professional data |
| `Dark` | Dark gray | Elegant reports |
| `Light` | Light gray | Clean, simple |
| `Minimal` | Bottom border only | Modern, minimal |

### Advanced Options

```csharp
using AlohaPDF.Elements.Table;

var config = new TableConfig
{
    Headers = new[] { "Q1", "Q2", "Q3", "Q4" },
    Rows = data,
    AlternateRows = true,
    HeaderStyle = TableHeaderStyle.Primary,
    LeftMargin = 0f,
    RightMargin = 0f,
    RepeatHeadersOnPageBreak = true,  // Repeat on new pages
    ShowHeaders = true
};

var table = new TableElement(config);
pdf.AddElement(table);
```

---

## 📝 Paragraph Component

**Purpose**: Display text with automatic word wrapping and formatting.

### Basic Usage

```csharp
pdf.AddParagraph("This is a simple paragraph that will wrap automatically.");
```

### With Styling

```csharp
pdf.AddParagraph(
    text: "Important information here.",
    lineHeight: 2f,      // Extra spacing between lines
    isBold: true,        // Bold text
    leftMargin: 24f      // Indent for quotes
);
```

### Advanced Options

```csharp
using AlohaPDF.Elements.Paragraph;

var config = new ParagraphConfig
{
    Text = "Your long text here...",
    LineHeight = 2f,       // Extra line spacing
    IsBold = false,        // Use bold font
    LeftMargin = 24f,      // Indent from left
    FontSize = 12f         // Font size in points
};

var paragraph = new ParagraphElement(config);
pdf.AddElement(paragraph);
```

### Use Cases

```csharp
// Standard paragraph
pdf.AddParagraph("Regular body text...");

// Indented quote
pdf.AddParagraph(
    "This is a quote or important note.",
    leftMargin: 24f,
    lineHeight: 2f
);

// Bold emphasis
pdf.AddParagraph(
    "This is important!",
    isBold: true
);
```

---

## 📋 List Component

**Purpose**: Display bullet points or numbered lists.

### Bullet List

```csharp
pdf.AddList(
    items: new[]
    {
        "First point",
        "Second point",
        "Third point"
    }
);
```

### Numbered List

```csharp
pdf.AddList(
    items: new[]
    {
        "Step one",
        "Step two",
        "Step three"
    },
    isNumbered: true
);
```

### Advanced Options

```csharp
using AlohaPDF.Elements.List;

var config = new ListConfig
{
    Items = new List<string>
    {
        "Item 1",
        "Item 2",
        "Item 3"
    },
    UseMonospace = false,      // Use monospace font
    WithMargin = true,          // Add left margin
    IsNumbered = true,          // 1. 2. 3. instead of •
    AlternateRows = false,      // Zebra striping
    CustomPrefix = "→ ",        // Custom bullet character
    LeftMargin = 24f            // Margin size
};

var list = new ListElement(config);
pdf.AddElement(list);
```

### List Styles

```csharp
// Standard bullets
pdf.AddList(items);

// Numbered
pdf.AddList(items, isNumbered: true);

// With margin (indented)
pdf.AddList(items, withMargin: true);

// Monospace (for code/console)
pdf.AddList(items, useMonospace: true);

// Custom prefix
pdf.AddList(items, customPrefix: "✓ ");

// Alternating backgrounds
pdf.AddList(items, alternateRows: true);
```

---

## 🏷️ Section Component

**Purpose**: Display section headings with optional pill styling.

### Basic Section

```csharp
pdf.AddSection("1. Introduction");
```

### Pill Style Section

```csharp
pdf.AddSection("🌺 Welcome", pill: true);
```

### Advanced Options

```csharp
using AlohaPDF.Elements.Section;

var config = new SectionConfig
{
    Text = "2. Main Content",
    Pill = false,          // Use pill/badge style
    FontSize = 16f         // Font size
};

var section = new SectionElement(config);
pdf.AddElement(section);
```

### Section Styles

```csharp
// Simple text heading
pdf.AddSection("Section Title");

// Pill/badge style (coral background, rounded)
pdf.AddSection("🎯 Important Section", pill: true);

// With emoji for visual interest
pdf.AddSection("📊 Data Analysis");
```

---

## ➖ Line Component

**Purpose**: Display horizontal separators/dividers.

### Basic Line

```csharp
pdf.AddLine();
```

### With Margins

```csharp
pdf.AddLine(leftMargin: 24f, rightMargin: 24f);
```

### Advanced Options

```csharp
using AlohaPDF.Elements.Line;

var config = new LineConfig
{
    LeftMargin = 0f,       // Left indent
    RightMargin = 0f,      // Right indent
    StrokeWidth = 1f       // Line thickness
};

var line = new LineElement(config);
pdf.AddElement(line);
```

### Use Cases

```csharp
// Full-width separator
pdf.AddLine();

// Indented separator (for subsections)
pdf.AddLine(leftMargin: 24f, rightMargin: 24f);

// Thick separator
pdf.AddLine(strokeWidth: 2f);
```

---

## 🎨 Spacing Component

**Purpose**: Add vertical space between elements.

### Usage

```csharp
using AlohaPDF.Styling;

// Small space
pdf.AddSpace(PdfLayout.SpaceSm);    // 8 points

// Medium space
pdf.AddSpace(PdfLayout.SpaceMd);    // 16 points

// Large space
pdf.AddSpace(PdfLayout.SpaceLg);    // 24 points

// Extra large space
pdf.AddSpace(PdfLayout.SpaceXl);    // 32 points

// 2X large space
pdf.AddSpace(PdfLayout.Space2xl);   // 48 points

// Custom space
pdf.AddSpace(100f);                  // 100 points
```

---

## 📐 Layout Best Practices

### Document Structure

```csharp
pdf.Initialize(options);

pdf
    .AddSection("Introduction", pill: true)
    .AddParagraph("Welcome text...")
    .AddSpace(PdfLayout.SpaceLg)
    
    .AddSection("Data Overview")
    .AddTable(headers, rows, headerStyle: TableHeaderStyle.Primary)
    .AddSpace(PdfLayout.SpaceMd)
    
    .AddSection("Key Points")
    .AddList(items, isNumbered: true)
    .AddSpace(PdfLayout.SpaceMd)
    
    .AddLine()
    .AddSpace(PdfLayout.SpaceSm)
    
    .AddParagraph("Conclusion...");

pdf.Generate("output.pdf");
```

### Spacing Guidelines

| Component | Spacing After | Reason |
|-----------|---------------|--------|
| Section | `SpaceLg` (24pt) | Clear separation |
| Table | `SpaceMd` (16pt) | Readable flow |
| Paragraph | `SpaceSm` (8pt) | Compact text |
| List | `SpaceMd` (16pt) | Group separation |
| Line | `SpaceSm` (8pt) | Subtle break |

### Margins

```csharp
// Default margin
var options = new PdfDocumentOptions
{
    PageMargin = PdfLayout.MarginDefault  // 48 points (~17mm)
};

// Compact margin (more content per page)
var optionsCompact = new PdfDocumentOptions
{
    PageMargin = PdfLayout.MarginCompact  // 32 points (~11mm)
};

// Relaxed margin (more whitespace)
var optionsRelaxed = new PdfDocumentOptions
{
    PageMargin = PdfLayout.MarginRelaxed  // 64 points (~23mm)
};
```

---

## 🎯 Complete Example

```csharp
using AlohaPDF;
using AlohaPDF.Core;
using AlohaPDF.Styling;

var pdf = new AlohaPdfDocument();

pdf.Initialize(new PdfDocumentOptions
{
    Title = "Monthly Report",
    Subtitle = "January 2026",
    PageSize = PageSize.A4,
    Orientation = PageOrientation.Portrait,
    Info = new DocumentInfo
    {
        Author = "John Doe",
        CreatedDate = DateTime.Now
    }
});

pdf
    // Executive Summary
    .AddSection("📋 Executive Summary", pill: true)
    .AddParagraph(
        "This report provides an overview of our performance...",
        lineHeight: 2f
    )
    .AddSpace(PdfLayout.SpaceLg)
    
    // Key Metrics
    .AddSection("📊 Key Metrics")
    .AddTable(
        headers: new[] { "Metric", "Target", "Actual", "Status" },
        rows: new[]
        {
            new[] { "Revenue", "$100K", "$125K", "✓ On Track" },
            new[] { "Customers", "500", "632", "✓ Exceeded" }
        },
        headerStyle: TableHeaderStyle.Primary,
        alternateRows: true
    )
    .AddSpace(PdfLayout.SpaceMd)
    
    // Action Items
    .AddSection("✅ Action Items")
    .AddList(
        items: new[]
        {
            "Complete Q1 review",
            "Plan Q2 initiatives",
            "Update forecasts"
        },
        isNumbered: true
    )
    .AddSpace(PdfLayout.SpaceMd)
    
    // Separator
    .AddLine()
    .AddSpace(PdfLayout.SpaceSm)
    
    // Footer note
    .AddParagraph(
        "For questions, contact john.doe@example.com",
        leftMargin: 24f,
        lineHeight: 2f
    );

pdf.Generate("monthly-report.pdf");
```

---

## 🔍 Component Reference Summary

| Component | Purpose | Key Options |
|-----------|---------|-------------|
| **Table** | Tabular data | `headerStyle`, `alternateRows`, `leftMargin` |
| **Paragraph** | Text blocks | `isBold`, `lineHeight`, `leftMargin` |
| **List** | Bullet/numbered | `isNumbered`, `useMonospace`, `customPrefix` |
| **Section** | Headings | `pill`, `fontSize` |
| **Line** | Separators | `leftMargin`, `rightMargin`, `strokeWidth` |
| **Space** | Vertical gaps | `PdfLayout.Space*` constants |

---

## 📖 See Also

- [README.md](README.md) - Main documentation
- [ARCHITECTURE.md](ARCHITECTURE.md) - SOLID architecture
- [PAGESIZE_GUIDE.md](PAGESIZE_GUIDE.md) - Page sizes
- [ORIENTATION_GUIDE.md](ORIENTATION_GUIDE.md) - Orientations

---

*Made with 🌺 Aloha Spirit - Simple components, beautiful PDFs!*
