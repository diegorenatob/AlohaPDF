using AlohaPDF;
using AlohaPDF.Core;
using AlohaPDF.Styling;
using FluentAssertions;

namespace AlohaPDF.Tests;

[TestFixture]
public class IntegrationTests
{
    private string _testOutputDirectory = null!;

    [SetUp]
    public void SetUp()
    {
        _testOutputDirectory = Path.Combine(Path.GetTempPath(), "AlohaPDF_Tests", Guid.NewGuid().ToString());
        Directory.CreateDirectory(_testOutputDirectory);
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up test files
        if (Directory.Exists(_testOutputDirectory))
        {
            try
            {
                Directory.Delete(_testOutputDirectory, recursive: true);
            }
            catch
            {
                // Ignore cleanup errors
            }
        }
    }

    [Test]
    public void Generate_SimpleDocument_ShouldCreatePdfFile()
    {
        // Arrange
        var pdf = new AlohaPdfDocument();
        var options = new PdfDocumentOptions
        {
            Title = "Integration Test Document",
            Subtitle = "Simple Test",
            PageSize = PageSize.A4,
            Orientation = PageOrientation.Portrait
        };

        var outputPath = Path.Combine(_testOutputDirectory, "simple_test.pdf");

        // Act
        pdf.Initialize(options);
        pdf.AddSection("Test Section")
           .AddParagraph("This is a test paragraph.");

        pdf.Generate(outputPath);

        // Assert
        File.Exists(outputPath).Should().BeTrue();
        new FileInfo(outputPath).Length.Should().BeGreaterThan(0);
    }

    [Test]
    public void Generate_DocumentWithAllElements_ShouldCreatePdfFile()
    {
        // Arrange
        var pdf = new AlohaPdfDocument();
        var options = new PdfDocumentOptions
        {
            Title = "Complete Test Document",
            Subtitle = "All Elements",
            PageSize = PageSize.A4,
            Orientation = PageOrientation.Portrait,
            Info = new DocumentInfo
            {
                Author = "Test Author",
                CreatedDate = DateTime.Now,
                ShowInHeader = true
            }
        };

        var outputPath = Path.Combine(_testOutputDirectory, "complete_test.pdf");

        // Act
        pdf.Initialize(options);
        pdf.AddSection("Introduction", pill: true)
           .AddParagraph("This document contains all element types.", lineHeight: 2f)
           .AddSpace(PdfLayout.SpaceLg)
           .AddSection("Lists")
           .AddList(new[] { "Item 1", "Item 2", "Item 3" }, isNumbered: true)
           .AddSpace(PdfLayout.SpaceMd)
           .AddSection("Tables")
           .AddTable(
               headers: new[] { "Column1", "Column2", "Column3" },
               rows: new[]
               {
                   new[] { "Value1", "Value2", "Value3" },
                   new[] { "Value4", "Value5", "Value6" }
               },
               alternateRows: true,
               headerStyle: TableHeaderStyle.Primary
           )
           .AddSpace(PdfLayout.SpaceLg)
           .AddLine()
           .AddBlankSpace(2)
           .AddSubtitle("Conclusion")
           .AddParagraph("This concludes the test document.", isBold: true);

        pdf.Generate(outputPath);

        // Assert
        File.Exists(outputPath).Should().BeTrue();
        new FileInfo(outputPath).Length.Should().BeGreaterThan(0);
    }

    [Test]
    public void Generate_LandscapeDocument_ShouldCreatePdfFile()
    {
        // Arrange
        var pdf = new AlohaPdfDocument();
        var options = new PdfDocumentOptions
        {
            Title = "Landscape Test",
            PageSize = PageSize.A4,
            Orientation = PageOrientation.Landscape
        };

        var outputPath = Path.Combine(_testOutputDirectory, "landscape_test.pdf");

        // Act
        pdf.Initialize(options);
        pdf.AddSection("Landscape Test")
           .AddParagraph("This document uses landscape orientation.");

        pdf.Generate(outputPath);

        // Assert
        File.Exists(outputPath).Should().BeTrue();
    }

    [Test]
    public void Generate_LetterSizeDocument_ShouldCreatePdfFile()
    {
        // Arrange
        var pdf = new AlohaPdfDocument();
        var options = new PdfDocumentOptions
        {
            Title = "Letter Size Test",
            PageSize = PageSize.Letter,
            Orientation = PageOrientation.Portrait
        };

        var outputPath = Path.Combine(_testOutputDirectory, "letter_test.pdf");

        // Act
        pdf.Initialize(options);
        pdf.AddSection("Letter Size Test")
           .AddParagraph("This document uses letter size paper.");

        pdf.Generate(outputPath);

        // Assert
        File.Exists(outputPath).Should().BeTrue();
    }

    [Test]
    public void Generate_DocumentWithMultipleSections_ShouldIncrementSectionNumbers()
    {
        // Arrange
        var pdf = new AlohaPdfDocument();
        var options = new PdfDocumentOptions
        {
            Title = "Multiple Sections Test",
            PageSize = PageSize.A4
        };

        var outputPath = Path.Combine(_testOutputDirectory, "sections_test.pdf");

        // Act
        pdf.Initialize(options);
        pdf.AddSection("First Section")
           .AddParagraph("Content of first section.")
           .AddSection("Second Section")
           .AddParagraph("Content of second section.")
           .AddSection("Third Section")
           .AddParagraph("Content of third section.");

        pdf.Generate(outputPath);

        // Assert
        File.Exists(outputPath).Should().BeTrue();
        pdf.SectionCounter.Should().Be(0); // Should be reset after generation
    }

