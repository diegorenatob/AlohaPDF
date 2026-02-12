# 📐 AlohaPDF - Page Orientation Guide

## 🎯 Overview

AlohaPDF supports both **Portrait** and **Landscape** orientations for all page sizes. Simply specify the orientation in your document options and AlohaPDF handles the rest!

---

## 🔄 Orientations

### Portrait (Default)
- **Vertical** orientation
- Height > Width
- Most common for documents, reports, letters
- Example: A4 Portrait = 210mm × 297mm (8.27" × 11.69")

### Landscape
- **Horizontal** orientation
- Width > Height
- Perfect for wide tables, charts, presentations
- Example: A4 Landscape = 297mm × 210mm (11.69" × 8.27")

---

## 🚀 Usage

### Basic Usage

```csharp
using AlohaPDF;
using AlohaPDF.Core;

var pdf = new AlohaPdfDocument();

// Portrait (default)
pdf.Initialize(new PdfDocumentOptions
{
    Title = "My Report",
    PageSize = PageSize.A4,
    Orientation = PageOrientation.Portrait  // Vertical
});

// or

// Landscape
pdf.Initialize(new PdfDocumentOptions
{
    Title = "Wide Report",
    PageSize = PageSize.A4,
    Orientation = PageOrientation.Landscape  // Horizontal
});
```

### Quick Examples

```csharp
// Portrait A4 (most common)
var optionsPortrait = new PdfDocumentOptions 
{ 
    PageSize = PageSize.A4,
    Orientation = PageOrientation.Portrait  // 595 × 842 points
};

// Landscape A4 (wide format)
var optionsLandscape = new PdfDocumentOptions 
{ 
    PageSize = PageSize.A4,
    Orientation = PageOrientation.Landscape  // 842 × 595 points (swapped!)
};

// Letter Landscape (US presentations)
var optionsLetterLandscape = new PdfDocumentOptions 
{ 
    PageSize = PageSize.Letter,
    Orientation = PageOrientation.Landscape  // 792 × 612 points
};

// A3 Landscape (posters)
var optionsA3Landscape = new PdfDocumentOptions 
{ 
    PageSize = PageSize.A3,
    Orientation = PageOrientation.Landscape  // 1191 × 842 points
};
```

---

## 📊 Dimensions Comparison

### A4 Example

| Orientation | Width | Height | Use Case |
|-------------|-------|--------|----------|
| **Portrait** | 595pt (210mm) | 842pt (297mm) | Reports, letters, documents |
| **Landscape** | 842pt (297mm) | 595pt (210mm) | Wide tables, presentations |

### Letter Example

| Orientation | Width | Height | Use Case |
|-------------|-------|--------|----------|
| **Portrait** | 612pt (8.5") | 792pt (11") | Standard documents (US) |
| **Landscape** | 792pt (11") | 612pt (8.5") | Presentations, wide content |

---

## 💡 When to Use Each Orientation

### Use Portrait For:
- ✅ Standard documents and reports
- ✅ Letters and correspondence
- ✅ Books and articles
- ✅ Invoices
- ✅ Resumes
- ✅ Most text-heavy content

### Use Landscape For:
- ✅ Wide tables with many columns
- ✅ Charts and graphs
- ✅ Presentations
- ✅ Spreadsheet-style data
- ✅ Timelines
- ✅ Gantt charts
- ✅ Certificates (sometimes)

---

## 🔧 Advanced Usage

### Getting Dimensions with Orientation

```csharp
using AlohaPDF.Core;

// Get dimensions for Portrait A4
var (widthP, heightP) = PageSizeInfo.GetDimensions(PageSize.A4, PageOrientation.Portrait);
Console.WriteLine($"Portrait A4: {widthP} × {heightP}");
// Output: "Portrait A4: 595 × 842"

// Get dimensions for Landscape A4
var (widthL, heightL) = PageSizeInfo.GetDimensions(PageSize.A4, PageOrientation.Landscape);
Console.WriteLine($"Landscape A4: {widthL} × {heightL}");
// Output: "Landscape A4: 842 × 595"  // Swapped!

// Individual dimensions
float width = PageSizeInfo.GetWidth(PageSize.A4, PageOrientation.Landscape);
float height = PageSizeInfo.GetHeight(PageSize.A4, PageOrientation.Landscape);
```

### Generate Both Orientations

```csharp
var orientations = new[] 
{ 
    PageOrientation.Portrait, 
    PageOrientation.Landscape 
};

foreach (var orientation in orientations)
{
    var pdf = new AlohaPdfDocument();
    
    pdf.Initialize(new PdfDocumentOptions
    {
        Title = $"Report - {orientation}",
        PageSize = PageSize.A4,
        Orientation = orientation
    });
    
    pdf.AddSection($"This is {orientation} format");
    
    pdf.Generate($"report-{orientation}.pdf");
}
```

