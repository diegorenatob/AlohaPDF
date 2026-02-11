namespace AlohaPDF.Elements.Paragraph;

/// <summary>
/// Configuration for paragraph rendering.
/// </summary>
public class ParagraphConfig
{
    /// <summary>
    /// Paragraph text content.
    /// </summary>
    public required string Text { get; init; }

    /// <summary>
    /// Additional line height spacing.
    /// </summary>
    public float LineHeight { get; init; } = 0f;

    /// <summary>
    /// Use bold font weight.
    /// </summary>
    public bool IsBold { get; init; } = false;

    /// <summary>
    /// Left indent/margin in points.
    /// </summary>
    public float LeftMargin { get; init; } = 0f;

    /// <summary>
    /// Font size (default: 12f).
    /// </summary>
    public float FontSize { get; init; } = 12f;
}
