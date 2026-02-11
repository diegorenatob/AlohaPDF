namespace AlohaPDF.Styling;

/// <summary>
/// Layout constants for PDF documents.
/// Based on A4 page size with modern spacing.
/// </summary>
public static class PdfLayout
{
    // Page dimensions (A4 in points: 210mm x 297mm)
    public const float PageWidth = 595.28f;
    public const float PageHeight = 841.89f;
    
    // Margins - Following modern design principles
    public const float MarginDefault = 48f;      // ~17mm
    public const float MarginCompact = 32f;      // ~11mm
    public const float MarginRelaxed = 64f;      // ~23mm
    
    // Header and footer
    public const float HeaderHeight = 72f;       // ~25mm
    public const float FooterHeight = 48f;       // ~17mm
    
    // Spacing scale - Based on 4px base unit
    public const float SpaceXs = 4f;
    public const float SpaceSm = 8f;
    public const float SpaceMd = 16f;
    public const float SpaceLg = 24f;
    public const float SpaceXl = 32f;
    public const float Space2xl = 48f;
    
    // Component sizing
    public const float PillHeight = 32f;
    public const float PillRadius = 16f;
    public const float CardRadius = 8f;
    public const float BorderRadius = 4f;
    
    // Table
    public const float TableRowHeight = 32f;
    public const float TableHeaderHeight = 40f;
    public const float TableCellPadding = 12f;
}