---

## 📐 All Combinations

Every page size supports both orientations:

| Page Size | Portrait Dimensions | Landscape Dimensions |
|-----------|-------------------|---------------------|
| **A4** | 595 × 842 | 842 × 595 |
| **Letter** | 612 × 792 | 792 × 612 |
| **Legal** | 612 × 1008 | 1008 × 612 |
| **A3** | 842 × 1191 | 1191 × 842 |
| **A5** | 420 × 595 | 595 × 420 |
| **Tabloid** | 792 × 1224 | 1224 × 792 |
| **Executive** | 522 × 756 | 756 × 522 |
| **B4** | 709 × 1001 | 1001 × 709 |
| **B5** | 499 × 709 | 709 × 499 |

---

## 🎨 Design Considerations

### Content Adaptation
- **Headers/Footers**: Same height in both orientations
- **Margins**: Consistent across orientations
- **Text Wrapping**: Automatically adjusts to page width
- **Tables**: Utilize full available width

### Best Practices

**Portrait**:
```csharp
// Good for narrow tables
pdf.AddTable(
    headers: new[] { "Name", "Value", "Status" },  // 3 columns
    rows: data
);
```

**Landscape**:
```csharp
// Good for wide tables
pdf.AddTable(
    headers: new[] { "ID", "Name", "Q1", "Q2", "Q3", "Q4", "Total", "Growth", "Status" },  // 9 columns!
    rows: data
);
```

---

## 🔍 Example Output

### Portrait A4
```
┌─────────────────┐
│                 │  Width: 595 points (210mm)
│                 │  Height: 842 points (297mm)
│                 │  
│                 │  Perfect for:
│    Content      │  • Documents
│                 │  • Reports
│                 │  • Letters
│                 │
└─────────────────┘
```

### Landscape A4
```
┌───────────────────────────────┐
│                               │  Width: 842 points (297mm)
│         Content               │  Height: 595 points (210mm)
│                               │  
└───────────────────────────────┘  Perfect for:
                                   • Wide tables
                                   • Presentations
                                   • Charts
```

---

## ⚠️ Important Notes

1. **Automatic Swap**: AlohaPDF automatically swaps width/height for Landscape
2. **Default**: If not specified, Portrait is used
3. **Thread-Safe**: Each document instance has its own orientation
4. **Content Adapts**: All elements automatically adjust to orientation

---

## 🧪 Testing Different Orientations

Run the included demo:

```bash
cd samples
dotnet run OrientationDemo.cs
```

This generates:
- `AlohaPDF-Portrait.pdf` - A4 in Portrait
- `AlohaPDF-Landscape.pdf` - A4 in Landscape
- `AlohaPDF-Letter-Landscape.pdf` - US Letter in Landscape

---

## 📚 Complete Example

```csharp
using AlohaPDF;
using AlohaPDF.Core;

// Create a landscape report for wide tables
var pdf = new AlohaPdfDocument();

pdf.Initialize(new PdfDocumentOptions
{
    Title = "Q4 Sales Report",
    Subtitle = "Wide Format for Better Visualization",
    PageSize = PageSize.A4,
    Orientation = PageOrientation.Landscape,  // 👈 Landscape!
    Info = new DocumentInfo
    {
        Author = "Sales Team",
        CreatedDate = DateTime.Now
    }
});

pdf
    .AddSection("Quarterly Performance")
    .AddTable(
        headers: new[] { "Region", "Q1", "Q2", "Q3", "Q4", "Total", "Growth", "Target", "Status" },
        rows: new[]
        {
            new[] { "North", "$100K", "$120K", "$145K", "$160K", "$525K", "+60%", "$500K", "✓" },
            new[] { "South", "$90K", "$110K", "$130K", "$155K", "$485K", "+72%", "$450K", "✓" },
            new[] { "East", "$85K", "$105K", "$125K", "$150K", "$465K", "+76%", "$440K", "✓" },
            new[] { "West", "$95K", "$115K", "$140K", "$165K", "$515K", "+74%", "$490K", "✓" }
        },
        headerStyle: TableHeaderStyle.Primary
    );

pdf.Generate("quarterly-report-landscape.pdf");
```

---

## 📖 See Also

- [PAGESIZE_GUIDE.md](PAGESIZE_GUIDE.md) - Page size documentation
- [README.md](README.md) - Main documentation
- [ARCHITECTURE.md](ARCHITECTURE.md) - Architecture overview

---

*Made with 🌺 Aloha Spirit - Flexible orientations for every need!*
