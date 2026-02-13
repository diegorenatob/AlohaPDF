using AlohaPDF.Core;
using FluentAssertions;

namespace AlohaPDF.Tests.Core;

[TestFixture]
public class PdfDocumentOptionsTests
{
    [Test]
    public void Constructor_ShouldInitializeWithDefaults()
    {
        // Act
        var options = new PdfDocumentOptions();

        // Assert
        options.Title.Should().BeEmpty();
        options.Subtitle.Should().BeEmpty();
        options.Info.Should().BeNull();
        options.RepeatHeader.Should().BeTrue();
        options.HeaderLogo.Should().BeNull();
        options.FooterLogo.Should().BeNull();
        options.Fonts.Should().BeNull();
        options.PageSize.Should().Be(PageSize.A4);
        options.Orientation.Should().Be(PageOrientation.Portrait);
    }

    [Test]
    public void Title_ShouldSetAndGetValue()
    {
        // Arrange
        var options = new PdfDocumentOptions();
        var title = "Aloha Sales Report";

        // Act
        options.Title = title;

        // Assert
        options.Title.Should().Be(title);
    }

    [Test]
    public void Subtitle_ShouldSetAndGetValue()
    {
        // Arrange
        var options = new PdfDocumentOptions();
        var subtitle = "Q1 2025 Report";

        // Act
        options.Subtitle = subtitle;

        // Assert
        options.Subtitle.Should().Be(subtitle);
    }

    [Test]
    public void Info_ShouldSetAndGetValue()
    {
        // Arrange
        var options = new PdfDocumentOptions();
        var info = new DocumentInfo
        {
            Author = "Jane Smith",
            CreatedDate = new DateTime(2025, 1, 1)
        };

        // Act
        options.Info = info;

        // Assert
        options.Info.Should().NotBeNull();
        options.Info!.Author.Should().Be("Jane Smith");
        options.Info.CreatedDate.Should().Be(new DateTime(2025, 1, 1));
    }

    [Test]
    public void RepeatHeader_ShouldSetAndGetValue()
    {
        // Arrange
        var options = new PdfDocumentOptions();

        // Act
        options.RepeatHeader = false;

        // Assert
        options.RepeatHeader.Should().BeFalse();
    }

    [Test]
    public void PageSize_ShouldSetAndGetValue()
    {
        // Arrange
        var options = new PdfDocumentOptions();

        // Act
        options.PageSize = PageSize.Letter;

        // Assert
        options.PageSize.Should().Be(PageSize.Letter);
    }

    [Test]
    public void Orientation_ShouldSetAndGetValue()
    {
        // Arrange
        var options = new PdfDocumentOptions();

        // Act
        options.Orientation = PageOrientation.Landscape;

        // Assert
        options.Orientation.Should().Be(PageOrientation.Landscape);
    }

    [Test]
    public void PdfDocumentOptions_ShouldAllowCompleteConfiguration()
    {
        // Arrange & Act
        var options = new PdfDocumentOptions
        {
            Title = "Test Report",
            Subtitle = "Q1 2025",
            PageSize = PageSize.A4,
            Orientation = PageOrientation.Portrait,
            RepeatHeader = true,
            Info = new DocumentInfo
            {
                Author = "Test Author",
                CreatedDate = DateTime.Now,
                ShowInHeader = true
            }
        };

        // Assert
        options.Title.Should().Be("Test Report");
        options.Subtitle.Should().Be("Q1 2025");
        options.PageSize.Should().Be(PageSize.A4);
        options.Orientation.Should().Be(PageOrientation.Portrait);
        options.RepeatHeader.Should().BeTrue();
        options.Info.Should().NotBeNull();
        options.Info!.Author.Should().Be("Test Author");
    }
}
