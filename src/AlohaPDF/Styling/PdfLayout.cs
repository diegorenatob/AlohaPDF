namespace AlohaPDF.Styling;

/// <summary>
/// Layout constants and helpers for PDF documents.
/// Supports multiple page sizes with consistent spacing.
/// </summary>
public static class PdfLayout
{
    // Page dimensions - Now configurable per document
    // Default values are for A4 (595.28 × 841.89 points / 210mm × 297mm)
    // Use SetPageSize() to configure different sizes
    private static float _pageWidth = 595.28f;
    private static float _pageHeight = 841.89f;

    /// <summary>
    /// Gets the current page width in points.
    /// Default: A4 width (595.28 points / 210mm).
    /// </summary>
    public static float PageWidth => _pageWidth;

    /// <summary>
    /// Gets the current page height in points.
    /// Default: A4 height (841.89 points / 297mm).
    /// </summary>
    public static float PageHeight => _pageHeight;

    /// <summary>
    /// Sets the page dimensions based on the specified page size.
    /// This should be called during document initialization.
    /// </summary>
    /// <param name="pageSize">The page size to use.</param>
    internal static void SetPageSize(Core.PageSize pageSize)
    {
        var dimensions = Core.PageSizeInfo.GetDimensions(pageSize);
        _pageWidth = dimensions.Width;
        _pageHeight = dimensions.Height;
    }

    /// <summary>
    /// Resets page dimensions to default (A4).
    /// </summary>
    internal static void ResetPageSize()
    {
        _pageWidth = 595.28f;
        _pageHeight = 841.89f;
    }
    
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
