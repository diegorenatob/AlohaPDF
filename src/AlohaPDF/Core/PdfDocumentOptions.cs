namespace AlohaPDF.Core;

/// <summary>
/// Configuration options for creating a PDF document.
/// </summary>
public class PdfDocumentOptions
{
    /// <summary>
    /// Gets or sets the document title shown in the header.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the document subtitle shown in the header.
    /// </summary>
    public string Subtitle { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets document metadata (author, date, version, etc.).
    /// Keys containing "date" or "time" will be right-aligned.
    /// </summary>
    public Dictionary<string, string> Metadata { get; set; } = new();

    /// <summary>
    /// Gets or sets whether to repeat the header on every page.
    /// Default is true.
    /// </summary>
    public bool RepeatHeader { get; set; } = true;

    /// <summary>
    /// Gets or sets whether to repeat metadata on every page.
    /// Default is false (only on first page).
    /// </summary>
    public bool RepeatMetadata { get; set; } = false;

    /// <summary>
    /// Gets or sets the header logo stream (SVG, PNG, JPG supported).
    /// Logo will be displayed in the header area.
    /// </summary>
    public Stream? HeaderLogo { get; set; }

    /// <summary>
    /// Gets or sets the footer logo stream (SVG, PNG, JPG supported).
    /// Logo will be displayed in the footer (page 2+).
    /// </summary>
    public Stream? FooterLogo { get; set; }

    /// <summary>
    /// Gets or sets custom typography fonts.
    /// If not provided, system fonts will be used.
    /// </summary>
    public FontOptions? Fonts { get; set; }

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
