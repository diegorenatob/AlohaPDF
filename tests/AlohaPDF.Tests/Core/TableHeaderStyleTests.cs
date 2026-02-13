using AlohaPDF.Core;
using FluentAssertions;

namespace AlohaPDF.Tests.Core;

[TestFixture]
public class TableHeaderStyleTests
{
    [Test]
    public void TableHeaderStyle_ShouldHaveExpectedValues()
    {
        // Assert
        Enum.IsDefined(typeof(TableHeaderStyle), TableHeaderStyle.Primary).Should().BeTrue();
        Enum.IsDefined(typeof(TableHeaderStyle), TableHeaderStyle.Secondary).Should().BeTrue();
    }

    [Test]
    public void TableHeaderStyle_ShouldBeComparable()
    {
        // Arrange
        var primary = TableHeaderStyle.Primary;
        var secondary = TableHeaderStyle.Secondary;

        // Assert
        primary.Should().NotBe(secondary);
        primary.Should().Be(TableHeaderStyle.Primary);
        secondary.Should().Be(TableHeaderStyle.Secondary);
    }
}
