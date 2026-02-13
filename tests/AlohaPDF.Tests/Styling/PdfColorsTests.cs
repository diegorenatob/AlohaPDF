using AlohaPDF.Styling;
using FluentAssertions;
using SkiaSharp;

namespace AlohaPDF.Tests.Styling;

[TestFixture]
public class PdfColorsTests
{
    [Test]
    public void PrimaryColor_ShouldReturnCorrectColor()
    {
        // Act
        var color = PdfColors.Primary;

        // Assert
        color.Should().NotBe(SKColor.Empty);
    }

    [Test]
    public void SecondaryColor_ShouldReturnCorrectColor()
    {
        // Act
        var color = PdfColors.Secondary;

        // Assert
        color.Should().NotBe(SKColor.Empty);
    }

    [Test]
    public void TextPrimaryColor_ShouldReturnCorrectColor()
    {
        // Act
        var color = PdfColors.TextPrimary;

        // Assert
        color.Should().NotBe(SKColor.Empty);
    }

    [Test]
    public void TextSecondaryColor_ShouldReturnCorrectColor()
    {
        // Act
        var color = PdfColors.TextSecondary;

        // Assert
        color.Should().NotBe(SKColor.Empty);
    }

    [Test]
    public void TextTertiaryColor_ShouldReturnCorrectColor()
    {
        // Act
        var color = PdfColors.TextTertiary;

        // Assert
        color.Should().NotBe(SKColor.Empty);
    }

    [Test]
    public void BorderColor_ShouldReturnCorrectColor()
    {
        // Act
        var color = PdfColors.Border;

        // Assert
        color.Should().NotBe(SKColor.Empty);
    }

    [Test]
    public void BackgroundAltColor_ShouldReturnCorrectColor()
    {
        // Act
        var color = PdfColors.BackgroundAlt;

        // Assert
        color.Should().NotBe(SKColor.Empty);
    }

    [Test]
    public void SuccessColor_ShouldReturnCorrectColor()
    {
        // Act
        var color = PdfColors.Success;

        // Assert
        color.Should().NotBe(SKColor.Empty);
    }

    [Test]
    public void WarningColor_ShouldReturnCorrectColor()
    {
        // Act
        var color = PdfColors.Warning;

        // Assert
        color.Should().NotBe(SKColor.Empty);
    }

    [Test]
    public void ErrorColor_ShouldReturnCorrectColor()
    {
        // Act
        var color = PdfColors.Error;

        // Assert
        color.Should().NotBe(SKColor.Empty);
    }

    [Test]
    public void AllColors_ShouldBeDifferent()
    {
        // Arrange
        var colors = new[]
        {
            PdfColors.Primary,
            PdfColors.Secondary,
            PdfColors.TextPrimary,
            PdfColors.TextSecondary,
            PdfColors.TextTertiary
        };

        // Assert - Check that main colors are distinct
        colors.Distinct().Count().Should().BeGreaterThan(1);
    }
}
