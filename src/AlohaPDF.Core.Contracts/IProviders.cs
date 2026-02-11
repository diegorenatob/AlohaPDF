using SkiaSharp;

namespace AlohaPDF.Core.Contracts;

/// <summary>
/// Provides access to fonts.
/// Dependency Inversion: High-level modules depend on this abstraction.
/// </summary>
public interface IFontProvider
{
    SKTypeface? Regular { get; }
    SKTypeface? Bold { get; }
    SKTypeface? Medium { get; }
    SKTypeface? Monospace { get; }
}

/// <summary>
/// Provides access to theme colors.
/// </summary>
public interface IColorProvider
{
    SKColor Primary { get; }
    SKColor Secondary { get; }
    SKColor TextPrimary { get; }
    SKColor TextSecondary { get; }
    SKColor Background { get; }
    SKColor BackgroundAlt { get; }
    SKColor Border { get; }
}
