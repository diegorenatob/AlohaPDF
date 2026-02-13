using AlohaPDF.Core;
using FluentAssertions;

namespace AlohaPDF.Tests.Core;

[TestFixture]
public class PageSizeInfoTests
{
    [Test]
    [TestCase(PageSize.A4, PageOrientation.Portrait, 595f, 842f)]
    [TestCase(PageSize.A4, PageOrientation.Landscape, 842f, 595f)]
    [TestCase(PageSize.Letter, PageOrientation.Portrait, 612f, 792f)]
    [TestCase(PageSize.Letter, PageOrientation.Landscape, 792f, 612f)]
    [TestCase(PageSize.Legal, PageOrientation.Portrait, 612f, 1008f)]
    [TestCase(PageSize.A3, PageOrientation.Portrait, 842f, 1191f)]
    [TestCase(PageSize.A5, PageOrientation.Portrait, 420f, 595f)]
    [TestCase(PageSize.Tabloid, PageOrientation.Portrait, 792f, 1224f)]
    [TestCase(PageSize.Executive, PageOrientation.Portrait, 522f, 756f)]
    [TestCase(PageSize.B4, PageOrientation.Portrait, 709f, 1001f)]
    [TestCase(PageSize.B5, PageOrientation.Portrait, 499f, 709f)]
    public void GetDimensions_ShouldReturnCorrectDimensions(PageSize pageSize, PageOrientation orientation, float expectedWidth, float expectedHeight)
    {
        // Act
        var (width, height) = PageSizeInfo.GetDimensions(pageSize, orientation);

        // Assert
        width.Should().Be(expectedWidth);
        height.Should().Be(expectedHeight);
    }

    [Test]
    [TestCase(PageSize.A4, PageOrientation.Portrait, 595f)]
    [TestCase(PageSize.A4, PageOrientation.Landscape, 842f)]
    [TestCase(PageSize.Letter, PageOrientation.Portrait, 612f)]
    public void GetWidth_ShouldReturnCorrectWidth(PageSize pageSize, PageOrientation orientation, float expectedWidth)
    {
        // Act
        var width = PageSizeInfo.GetWidth(pageSize, orientation);

        // Assert
        width.Should().Be(expectedWidth);
    }

    [Test]
    [TestCase(PageSize.A4, PageOrientation.Portrait, 842f)]
    [TestCase(PageSize.A4, PageOrientation.Landscape, 595f)]
    [TestCase(PageSize.Letter, PageOrientation.Portrait, 792f)]
    public void GetHeight_ShouldReturnCorrectHeight(PageSize pageSize, PageOrientation orientation, float expectedHeight)
    {
        // Act
        var height = PageSizeInfo.GetHeight(pageSize, orientation);

        // Assert
        height.Should().Be(expectedHeight);
    }

    [Test]
    [TestCase(PageSize.A4, "A4 (210mm × 297mm / 8.27\" × 11.69\")")]
    [TestCase(PageSize.Letter, "Letter (8.5\" × 11\" / 215.9mm × 279.4mm)")]
    [TestCase(PageSize.Legal, "Legal (8.5\" × 14\" / 215.9mm × 355.6mm)")]
    [TestCase(PageSize.A3, "A3 (297mm × 420mm / 11.69\" × 16.54\")")]
    public void GetDescription_ShouldReturnCorrectDescription(PageSize pageSize, string expectedDescription)
    {
        // Act
        var description = PageSizeInfo.GetDescription(pageSize);

        // Assert
        description.Should().Be(expectedDescription);
    }

    [Test]
    [TestCase(PageSize.A4, "International standard, most common worldwide")]
    [TestCase(PageSize.Letter, "Standard in USA, Canada, Mexico")]
    [TestCase(PageSize.Legal, "Legal documents in USA")]
    public void GetUsage_ShouldReturnCorrectUsage(PageSize pageSize, string expectedUsage)
    {
        // Act
        var usage = PageSizeInfo.GetUsage(pageSize);

        // Assert
        usage.Should().Be(expectedUsage);
    }

    [Test]
    public void GetDimensions_WithDefaultOrientation_ShouldReturnPortrait()
    {
        // Act
        var (width, height) = PageSizeInfo.GetDimensions(PageSize.A4);

        // Assert
        width.Should().Be(595f);
        height.Should().Be(842f);
    }
}
