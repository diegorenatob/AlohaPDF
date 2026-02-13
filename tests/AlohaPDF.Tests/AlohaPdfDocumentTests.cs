using AlohaPDF;
using AlohaPDF.Core;
using FluentAssertions;

namespace AlohaPDF.Tests;

[TestFixture]
public class AlohaPdfDocumentTests
{
    private AlohaPdfDocument _document = null!;
    private PdfDocumentOptions _defaultOptions = null!;

    [SetUp]
    public void SetUp()
    {
        _document = new AlohaPdfDocument();
        _defaultOptions = new PdfDocumentOptions
        {
            Title = "Test Document",
            Subtitle = "Test Subtitle",
            PageSize = PageSize.A4,
            Orientation = PageOrientation.Portrait
        };
    }

    [TearDown]
    public void TearDown()
    {
        // Cleanup any generated test files if needed
    }

    [Test]
    public void Constructor_ShouldCreateInstance()
    {
        // Arrange & Act
        var document = new AlohaPdfDocument();

        // Assert
        document.Should().NotBeNull();
        document.SectionCounter.Should().Be(0);
    }

    [Test]
    public void Initialize_WithValidOptions_ShouldInitializeDocument()
    {
        // Act
        _document.Initialize(_defaultOptions);

        // Assert
        _document.SectionCounter.Should().Be(0);
    }

