namespace AlohaPDF.Elements.Table;

/// <summary>
/// Configuration for table rendering.
/// Single Responsibility: Only holds table configuration data.
/// </summary>
public class TableConfig
{
    /// <summary>
    /// Column headers.
    /// </summary>
    public required string[] Headers { get; init; }

    /// <summary>
    /// Data rows. Each row should have the same number of columns as headers.
    /// </summary>
    public required List<string[]> Rows { get; init; }

    /// <summary>
    /// Alternate row background colors for better readability.
    /// </summary>
    public bool AlternateRows { get; init; } = true;

    /// <summary>
    /// Header style (Primary, Secondary, Dark, Light, Minimal).
    /// </summary>
    public TableHeaderStyle HeaderStyle { get; init; } = TableHeaderStyle.Light;

    /// <summary>
    /// Left margin/indent in points.
    /// </summary>
    public float LeftMargin { get; init; } = 0f;

    /// <summary>
    /// Right margin in points.
    /// </summary>
    public float RightMargin { get; init; } = 0f;

    /// <summary>
    /// Repeat headers when table spans multiple pages.
    /// </summary>
    public bool RepeatHeadersOnPageBreak { get; init; } = false;

    /// <summary>
    /// Show headers (can be disabled for data-only tables).
    /// </summary>
    public bool ShowHeaders { get; init; } = true;
}

/// <summary>
/// Table header styles matching AlohaPDF.Core.
/// </summary>
public enum TableHeaderStyle
{
    Light,
    Dark,
    Primary,
    Secondary,
    Minimal
}
