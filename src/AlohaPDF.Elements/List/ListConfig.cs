namespace AlohaPDF.Elements.List;

/// <summary>
/// Configuration for list rendering.
/// </summary>
public class ListConfig
{
    /// <summary>
    /// List items to display.
    /// </summary>
    public required List<string> Items { get; init; }

    /// <summary>
    /// Use monospace font (for code/console style).
    /// </summary>
    public bool UseMonospace { get; init; } = false;

    /// <summary>
    /// Add left margin/indent.
    /// </summary>
    public bool WithMargin { get; init; } = false;

    /// <summary>
    /// Use numeric prefixes (1., 2., etc.) instead of bullets.
    /// </summary>
    public bool IsNumbered { get; init; } = false;

    /// <summary>
    /// Alternate row background colors.
    /// </summary>
    public bool AlternateRows { get; init; } = false;

    /// <summary>
    /// Custom prefix for each item (overrides IsNumbered).
    /// </summary>
    public string? CustomPrefix { get; init; }

    /// <summary>
    /// Left margin in points (only used if WithMargin is true).
    /// </summary>
    public float LeftMargin { get; init; } = 24f;
}
