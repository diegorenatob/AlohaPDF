using AlohaPDF.Core;
using FluentAssertions;

namespace AlohaPDF.Tests.Core;

[TestFixture]
public class DocumentInfoTests
{
    [Test]
    public void Constructor_ShouldInitializeWithDefaults()
    {
        // Act
        var documentInfo = new DocumentInfo();

        // Assert
        documentInfo.Author.Should().BeNull();
        documentInfo.CreatedDate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
        documentInfo.Properties.Should().BeNull();
        documentInfo.ShowInHeader.Should().BeTrue();
    }

    [Test]
    public void Author_ShouldSetAndGetValue()
    {
        // Arrange
        var documentInfo = new DocumentInfo();
        var authorName = "Jane Smith";

        // Act
        documentInfo.Author = authorName;

        // Assert
        documentInfo.Author.Should().Be(authorName);
    }

    [Test]
    public void CreatedDate_ShouldSetAndGetValue()
    {
        // Arrange
        var documentInfo = new DocumentInfo();
        var date = new DateTime(2025, 1, 1);

        // Act
        documentInfo.CreatedDate = date;

        // Assert
        documentInfo.CreatedDate.Should().Be(date);
    }

    [Test]
    public void Properties_ShouldAcceptKeyValuePairs()
    {
        // Arrange
        var documentInfo = new DocumentInfo
        {
            Properties = new Dictionary<string, string>
            {
                { "Department", "Sales" },
                { "Project", "Q1 Report" }
            }
        };

        // Assert
        documentInfo.Properties.Should().NotBeNull();
        documentInfo.Properties.Should().ContainKey("Department");
        documentInfo.Properties!["Department"].Should().Be("Sales");
        documentInfo.Properties.Should().ContainKey("Project");
        documentInfo.Properties["Project"].Should().Be("Q1 Report");
    }

    [Test]
    public void ShowInHeader_ShouldSetAndGetValue()
    {
        // Arrange
        var documentInfo = new DocumentInfo();

        // Act
        documentInfo.ShowInHeader = false;

        // Assert
        documentInfo.ShowInHeader.Should().BeFalse();
    }

    [Test]
    public void DocumentInfo_ShouldAllowNullProperties()
    {
        // Arrange & Act
        var documentInfo = new DocumentInfo
        {
            Author = null,
            Properties = null
        };

        // Assert
        documentInfo.Author.Should().BeNull();
        documentInfo.Properties.Should().BeNull();
    }
}
