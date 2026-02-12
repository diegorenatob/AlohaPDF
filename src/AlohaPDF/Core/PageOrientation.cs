namespace AlohaPDF.Core;

/// <summary>
/// Page orientation for PDF documents.
/// </summary>
public enum PageOrientation
{
    /// <summary>
    /// Portrait orientation (vertical, height > width).
    /// This is the default and most common orientation.
    /// Example: A4 Portrait is 210mm × 297mm (8.27" × 11.69")
    /// </summary>
    Portrait,

    /// <summary>
    /// Landscape orientation (horizontal, width > height).
    /// Useful for wide tables, charts, and presentations.
    /// Example: A4 Landscape is 297mm × 210mm (11.69" × 8.27")
    /// </summary>
    Landscape
}
