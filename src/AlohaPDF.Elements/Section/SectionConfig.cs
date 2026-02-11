namespace AlohaPDF.Elements.Section;

/// <summary>
/// Configuration for section heading.
/// </summary>
public class SectionConfig
{
    /// <summary>
    /// Section title text.
    /// </summary>
    public required string Text { get; init; }

    /// <summary>
    /// Display with pill/badge styling.
    /// </summary>
    public bool Pill { get; init; } = false;

    /// <summary>
    /// Font size (default: 16f for sections).
    /// </summary>
    public float FontSize { get; init; } = 16f;
}
