namespace AlohaPDF.Styling;

/// <summary>
/// Modern color palette inspired by tropical Aloha spirit.
/// Warm, inviting colors for beautiful PDF documents.
/// </summary>
public static class PdfColors
{
    // Primary colors - Tropical sunset palette
    public static readonly SkiaSharp.SKColor Primary = SkiaSharp.SKColor.Parse("#FF6B35");        // Vibrant coral
    public static readonly SkiaSharp.SKColor PrimaryDark = SkiaSharp.SKColor.Parse("#D85A2B");    // Deep coral
    public static readonly SkiaSharp.SKColor PrimaryLight = SkiaSharp.SKColor.Parse("#FF8A5B");   // Soft coral
    
    // Secondary colors - Ocean blues
    public static readonly SkiaSharp.SKColor Secondary = SkiaSharp.SKColor.Parse("#00A8CC");      // Tropical ocean
    public static readonly SkiaSharp.SKColor SecondaryDark = SkiaSharp.SKColor.Parse("#0088AA");  // Deep ocean
    public static readonly SkiaSharp.SKColor SecondaryLight = SkiaSharp.SKColor.Parse("#4FC3DC"); // Sky blue
    
    // Accent colors - Tropical greens
    public static readonly SkiaSharp.SKColor Accent = SkiaSharp.SKColor.Parse("#6BBF59");         // Palm green
    public static readonly SkiaSharp.SKColor AccentDark = SkiaSharp.SKColor.Parse("#5AA648");     // Forest green
    
    // Neutral colors - Professional base
    public static readonly SkiaSharp.SKColor TextPrimary = SkiaSharp.SKColor.Parse("#1A1A1A");
    public static readonly SkiaSharp.SKColor TextSecondary = SkiaSharp.SKColor.Parse("#666666");
    public static readonly SkiaSharp.SKColor TextTertiary = SkiaSharp.SKColor.Parse("#999999");
    
    // Background colors
    public static readonly SkiaSharp.SKColor Background = SkiaSharp.SKColor.Parse("#FFFFFF");
    public static readonly SkiaSharp.SKColor BackgroundAlt = SkiaSharp.SKColor.Parse("#F8F9FA");
    public static readonly SkiaSharp.SKColor BackgroundAccent = SkiaSharp.SKColor.Parse("#FFF5F2");  // Soft coral tint
    
    // Border and divider colors
    public static readonly SkiaSharp.SKColor Border = SkiaSharp.SKColor.Parse("#E0E0E0");
    public static readonly SkiaSharp.SKColor BorderDark = SkiaSharp.SKColor.Parse("#CCCCCC");
    public static readonly SkiaSharp.SKColor Divider = SkiaSharp.SKColor.Parse("#F0F0F0");
    
    // Status colors
    public static readonly SkiaSharp.SKColor Success = SkiaSharp.SKColor.Parse("#6BBF59");
    public static readonly SkiaSharp.SKColor Warning = SkiaSharp.SKColor.Parse("#FFA726");
    public static readonly SkiaSharp.SKColor Error = SkiaSharp.SKColor.Parse("#EF5350");
    public static readonly SkiaSharp.SKColor Info = SkiaSharp.SKColor.Parse("#00A8CC");
    
    // Table-specific colors
    public static readonly SkiaSharp.SKColor TableHeader = SkiaSharp.SKColor.Parse("#F5F5F5");
    public static readonly SkiaSharp.SKColor TableHeaderDark = SkiaSharp.SKColor.Parse("#2C2C2C");
    public static readonly SkiaSharp.SKColor TableHeaderPrimary = SkiaSharp.SKColor.Parse("#FF6B35");
    public static readonly SkiaSharp.SKColor TableRowAlt = SkiaSharp.SKColor.Parse("#FAFAFA");
}
