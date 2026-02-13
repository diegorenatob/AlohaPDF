using AlohaPDF.Core;
using AlohaPDF.Styling;
using FluentAssertions;

namespace AlohaPDF.Tests.Styling;

[TestFixture]
public class PdfLayoutTests
{
    [Test]
    public void DefaultPageDimensions_ShouldBeA4()
    {
        // Assert
        PdfLayout.PageWidth.Should().BeApproximately(595.28f, 0.01f);
        PdfLayout.PageHeight.Should().BeApproximately(841.89f, 0.01f);
    }

    [Test]
    public void MarginConstants_ShouldHaveExpectedValues()
    {
        // Assert
        PdfLayout.MarginDefault.Should().Be(48f);
        PdfLayout.MarginCompact.Should().Be(32f);
        PdfLayout.MarginRelaxed.Should().Be(64f);
    }

    [Test]
    public void HeaderFooterConstants_ShouldHaveExpectedValues()
    {
        // Assert
        PdfLayout.HeaderHeight.Should().Be(72f);
        PdfLayout.FooterHeight.Should().Be(48f);
    }

    [Test]
    public void SpacingConstants_ShouldFollowScale()
    {
        // Assert - Verify spacing scale
        PdfLayout.SpaceXs.Should().Be(4f);
        PdfLayout.SpaceSm.Should().Be(8f);
        PdfLayout.SpaceMd.Should().Be(16f);
        PdfLayout.SpaceLg.Should().Be(24f);
        PdfLayout.SpaceXl.Should().Be(32f);
        PdfLayout.Space2xl.Should().Be(48f);
    }

    [Test]
    public void ComponentSizingConstants_ShouldHaveExpectedValues()
    {
        // Assert
        PdfLayout.PillHeight.Should().Be(32f);
        PdfLayout.PillRadius.Should().Be(16f);
        PdfLayout.CardRadius.Should().Be(8f);
        PdfLayout.BorderRadius.Should().Be(4f);
    }

    [Test]
    public void TableConstants_ShouldHaveExpectedValues()
    {
        // Assert
        PdfLayout.TableRowHeight.Should().Be(32f);
        PdfLayout.TableHeaderHeight.Should().Be(40f);
        PdfLayout.TableCellPadding.Should().Be(12f);
    }
}

