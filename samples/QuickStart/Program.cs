using AlohaPDF;
using AlohaPDF.Core;
using AlohaPDF.Styling;

Console.WriteLine("🌺 AlohaPDF - Quick Start Example");
Console.WriteLine("==================================\n");

try
{
    var pdf = new AlohaPdfDocument();

    var options = new PdfDocumentOptions
    {
        Title = "Aloha Sales Report",
        Subtitle = "Q1 2025 - Created with Aloha Spirit",
        PageSize = PageSize.A4,  // Can be: A4, Letter, Legal, A3, A5, Tabloid, Executive, B4, B5
        Info = new DocumentInfo
        {
            Author = "Jane Smith",
            CreatedDate = DateTime.Now,
            ShowInHeader = true  // Simple one-line format: "Jane Smith • Created on Feb 11, 2025"
        },
        RepeatHeader = true
    };

    Console.WriteLine("✓ Initializing PDF with Aloha spirit...");
    pdf.Initialize(options);

    Console.WriteLine("✓ Adding tropical content...");
    
    pdf
        .AddSection("🌴 Executive Summary", pill: true)
        .AddParagraph(
            "Welcome to our Q1 2025 performance report, created with AlohaPDF! " +
            "We achieved outstanding growth across all metrics with the Aloha spirit guiding us.",
            lineHeight: 2f
        )
        .AddSpace(PdfLayout.SpaceLg)
        
        .AddSection("📊 Key Performance Indicators")
        .AddTable(
            headers: new[] { "Metric", "Target", "Actual", "Variance", "Status" },
            rows: new[]
            {
                new[] { "Revenue", "$100K", "$125K", "+25%", "🌺 Excellent" },
                new[] { "New Customers", "500", "632", "+26.4%", "🌺 Excellent" },
                new[] { "Customer Satisfaction", "4.5/5", "4.8/5", "+6.7%", "🌺 Excellent" },
                new[] { "Retention Rate", "85%", "91%", "+7.1%", "🌺 Excellent" },
                new[] { "Support Response", "< 24h", "18h", "+25%", "🌺 Excellent" }
            },
            alternateRows: true,
            headerStyle: TableHeaderStyle.Primary  // Tropical coral header
        )
        .AddSpace(PdfLayout.SpaceLg)
        
        .AddSection("🏝️ Regional Paradise")
        .AddSubtitleWithSummary("Revenue by Region", "Total:", "$125,000", pill: true)
        .AddTable(
            headers: new[] { "Region", "Sales", "Growth", "Share" },
            rows: new[]
            {
                new[] { "Pacific Islands", "$62,500", "+28%", "50%" },
                new[] { "Tropical Americas", "$37,500", "+22%", "30%" },
                new[] { "Asia-Pacific", "$18,750", "+18%", "15%" },
                new[] { "Caribbean", "$6,250", "+15%", "5%" }
            },
            alternateRows: true,
            headerStyle: TableHeaderStyle.Secondary  // Ocean blue header
        )
        .AddSpace(PdfLayout.SpaceLg)
        
        .AddSection("🌊 Top Products")
        .AddList(
            items: new[]
            {
                "Tropical Breeze Widget - $45,000 (36%)",
                "Ocean Wave Solution - $38,000 (30.4%)",
                "Palm Paradise Suite - $25,000 (20%)",
                "Aloha Essentials Kit - $17,000 (13.6%)"
            },
            isNumbered: true,
            alternateRows: true
        )
        .AddSpace(PdfLayout.SpaceLg)
        
        .AddSection("🎯 Q2 Action Items")
        .AddStyledList(
            title: "Strategic Initiatives with Aloha Spirit",
            items: new[]
            {
                "Expand to new tropical markets",
                "Launch customer appreciation program",
                "Implement island-time work-life balance",
                "Increase team wellness activities",
                "Develop eco-friendly product line"
            },
            baseNumber: 1
        )
        .AddSpace(PdfLayout.SpaceLg)
        
        .AddSection("🌺 Mahalo & Conclusion")
        .AddParagraph(
            "Q1 2025 was our best quarter yet! With the Aloha spirit in everything we do, " +
            "we're positioned for continued success. Mahalo (thank you) to our amazing team!",
            lineHeight: 2f,
            isBold: true
        );

    var outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"AlohaPDF-{DateTime.Now:yyyyMMdd-HHmmss}.pdf");
    
    Console.WriteLine($"\n✓ Generating PDF with Aloha vibes: {outputPath}");
    pdf.Generate(outputPath);

    Console.WriteLine("\n🌺 PDF generated successfully with Aloha spirit!");
    Console.WriteLine($"   Location: {outputPath}");
    Console.WriteLine("\n   Open the file to experience the tropical magic!");
    Console.WriteLine("\n🏝️ Mahalo for using AlohaPDF - Create PDFs with joy!");
}
catch (Exception ex)
{
    Console.WriteLine($"\n❌ Oops! Something went wrong: {ex.Message}");
    Console.WriteLine($"   {ex.StackTrace}");
}

Console.WriteLine("\n🌴 Press any key to exit... Aloha!");
Console.ReadKey();