    [Test]
    public void Initialize_WithNullOptions_ShouldThrowArgumentNullException()
    {
        // Act
        Action act = () => _document.Initialize(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void AddSection_ShouldIncrementSectionCounter()
    {
        // Arrange
        _document.Initialize(_defaultOptions);

        // Act
        _document.AddSection("First Section");
        _document.AddSection("Second Section");

        // Assert
        _document.SectionCounter.Should().Be(2);
    }

    [Test]
    public void AddSection_WithoutInitialize_ShouldThrowInvalidOperationException()
    {
        // Act
        Action act = () => _document.AddSection("Section");

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Test]
    public void AddSection_ShouldReturnSameInstance()
    {
        // Arrange
        _document.Initialize(_defaultOptions);

        // Act
        var result = _document.AddSection("Test Section");

        // Assert
        result.Should().BeSameAs(_document);
    }

    [Test]
    public void AddSubtitle_ShouldReturnSameInstance()
    {
        // Arrange
        _document.Initialize(_defaultOptions);

        // Act
        var result = _document.AddSubtitle("Test Subtitle");

        // Assert
        result.Should().BeSameAs(_document);
    }

    [Test]
    public void AddParagraph_ShouldReturnSameInstance()
    {
        // Arrange
        _document.Initialize(_defaultOptions);

        // Act
        var result = _document.AddParagraph("Test paragraph text");

        // Assert
        result.Should().BeSameAs(_document);
    }

    [Test]
    public void AddLine_ShouldReturnSameInstance()
    {
        // Arrange
        _document.Initialize(_defaultOptions);

        // Act
        var result = _document.AddLine();

        // Assert
        result.Should().BeSameAs(_document);
    }

    [Test]
    public void AddBlankSpace_ShouldReturnSameInstance()
    {
        // Arrange
        _document.Initialize(_defaultOptions);

        // Act
        var result = _document.AddBlankSpace(2);

        // Assert
        result.Should().BeSameAs(_document);
    }

    [Test]
    public void AddSpace_ShouldReturnSameInstance()
    {
        // Arrange
        _document.Initialize(_defaultOptions);

        // Act
        var result = _document.AddSpace(24f);

        // Assert
        result.Should().BeSameAs(_document);
    }

    [Test]
    public void AddList_ShouldReturnSameInstance()
    {
        // Arrange
        _document.Initialize(_defaultOptions);
        var items = new[] { "Item 1", "Item 2", "Item 3" };

        // Act
        var result = _document.AddList(items);

        // Assert
        result.Should().BeSameAs(_document);
    }

    [Test]
    public void AddTable_ShouldReturnSameInstance()
    {
        // Arrange
        _document.Initialize(_defaultOptions);
        var headers = new[] { "Column1", "Column2" };
        var rows = new[] { new[] { "Value1", "Value2" } };

        // Act
        var result = _document.AddTable(headers, rows);

        // Assert
        result.Should().BeSameAs(_document);
    }

    [Test]
    public void FluentAPI_ShouldAllowMethodChaining()
    {
        // Arrange
        _document.Initialize(_defaultOptions);

        // Act
        Action act = () => _document
            .AddSection("Section 1")
            .AddParagraph("Paragraph text")
            .AddSpace(12f)
            .AddList(new[] { "Item 1", "Item 2" })
            .AddLine()
            .AddSection("Section 2");

        // Assert
        act.Should().NotThrow();
        _document.SectionCounter.Should().Be(2);
    }

    [Test]
    public void AddSubtitleWithSummary_ShouldReturnSameInstance()
    {
        // Arrange
        _document.Initialize(_defaultOptions);

        // Act
        var result = _document.AddSubtitleWithSummary("Revenue", "Total:", "$1,000");

        // Assert
        result.Should().BeSameAs(_document);
    }

    [Test]
    public void AddStyledList_ShouldReturnSameInstance()
    {
        // Arrange
        _document.Initialize(_defaultOptions);
        var items = new[] { "Item 1", "Item 2" };

        // Act
        var result = _document.AddStyledList("List Title", items);

        // Assert
        result.Should().BeSameAs(_document);
    }

    [Test]
    public void AddStyledItem_ShouldReturnSameInstance()
    {
        // Arrange
        _document.Initialize(_defaultOptions);

        // Act
        var result = _document.AddStyledItem("Item Title", "Item text");

        // Assert
        result.Should().BeSameAs(_document);
    }

    [Test]
    public void SectionCounter_ShouldStartAtZero()
    {
        // Arrange
        _document.Initialize(_defaultOptions);

        // Assert
        _document.SectionCounter.Should().Be(0);
    }

    [Test]
    public void Initialize_CalledTwice_ShouldResetSectionCounter()
    {
        // Arrange
        _document.Initialize(_defaultOptions);
        _document.AddSection("Section 1");

        // Act
        _document.Initialize(_defaultOptions);

        // Assert
        _document.SectionCounter.Should().Be(0);
    }

    [Test]
    public void Generate_WithoutInitialize_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var outputPath = Path.Combine(Path.GetTempPath(), "test.pdf");

        // Act
        Action act = () => _document.Generate(outputPath);

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Test]
    public void AddParagraph_WithAllParameters_ShouldNotThrow()
    {
        // Arrange
        _document.Initialize(_defaultOptions);

        // Act
        Action act = () => _document.AddParagraph(
            text: "Test paragraph",
            lineHeight: 2f,
            isBold: true,
            leftMargin: 24f
        );

        // Assert
        act.Should().NotThrow();
    }

    [Test]
    public void AddList_WithAllParameters_ShouldNotThrow()
    {
        // Arrange
        _document.Initialize(_defaultOptions);
        var items = new[] { "Item 1", "Item 2" };

        // Act
        Action act = () => _document.AddList(
            items: items,
            useMonospace: true,
            withMargin: true,
            isNumbered: true,
            alternateRows: true,
            customPrefix: "→"
        );

        // Assert
        act.Should().NotThrow();
    }

    [Test]
    public void AddTable_WithAllParameters_ShouldNotThrow()
    {
        // Arrange
        _document.Initialize(_defaultOptions);
        var headers = new[] { "Column1", "Column2" };
        var rows = new[] { new[] { "Value1", "Value2" } };

        // Act
        Action act = () => _document.AddTable(
            headers: headers,
            rows: rows,
            alternateRows: true,
            headerStyle: TableHeaderStyle.Primary,
            leftMargin: 10f,
            rightMargin: 10f,
            repeatHeadersOnPageBreak: true
        );

        // Assert
        act.Should().NotThrow();
    }
}
