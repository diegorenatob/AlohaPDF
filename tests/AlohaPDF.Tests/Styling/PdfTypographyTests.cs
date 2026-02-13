using AlohaPDF.Styling;
using FluentAssertions;

namespace AlohaPDF.Tests.Styling;

[TestFixture]
public class PdfTypographyTests
{
    [Test]
    public void FontSizeConstants_ShouldHaveExpectedValues()
    {
        // Assert
        PdfTypography.Display.Should().Be(24f);
        PdfTypography.Heading1.Should().Be(20f);
        PdfTypography.Heading2.Should().Be(16f);
        PdfTypography.Heading3.Should().Be(14f);
        PdfTypography.Body.Should().Be(12f);
        PdfTypography.Caption.Should().Be(10f);
        PdfTypography.Tiny.Should().Be(8f);
    }

    [Test]
    public void LineHeightConstants_ShouldHaveExpectedValues()
    {
        // Assert
        PdfTypography.LineHeightTight.Should().Be(1.25f);
        PdfTypography.LineHeightNormal.Should().Be(1.5f);
        PdfTypography.LineHeightRelaxed.Should().Be(1.75f);
    }

    [Test]
    public void FontSizes_ShouldBeInDescendingOrder()
    {
        // Assert - Font sizes should decrease
        PdfTypography.Display.Should().BeGreaterThan(PdfTypography.Heading1);
        PdfTypography.Heading1.Should().BeGreaterThan(PdfTypography.Heading2);
        PdfTypography.Heading2.Should().BeGreaterThan(PdfTypography.Heading3);
        PdfTypography.Heading3.Should().BeGreaterThan(PdfTypography.Body);
        PdfTypography.Body.Should().BeGreaterThan(PdfTypography.Caption);
        PdfTypography.Caption.Should().BeGreaterThan(PdfTypography.Tiny);
    }

    [Test]
    public void LineHeights_ShouldBeInAscendingOrder()
    {
        // Assert - Line heights should increase
        PdfTypography.LineHeightTight.Should().BeLessThan(PdfTypography.LineHeightNormal);
        PdfTypography.LineHeightNormal.Should().BeLessThan(PdfTypography.LineHeightRelaxed);
    }

    [Test]
    public void AllFontSizes_ShouldBePositive()
    {
        // Assert
        PdfTypography.Display.Should().BePositive();
        PdfTypography.Heading1.Should().BePositive();
        PdfTypography.Heading2.Should().BePositive();
        PdfTypography.Heading3.Should().BePositive();
        PdfTypography.Body.Should().BePositive();
        PdfTypography.Caption.Should().BePositive();
        PdfTypography.Tiny.Should().BePositive();
    }

    [Test]
    public void AllLineHeights_ShouldBeGreaterThanOne()
    {
        // Assert - Line heights should be multipliers > 1
        PdfTypography.LineHeightTight.Should().BeGreaterThan(1.0f);
        PdfTypography.LineHeightNormal.Should().BeGreaterThan(1.0f);
        PdfTypography.LineHeightRelaxed.Should().BeGreaterThan(1.0f);
    }
}
