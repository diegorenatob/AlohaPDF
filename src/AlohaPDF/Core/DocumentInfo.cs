namespace AlohaPDF.Core;

/// <summary>
/// Simple document metadata - completely different from TKE design.
/// Uses a clean, single-line format.
/// </summary>
public class DocumentInfo
{
    /// <summary>
    /// Document author or creator name.
    /// </summary>
    public string? Author { get; set; }

    /// <summary>
    /// Creation date of the document.
    /// </summary>
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    /// <summary>
    /// Optional additional information (can be null).
    /// Simple key-value pairs for flexibility.
    /// </summary>
    public Dictionary<string, string>? Properties { get; set; }

    /// <summary>
    /// Show document info in header (default: true).
    /// When true, displays a simple one-line format: "Author | Date"
    /// </summary>
    public bool ShowInHeader { get; set; } = true;
}
