using AlohaPDF;
using AlohaPDF.Core;
using AlohaPDF.Styling;

Console.WriteLine("🌺 AlohaPDF - Page Size Demo");
Console.WriteLine("=============================\n");

try
{
    // Test different page sizes
    var pageSizes = new[] 
    { 
        PageSize.A4, 
        PageSize.Letter, 
        PageSize.A3, 
        PageSize.Legal 
    };

    foreach (var pageSize in pageSizes)
    {
        var pdf = new AlohaPdfDocument();

        var dimensions = PageSizeInfo.GetDimensions(pageSize);
        var description = PageSizeInfo.GetDescription(pageSize);
        var usage = PageSizeInfo.GetUsage(pageSize);

        Console.WriteLine($"📄 Generating {pageSize} PDF...");
        Console.WriteLine($"   Size: {description}");
        Console.WriteLine($"   Usage: {usage}");
        Console.WriteLine($"   Dimensions: {dimensions.Width:F2} × {dimensions.Height:F2} points");

        var options = new PdfDocumentOptions
        {
            Title = $"AlohaPDF - {pageSize} Demo",
            Subtitle = $"Page Size: {description}",
            PageSize = pageSize,
            Info = new DocumentInfo
            {
                Author = "AlohaPDF Demo",
                CreatedDate = DateTime.Now
            }
        };

        pdf.Initialize(options);

        pdf
            .AddSection($"🌴 {pageSize} Page Size Demo", pill: true)
            .AddParagraph(
                $"This document demonstrates the {pageSize} page size. " +
                $"Dimensions: {dimensions.Width:F2} × {dimensions.Height:F2} points. " +
                $"{usage}",
                lineHeight: 2f
            )
            .AddSpace(PdfLayout.SpaceLg)
            
            .AddSection("Page Size Information")
            .AddTable(
                headers: new[] { "Property", "Value" },
                rows: new[]
                {
                    new[] { "Page Size", pageSize.ToString() },
                    new[] { "Width (points)", dimensions.Width.ToString("F2") },
                    new[] { "Height (points)", dimensions.Height.ToString("F2") },
                    new[] { "Width (inches)", (dimensions.Width / 72f).ToString("F2") + "\"" },
                    new[] { "Height (inches)", (dimensions.Height / 72f).ToString("F2") + "\"" },
                    new[] { "Width (mm)", (dimensions.Width / 72f * 25.4f).ToString("F2") + "mm" },
                    new[] { "Height (mm)", (dimensions.Height / 72f * 25.4f).ToString("F2") + "mm" },
                    new[] { "Usage", usage }
                },
                alternateRows: true,
                headerStyle: TableHeaderStyle.Primary
            )
            .AddSpace(PdfLayout.SpaceLg)
            
            .AddSection("📊 Sample Content")
            .AddList(
                items: new[]
                {
                    "This is a bullet point in " + pageSize + " format",
                    "Page margins adapt to the page size",
                    "Content automatically adjusts",
                    "Headers and footers scale appropriately"
                },
                isNumbered: true
            );

        var fileName = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), 
            $"AlohaPDF-{pageSize}-Demo.pdf"
        );

        pdf.Generate(fileName);
        Console.WriteLine($"   ✅ Generated: {fileName}\n");
    }

    Console.WriteLine("🎉 All page size demos generated successfully!");
    Console.WriteLine("\n🌺 Mahalo for using AlohaPDF!");
}
catch (Exception ex)
{
    Console.WriteLine($"\n❌ Error: {ex.Message}");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
