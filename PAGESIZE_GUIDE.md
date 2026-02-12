# 📄 AlohaPDF - Page Size Support

## 🎯 Overview

AlohaPDF now supports **9 standard page sizes** including ISO A-series, B-series, and North American formats. You can easily configure the page size when creating your PDF document.

---

## 📐 Supported Page Sizes

### ISO A-Series (International)

| Size | Dimensions (mm) | Dimensions (inches) | Points | Common Use |
|------|----------------|---------------------|--------|------------|
| **A4** | 210 × 297 | 8.27" × 11.69" | 595 × 842 | Most common worldwide |
| **A3** | 297 × 420 | 11.69" × 16.54" | 842 × 1191 | Large prints, posters |
| **A5** | 148 × 210 | 5.83" × 8.27" | 420 × 595 | Small books, notepads |

### ISO B-Series (Asia)

| Size | Dimensions (mm) | Dimensions (inches) | Points | Common Use |
|------|----------------|---------------------|--------|------------|
| **B4** | 250 × 353 | 9.84" × 13.90" | 709 × 1001 | Between A3 and A4 |
| **B5** | 176 × 250 | 6.93" × 9.84" | 499 × 709 | Between A4 and A5 |

### North American

| Size | Dimensions (inches) | Dimensions (mm) | Points | Common Use |
|------|---------------------|----------------|--------|------------|
| **Letter** | 8.5" × 11" | 215.9 × 279.4 | 612 × 792 | Standard in USA/Canada |
| **Legal** | 8.5" × 14" | 215.9 × 355.6 | 612 × 1008 | Legal documents (USA) |
| **Tabloid** | 11" × 17" | 279.4 × 431.8 | 792 × 1224 | Large prints |
| **Executive** | 7.25" × 10.5" | 184.15 × 266.7 | 522 × 756 | Personal stationery |

---

## 🚀 Usage

### Basic Usage

```csharp
using AlohaPDF;
using AlohaPDF.Core;

var pdf = new AlohaPdfDocument();

var options = new PdfDocumentOptions
{
    Title = "My Report",
    Subtitle = "Created with AlohaPDF",
    PageSize = PageSize.A4,  // 👈 Specify page size here
    Info = new DocumentInfo
    {
        Author = "John Doe",
        CreatedDate = DateTime.Now
    }
};

pdf.Initialize(options);

pdf
    .AddSection("Introduction")
    .AddParagraph("This is an A4 document...");

pdf.Generate("report-a4.pdf");
```

### Using Different Sizes

```csharp
// A4 - International standard
var optionsA4 = new PdfDocumentOptions 
{ 
    PageSize = PageSize.A4  // 210mm × 297mm
};

// Letter - US standard
var optionsLetter = new PdfDocumentOptions 
{ 
    PageSize = PageSize.Letter  // 8.5" × 11"
};

// A3 - Large format
var optionsA3 = new PdfDocumentOptions 
{ 
    PageSize = PageSize.A3  // 297mm × 420mm
};

// Legal - US legal documents
var optionsLegal = new PdfDocumentOptions 
{ 
    PageSize = PageSize.Legal  // 8.5" × 14"
};
```

---

## 🔧 Advanced Usage

### Getting Page Size Information

```csharp
using AlohaPDF.Core;

// Get dimensions
var (width, height) = PageSizeInfo.GetDimensions(PageSize.A4);
Console.WriteLine($"A4 size: {width} × {height} points");

// Get description
var description = PageSizeInfo.GetDescription(PageSize.Letter);
Console.WriteLine(description);
// Output: "Letter (8.5" × 11" / 215.9mm × 279.4mm)"

// Get usage info
var usage = PageSizeInfo.GetUsage(PageSize.A3);
Console.WriteLine(usage);
// Output: "Large prints, posters, international"

// Get individual dimensions
float width = PageSizeInfo.GetWidth(PageSize.A4);
float height = PageSizeInfo.GetHeight(PageSize.A4);
```

### Generate Multiple Sizes

