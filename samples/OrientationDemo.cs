using AlohaPDF;
using AlohaPDF.Core;
using AlohaPDF.Styling;

Console.WriteLine("🌺 AlohaPDF - Orientation Demo");
Console.WriteLine("================================\n");

try
{
    // Demo 1: Portrait A4
    Console.WriteLine("📄 Generating Portrait A4...");
    var pdfPortrait = new AlohaPdfDocument();
    
    pdfPortrait.Initialize(new PdfDocumentOptions
    {
        Title = "Portrait Demo",
        Subtitle = "A4 in Portrait Orientation",
        PageSize = PageSize.A4,
        Orientation = PageOrientation.Portrait,
        Info = new DocumentInfo
        {
            Author = "AlohaPDF Demo",
            CreatedDate = DateTime.Now
        }
    });

    var dimensionsPortrait = PageSizeInfo.GetDimensions(PageSize.A4, PageOrientation.Portrait);
    
    pdfPortrait
        .AddSection("📱 Portrait Orientation", pill: true)
        .AddParagraph($"This document is in Portrait orientation (vertical).", lineHeight: 2f)
        .AddTable(
            headers: new[] { "Property", "Value" },
            rows: new[]
            {
                new[] { "Page Size", "A4" },
                new[] { "Orientation", "Portrait" },
                new[] { "Width", dimensionsPortrait.Width.ToString("F2") + " points" },
                new[] { "Height", dimensionsPortrait.Height.ToString("F2") + " points" },
                new[] { "Aspect", "Vertical (Height > Width)" }
            },
            headerStyle: TableHeaderStyle.Primary
        );

    var portraitFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AlohaPDF-Portrait.pdf");
    pdfPortrait.Generate(portraitFile);
    Console.WriteLine($"   ✅ Generated: {portraitFile}\n");

    // Demo 2: Landscape A4
    Console.WriteLine("📄 Generating Landscape A4...");
    var pdfLandscape = new AlohaPdfDocument();
    
    pdfLandscape.Initialize(new PdfDocumentOptions
    {
        Title = "Landscape Demo",
        Subtitle = "A4 in Landscape Orientation",
        PageSize = PageSize.A4,
        Orientation = PageOrientation.Landscape,  // 👈 Landscape!
        Info = new DocumentInfo
        {
            Author = "AlohaPDF Demo",
            CreatedDate = DateTime.Now
        }
    });

    var dimensionsLandscape = PageSizeInfo.GetDimensions(PageSize.A4, PageOrientation.Landscape);
    
    pdfLandscape
        .AddSection("🖥️ Landscape Orientation", pill: true)
        .AddParagraph($"This document is in Landscape orientation (horizontal). Perfect for wide tables and charts!", lineHeight: 2f)
        .AddTable(
            headers: new[] { "Property", "Value" },
            rows: new[]
            {
                new[] { "Page Size", "A4" },
                new[] { "Orientation", "Landscape" },
                new[] { "Width", dimensionsLandscape.Width.ToString("F2") + " points" },
                new[] { "Height", dimensionsLandscape.Height.ToString("F2") + " points" },
                new[] { "Aspect", "Horizontal (Width > Height)" },
                new[] { "Note", "Width and Height are swapped from Portrait!" }
            },
            headerStyle: TableHeaderStyle.Secondary
        )
        .AddSpace(PdfLayout.SpaceLg)
        .AddSection("📊 Wide Table Example")
        .AddTable(
            headers: new[] { "Q1", "Q2", "Q3", "Q4", "Total", "Growth", "Status" },
            rows: new[]
            {
                new[] { "$100K", "$120K", "$145K", "$160K", "$525K", "+60%", "🌺 Excellent" },
                new[] { "$90K", "$110K", "$130K", "$155K", "$485K", "+72%", "🌺 Excellent" }
            },
            alternateRows: true,
            headerStyle: TableHeaderStyle.Primary
        );

    var landscapeFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AlohaPDF-Landscape.pdf");
    pdfLandscape.Generate(landscapeFile);
    Console.WriteLine($"   ✅ Generated: {landscapeFile}\n");

    // Demo 3: Letter Landscape (US format)
    Console.WriteLine("📄 Generating Letter Landscape...");
    var pdfLetterLandscape = new AlohaPdfDocument();
    
    pdfLetterLandscape.Initialize(new PdfDocumentOptions
    {
        Title = "Letter Landscape Demo",
        Subtitle = "US Letter in Landscape",
        PageSize = PageSize.Letter,
        Orientation = PageOrientation.Landscape,
        Info = new DocumentInfo
        {
            Author = "AlohaPDF Demo",
            CreatedDate = DateTime.Now
        }
    });

    pdfLetterLandscape
        .AddSection("🇺🇸 Letter Landscape", pill: true)
        .AddParagraph("Perfect for presentations and wide content in North America!", lineHeight: 2f)
        .AddList(
            items: new[]
            {
                "Landscape is great for presentations",
                "Wide tables fit better horizontally",
                "Charts and graphs display better",
                "Perfect for spreadsheet-style content"
            },
            isNumbered: true
        );

    var letterLandscapeFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AlohaPDF-Letter-Landscape.pdf");
    pdfLetterLandscape.Generate(letterLandscapeFile);
    Console.WriteLine($"   ✅ Generated: {letterLandscapeFile}\n");

    Console.WriteLine("🎉 All orientation demos generated successfully!");
    Console.WriteLine("\n🌺 Mahalo for using AlohaPDF!");
    Console.WriteLine("\nCompare the PDFs to see the difference between Portrait and Landscape!");
}
catch (Exception ex)
{
    Console.WriteLine($"\n❌ Error: {ex.Message}");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
