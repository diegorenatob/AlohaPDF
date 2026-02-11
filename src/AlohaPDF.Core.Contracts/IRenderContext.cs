using SkiaSharp;

namespace AlohaPDF.Core.Contracts;

/// <summary>
/// Provides rendering context with canvas, fonts, colors, and layout helpers.
/// Interface Segregation: Clients only depend on what they need.
/// </summary>
public interface IRenderContext
{
    /// <summary>
    /// Gets the current SKCanvas for drawing.
    /// </summary>
    SKCanvas Canvas { get; }
    
    /// <summary>
    /// Gets the current Y position on the page.
    /// </summary>
    float CurrentY { get; set; }
    
    /// <summary>
    /// Gets the current page number.
    /// </summary>
    int CurrentPage { get; }
    
    /// <summary>
    /// Gets the page margin.
    /// </summary>
    float PageMargin { get; }
    
    /// <summary>
    /// Gets the available width for content (page width minus margins).
    /// </summary>
    float AvailableWidth { get; }
    
    /// <summary>
    /// Gets the font provider for accessing different font styles.
    /// </summary>
    IFontProvider Fonts { get; }
    
    /// <summary>
    /// Gets the color provider for accessing theme colors.
    /// </summary>
    IColorProvider Colors { get; }
    
    /// <summary>
    /// Checks if there's enough space for the given height, triggers page break if needed.
    /// </summary>
    /// <param name="requiredHeight">Height in points.</param>
    void EnsureSpace(float requiredHeight);
    
    /// <summary>
    /// Measures text width.
    /// </summary>
    float MeasureText(string text, SKFont font);
    
    /// <summary>
    /// Wraps text to fit within a given width.
    /// </summary>
    List<string> WrapText(string text, float maxWidth, float fontSize, SKTypeface? typeface = null);
}