```csharp
var pageSizes = new[] 
{ 
    PageSize.A4, 
    PageSize.Letter, 
    PageSize.A3 
};

foreach (var pageSize in pageSizes)
{
    var pdf = new AlohaPdfDocument();
    
    pdf.Initialize(new PdfDocumentOptions
    {
        Title = $"Report - {pageSize}",
        PageSize = pageSize
    });
    
    pdf.AddSection($"This is {pageSize} format");
    
    pdf.Generate($"report-{pageSize}.pdf");
}
```

---

## 💡 Recommendations

### When to Use Each Size

**A4** (Default)
- ✅ International business documents
- ✅ Reports and presentations
- ✅ Most versatile option

**Letter**
- ✅ US/Canada business documents
- ✅ Resumes and cover letters
- ✅ Office correspondence

**Legal**
- ✅ Legal contracts (USA)
- ✅ Government forms
- ✅ Longer documents

**A3**
- ✅ Posters and charts
- ✅ Large diagrams
- ✅ Architectural drawings

**A5**
- ✅ Brochures and flyers
- ✅ Notebooks
- ✅ Compact reports

**Tabloid**
- ✅ Newspapers
- ✅ Large presentations
- ✅ Posters (US)

---

## 🔄 How It Works

1. **Configure**: Set `PageSize` in `PdfDocumentOptions`
2. **Initialize**: AlohaPDF sets up the page dimensions
3. **Automatic**: All content adapts to the page size
4. **Generate**: PDF created with correct dimensions

### Behind the Scenes

```csharp
// When you initialize:
pdf.Initialize(options);

// AlohaPDF does:
PdfLayout.SetPageSize(options.PageSize);  // 👈 Sets dimensions
// Now PdfLayout.PageWidth and PageHeight are updated

// All elements use these values:
float availableWidth = PdfLayout.PageWidth - (2 * margin);
```

---

## 📊 Comparison Table

| Feature | A4 | Letter | A3 | Legal |
|---------|----|----|----|----|
| **Width** | 210mm | 216mm | 297mm | 216mm |
| **Height** | 297mm | 279mm | 420mm | 356mm |
| **Ratio** | 1:√2 | 1:1.29 | 1:√2 | 1:1.65 |
| **Region** | Global | Americas | Global | USA |
| **Use Case** | General | Business | Large | Legal |

---

## 🎨 Design Considerations

### Margins
- Margins are **consistent** across all page sizes
- Default: 48 points (~17mm)
- Customizable via `PdfDocumentOptions.PageMargin`

### Headers & Footers
- **Automatically scaled** to page size
- Same height across all sizes
- Content adapts to available width

### Content
- **Word wrapping** adjusts to page width
- **Tables** scale to fit
- **Images** respect page boundaries

---

## 🔍 Example Output

### A4 Document
```
Width:  595 points (210mm / 8.27")
Height: 842 points (297mm / 11.69")
Aspect Ratio: 1:1.414 (1:√2)
```

### Letter Document
```
Width:  612 points (8.5")
Height: 792 points (11")
Aspect Ratio: 1:1.294
```

### A3 Document
```
Width:  842 points (297mm / 11.69")
Height: 1191 points (420mm / 16.54")
Aspect Ratio: 1:1.414 (1:√2)
```

---

## ⚠️ Important Notes

1. **Default is A4**: If you don't specify `PageSize`, A4 is used
2. **Thread-safe**: Each document instance has its own page size
3. **Reset**: Page size resets to A4 after `Generate()` completes
4. **Points**: All dimensions internally use points (1 point = 1/72 inch)

---

## 🧪 Testing Different Sizes

Run the included demo to see all sizes in action:

```bash
cd samples/QuickStart
dotnet run PageSizeDemo.cs
```

This generates PDFs for A4, Letter, A3, and Legal with detailed size information.

---

## 📚 See Also

- [README.md](../README.md) - Main documentation
- [ARCHITECTURE.md](ARCHITECTURE.md) - Architecture overview
- [QuickStart Example](samples/QuickStart/Program.cs) - Basic usage

---

*Made with 🌺 Aloha Spirit - Flexible page sizes for global reach!*