    [Test]
    public void Generate_DocumentWithStyledElements_ShouldCreatePdfFile()
    {
        // Arrange
        var pdf = new AlohaPdfDocument();
        var options = new PdfDocumentOptions
        {
            Title = "Styled Elements Test",
            PageSize = PageSize.A4
        };

        var outputPath = Path.Combine(_testOutputDirectory, "styled_test.pdf");

        // Act
        pdf.Initialize(options);
        pdf.AddStyledList(
               title: "Action Items",
               items: new[] { "Task 1", "Task 2", "Task 3" },
               baseNumber: 1
           )
           .AddStyledItem(
               title: "Important Note",
               text: "This is an important note with styling.",
               number: "1"
           );

        pdf.Generate(outputPath);

        // Assert
        File.Exists(outputPath).Should().BeTrue();
    }

    [Test]
    public void Generate_DocumentWithSubtitleAndSummary_ShouldCreatePdfFile()
    {
        // Arrange
        var pdf = new AlohaPdfDocument();
        var options = new PdfDocumentOptions
        {
            Title = "Summary Test",
            PageSize = PageSize.A4
        };

        var outputPath = Path.Combine(_testOutputDirectory, "summary_test.pdf");

        // Act
        pdf.Initialize(options);
        pdf.AddSubtitleWithSummary(
               text: "Revenue Report",
               summaryText: "Total:",
               summaryValue: "$125,000",
               pill: true
           );

        pdf.Generate(outputPath);

        // Assert
        File.Exists(outputPath).Should().BeTrue();
    }

    [Test]
    public void Generate_EmptyDocument_ShouldCreatePdfFile()
    {
        // Arrange
        var pdf = new AlohaPdfDocument();
        var options = new PdfDocumentOptions
        {
            Title = "Empty Document Test",
            PageSize = PageSize.A4
        };

        var outputPath = Path.Combine(_testOutputDirectory, "empty_test.pdf");

        // Act
        pdf.Initialize(options);
        pdf.Generate(outputPath);

        // Assert
        File.Exists(outputPath).Should().BeTrue();
    }

    [Test]
    public void Generate_ReinitializeAndGenerate_ShouldCreateNewDocument()
    {
        // Arrange
        var pdf = new AlohaPdfDocument();
        var options1 = new PdfDocumentOptions
        {
            Title = "First Document",
            PageSize = PageSize.A4
        };
        var options2 = new PdfDocumentOptions
        {
            Title = "Second Document",
            PageSize = PageSize.Letter
        };

        var outputPath1 = Path.Combine(_testOutputDirectory, "first_doc.pdf");
        var outputPath2 = Path.Combine(_testOutputDirectory, "second_doc.pdf");

        // Act
        pdf.Initialize(options1);
        pdf.AddSection("First Document Section");
        pdf.Generate(outputPath1);

        pdf.Initialize(options2);
        pdf.AddSection("Second Document Section");
        pdf.Generate(outputPath2);

        // Assert
        File.Exists(outputPath1).Should().BeTrue();
        File.Exists(outputPath2).Should().BeTrue();
    }

    [Test]
    public void Generate_DocumentWithDifferentPageSizes_ShouldCreateValidPdfs()
    {
        // Arrange & Act & Assert for each page size
        var pageSizes = new[] { PageSize.A4, PageSize.A3, PageSize.A5, PageSize.Letter, PageSize.Legal };

        foreach (var pageSize in pageSizes)
        {
            var pdf = new AlohaPdfDocument();
            var options = new PdfDocumentOptions
            {
                Title = $"{pageSize} Test",
                PageSize = pageSize
            };

            var outputPath = Path.Combine(_testOutputDirectory, $"{pageSize}_test.pdf");

            pdf.Initialize(options);
            pdf.AddSection($"{pageSize} Document")
               .AddParagraph($"This document uses {pageSize} page size.");

            pdf.Generate(outputPath);

            File.Exists(outputPath).Should().BeTrue($"File for {pageSize} should be created");
        }
    }

    [Test]
    public void Generate_LargeTable_ShouldCreatePdfFile()
    {
        // Arrange
        var pdf = new AlohaPdfDocument();
        var options = new PdfDocumentOptions
        {
            Title = "Large Table Test",
            PageSize = PageSize.A4
        };

        var headers = new[] { "ID", "Name", "Value", "Status" };
        var rows = new List<string[]>();
        for (int i = 1; i <= 20; i++)
        {
            rows.Add(new[] { i.ToString(), $"Item {i}", $"${i * 100}", "Active" });
        }

        var outputPath = Path.Combine(_testOutputDirectory, "large_table_test.pdf");

        // Act
        pdf.Initialize(options);
        pdf.AddSection("Large Table Test")
           .AddTable(headers, rows, alternateRows: true);

        pdf.Generate(outputPath);

        // Assert
        File.Exists(outputPath).Should().BeTrue();
    }
}
