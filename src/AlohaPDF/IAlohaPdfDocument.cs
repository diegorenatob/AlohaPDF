using AlohaPDF.Core;

namespace AlohaPDF;

/// <summary>
/// Fluent API for creating PDF documents in .NET MAUI applications.
/// Provides an intuitive, chainable interface for building professional reports.
/// </summary>
public interface IAlohaPdfDocument
{
    /// <summary>
    /// Gets the current section counter for auto-numbered sections.
    /// </summary>
    int SectionCounter { get; }

    /// <summary>
    /// Initializes the PDF document with configuration options.
    /// Must be called before adding any content.
    /// </summary>
    /// <param name="options">Document configuration options.</param>
    void Initialize(PdfDocumentOptions options);

    /// <summary>
    /// Adds a numbered section heading (e.g., "1. Introduction").
    /// The section number is automatically incremented.
    /// </summary>
    /// <param name="text">Section title text.</param>
    /// <param name="pill">Whether to display with pill/badge styling.</param>
    /// <returns>Current document instance for method chaining.</returns>
    IAlohaPdfDocument AddSection(string text, bool pill = false);

    /// <summary>
    /// Adds a subtitle or heading without numbering.
    /// </summary>
    /// <param name="text">Subtitle text.</param>
    /// <param name="pill">Whether to display with pill/badge styling.</param>
    /// <returns>Current document instance for method chaining.</returns>
    IAlohaPdfDocument AddSubtitle(string text, bool pill = false);

    /// <summary>
    /// Adds a subtitle with summary information displayed on the right side.
    /// Perfect for showing totals, counts, or key metrics.
    /// </summary>
    /// <param name="text">Main subtitle text.</param>
    /// <param name="summaryText">Summary label (e.g., "Total:").</param>
    /// <param name="summaryValue">Summary value (e.g., "$1,234").</param>
    /// <param name="pill">Whether to display with pill/badge styling.</param>
    /// <returns>Current document instance for method chaining.</returns>
    IAlohaPdfDocument AddSubtitleWithSummary(string text, string summaryText, string summaryValue, bool pill = false);

    /// <summary>
    /// Adds a paragraph of text with automatic word wrapping.
    /// </summary>
    /// <param name="text">Paragraph text content.</param>
    /// <param name="lineHeight">Additional line height spacing (default: 0).</param>
    /// <param name="isBold">Whether to use bold font weight.</param>
    /// <param name="leftMargin">Left indent/margin in points.</param>
    /// <returns>Current document instance for method chaining.</returns>
    IAlohaPdfDocument AddParagraph(string text, float lineHeight = 0, bool isBold = false, float leftMargin = 0f);

    /// <summary>
    /// Adds a horizontal divider line.
    /// </summary>
    /// <param name="leftMargin">Left margin/indent in points.</param>
    /// <param name="rightMargin">Right margin in points.</param>
    /// <returns>Current document instance for method chaining.</returns>
    IAlohaPdfDocument AddLine(float leftMargin = 0f, float rightMargin = 0f);

    /// <summary>
    /// Adds vertical blank space.
    /// </summary>
    /// <param name="count">Number of line heights to add.</param>
    /// <returns>Current document instance for method chaining.</returns>
    IAlohaPdfDocument AddBlankSpace(int count = 1);

    /// <summary>
    /// Adds specific amount of vertical space.
    /// </summary>
    /// <param name="points">Height in points to add.</param>
    /// <returns>Current document instance for method chaining.</returns>
    IAlohaPdfDocument AddSpace(float points);

    /// <summary>
    /// Adds a list of items with various styling options.
    /// </summary>
    /// <param name="items">List items to display.</param>
    /// <param name="useMonospace">Use monospace font (for code/console style).</param>
    /// <param name="withMargin">Add left margin/indent.</param>
    /// <param name="isNumbered">Use numeric prefixes (1., 2., etc.).</param>
    /// <param name="alternateRows">Alternate row background colors.</param>
    /// <param name="customPrefix">Custom prefix for each item.</param>
    /// <returns>Current document instance for method chaining.</returns>
    IAlohaPdfDocument AddList(
        IEnumerable<string> items, 
        bool useMonospace = false, 
        bool withMargin = false, 
        bool isNumbered = false, 
        bool alternateRows = false, 
        string? customPrefix = null);

    /// <summary>
    /// Adds a data table with headers and rows.
    /// </summary>
    /// <param name="headers">Column header texts.</param>
    /// <param name="rows">Data rows (each row should match header count).</param>
    /// <param name="alternateRows">Alternate row background colors.</param>
    /// <param name="headerStyle">Visual style for table header.</param>
    /// <param name="leftMargin">Left margin/indent in points.</param>
    /// <param name="rightMargin">Right margin in points.</param>
    /// <param name="repeatHeadersOnPageBreak">Repeat headers when table spans multiple pages.</param>
    /// <returns>Current document instance for method chaining.</returns>
    IAlohaPdfDocument AddTable(
        string[] headers, 
        IEnumerable<string[]> rows, 
        bool alternateRows = true, 
        TableHeaderStyle headerStyle = TableHeaderStyle.Light, 
        float leftMargin = 0f, 
        float rightMargin = 0f, 
        bool repeatHeadersOnPageBreak = false);

    /// <summary>
    /// Adds a styled list with a title banner.
    /// Items are numbered with a base prefix (e.g., "1.1", "1.2").
    /// </summary>
    /// <param name="title">List title displayed in banner.</param>
    /// <param name="items">List items.</param>
    /// <param name="baseNumber">Base number for item numbering.</param>
    /// <param name="addBottomMargin">Add spacing after the list.</param>
    /// <returns>Current document instance for method chaining.</returns>
    IAlohaPdfDocument AddStyledList(
        string title, 
        IEnumerable<string> items, 
        int baseNumber = 1, 
        bool addBottomMargin = true);

    /// <summary>
    /// Adds a single styled item with optional title banner.
    /// </summary>
    /// <param name="title">Item title in banner (optional).</param>
    /// <param name="text">Item text content.</param>
    /// <param name="number">Item number or label.</param>
    /// <param name="addLineSeparator">Add line separator after item.</param>
    /// <param name="addBottomMargin">Add spacing after item.</param>
    /// <returns>Current document instance for method chaining.</returns>
    IAlohaPdfDocument AddStyledItem(
        string title, 
        string text, 
        string number = "1", 
        bool addLineSeparator = false, 
        bool addBottomMargin = false);

    /// <summary>
    /// Generates the PDF document and saves to specified path.
    /// Existing files will be overwritten.
    /// </summary>
    /// <param name="outputPath">Full file path where PDF will be saved.</param>
    void Generate(string outputPath);

    /// <summary>
    /// Generates the PDF document and returns the file path.
    /// </summary>
    /// <param name="fileName">File name for the PDF.</param>
    /// <param name="useAppDataDirectory">Combine with app data directory path.</param>
    /// <returns>Full path where PDF was saved.</returns>
    string Generate(string fileName, bool useAppDataDirectory);
}
