namespace AlohaPDF.Elements.Line;

/// <summary>
/// Configuration for horizontal line/separator.
/// </summary>
public class LineConfig
{
    /// <summary>
    /// Left margin/indent in points.
    /// </summary>
    public float LeftMargin { get; init; } = 0f;

    /// <summary>
    /// Right margin in points.
    /// </summary>
    public float RightMargin { get; init; } = 0f;

    /// <summary>
    /// Line stroke width.
    /// </summary>
    public float StrokeWidth { get; init; } = 1f;
}
