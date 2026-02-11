using AlohaPDF.Core.Contracts;
using SkiaSharp;

namespace AlohaPDF.Elements.Paragraph;

/// <summary>
/// Renders paragraphs with word wrapping.
/// </summary>
public class ParagraphRenderer
{
    public void Render(IRenderContext context, ParagraphConfig config)
    {
        context.EnsureSpace(16f);

        var typeface = config.IsBold ? context.Fonts.Bold : context.Fonts.Regular;
        var color = config.LeftMargin > 0 ? context.Colors.TextSecondary : context.Colors.TextPrimary;

        var availableWidth = context.AvailableWidth - config.LeftMargin;
        var lines = context.WrapText(config.Text, availableWidth, config.FontSize, typeface);

        using var font = new SKFont(typeface, config.FontSize);
        using var paint = new SKPaint(font)
        {
            Color = color,
            IsAntialias = true
        };

        foreach (var line in lines)
        {
            context.Canvas.DrawText(line, context.PageMargin + config.LeftMargin, context.CurrentY, font, paint);
            context.CurrentY += 16f + config.LineHeight;
        }
    }
}
