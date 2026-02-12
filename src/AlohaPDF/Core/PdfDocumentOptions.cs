namespace AlohaPDF.Core;

/// <summary>
/// Configuration options for PDF document generation.
/// Simplified and professional design.
/// </summary>
public class PdfDocumentOptions
{
    /// <summary>
    /// Gets or sets the document title displayed in the header.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the document subtitle displayed in the header.
    /// </summary>
    public string Subtitle { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets simple document metadata.
    /// Displays as clean, single-line format: "Author | Date"
    /// </summary>
    public DocumentInfo? Info { get; set; }

    /// <summary>
    /// Gets or sets whether to repeat the header on every page.
    /// Default is true.
    /// </summary>
    public bool RepeatHeader { get; set; } = true;

    /// <summary>
    /// Gets or sets the header logo as a stream (SVG, PNG, JPG supported).
    /// The logo will be displayed in the top-right corner of the header.
    /// </summary>
    public Stream? HeaderLogo { get; set; }

    /// <summary>
    /// Gets or sets the footer logo as a stream (SVG, PNG, JPG supported).
    /// The logo will be displayed in the bottom-left corner of the footer (page 2+).
    /// </summary>
    public Stream? FooterLogo { get; set; }

    /// <summary>
    /// Gets or sets custom font resources.
    /// If not provided, system default fonts will be used.
    /// </summary>
    public FontOptions? Fonts { get; set; }

    /// <summary>
    /// Gets or sets the page size for the PDF document.
    /// Default is A4 (595 × 842 points / 210mm × 297mm).
    /// </summary>
    public PageSize PageSize { get; set; } = PageSize.A4;

    /// <summary>
    /// Gets or sets the page margin size.
    /// Default is MarginDefault (48f).
    /// </summary>
    public float PageMargin { get; set; } = Styling.PdfLayout.MarginDefault;
}

/// <summary>
/// Custom font options for the PDF document.
/// All fonts are optional and will fallback to system defaults.
/// </summary>
public class FontOptions
{
    /// <summary>
    /// Regular weight font (TTF/OTF).
    /// </summary>
    public Stream? Regular { get; set; }

    /// <summary>
    /// Bold weight font (TTF/OTF).
    /// </summary>
    public Stream? Bold { get; set; }

    /// <summary>
    /// Medium weight font (TTF/OTF).
    /// </summary>
    public Stream? Medium { get; set; }

    /// <summary>
    /// Monospace font for code or console-style text (TTF/OTF).
    /// </summary>
    public Stream? Monospace { get; set; }
}
