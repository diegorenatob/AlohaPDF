namespace AlohaPDF.Styling;

/// <summary>
/// Typography settings for PDF documents.
/// Based on modern type scales.
/// </summary>
public static class PdfTypography
{
    // Font sizes - Type scale
    public const float Display = 24f;
    public const float Heading1 = 20f;
    public const float Heading2 = 16f;
    public const float Heading3 = 14f;
    public const float Body = 12f;
    public const float Caption = 10f;
    public const float Tiny = 8f;
    
    // Line heights
    public const float LineHeightTight = 1.25f;
    public const float LineHeightNormal = 1.5f;
    public const float LineHeightRelaxed = 1.75f;
    
    // Spacing
    public const float LetterSpacingNormal = 0f;
    public const float LetterSpacingWide = 0.5f;
}
