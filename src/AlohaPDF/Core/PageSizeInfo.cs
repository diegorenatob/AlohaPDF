namespace AlohaPDF.Core;

/// <summary>
/// Provides dimension information for standard page sizes.
/// All dimensions are in points (1 point = 1/72 inch).
/// </summary>
public static class PageSizeInfo
{
    /// <summary>
    /// Gets the width and height in points for the specified page size.
    /// </summary>
    /// <param name="pageSize">The page size.</param>
    /// <returns>A tuple with (width, height) in points.</returns>
    public static (float Width, float Height) GetDimensions(PageSize pageSize)
    {
        return pageSize switch
        {
            // ISO A-series
            PageSize.A4 => (595f, 842f),      // 210mm × 297mm
            PageSize.A3 => (842f, 1191f),     // 297mm × 420mm
            PageSize.A5 => (420f, 595f),      // 148mm × 210mm

            // ISO B-series
            PageSize.B4 => (709f, 1001f),     // 250mm × 353mm
            PageSize.B5 => (499f, 709f),      // 176mm × 250mm

            // North American
            PageSize.Letter => (612f, 792f),   // 8.5" × 11"
            PageSize.Legal => (612f, 1008f),   // 8.5" × 14"
            PageSize.Tabloid => (792f, 1224f), // 11" × 17"
            PageSize.Executive => (522f, 756f), // 7.25" × 10.5"

            _ => (595f, 842f) // Default to A4
        };
    }

    /// <summary>
    /// Gets the width in points for the specified page size.
    /// </summary>
    public static float GetWidth(PageSize pageSize) => GetDimensions(pageSize).Width;

    /// <summary>
    /// Gets the height in points for the specified page size.
    /// </summary>
    public static float GetHeight(PageSize pageSize) => GetDimensions(pageSize).Height;

    /// <summary>
    /// Gets a human-readable description of the page size.
    /// </summary>
    public static string GetDescription(PageSize pageSize)
    {
        return pageSize switch
        {
            PageSize.A4 => "A4 (210mm × 297mm / 8.27\" × 11.69\")",
            PageSize.A3 => "A3 (297mm × 420mm / 11.69\" × 16.54\")",
            PageSize.A5 => "A5 (148mm × 210mm / 5.83\" × 8.27\")",
            PageSize.B4 => "B4 (250mm × 353mm / 9.84\" × 13.90\")",
            PageSize.B5 => "B5 (176mm × 250mm / 6.93\" × 9.84\")",
            PageSize.Letter => "Letter (8.5\" × 11\" / 215.9mm × 279.4mm)",
            PageSize.Legal => "Legal (8.5\" × 14\" / 215.9mm × 355.6mm)",
            PageSize.Tabloid => "Tabloid (11\" × 17\" / 279.4mm × 431.8mm)",
            PageSize.Executive => "Executive (7.25\" × 10.5\" / 184.15mm × 266.7mm)",
            _ => "Unknown"
        };
    }

    /// <summary>
    /// Gets the common usage/region for the page size.
    /// </summary>
    public static string GetUsage(PageSize pageSize)
    {
        return pageSize switch
        {
            PageSize.A4 => "International standard, most common worldwide",
            PageSize.A3 => "Large prints, posters, international",
            PageSize.A5 => "Small books, notepads, international",
            PageSize.B4 => "Between A3 and A4, used in Asia",
            PageSize.B5 => "Between A4 and A5, used in Asia",
            PageSize.Letter => "Standard in USA, Canada, Mexico",
            PageSize.Legal => "Legal documents in USA",
            PageSize.Tabloid => "Large prints in USA",
            PageSize.Executive => "Personal stationery in USA",
            _ => "Unknown"
        };
    }
}
