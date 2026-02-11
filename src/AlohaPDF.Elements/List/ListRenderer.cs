using AlohaPDF.Core.Contracts;
using SkiaSharp;

namespace AlohaPDF.Elements.List;

/// <summary>
/// Renders lists with various styles.
/// </summary>
public class ListRenderer
{
    private const float RowHeight = 32f;

    public void Render(IRenderContext context, ListConfig config)
    {
        float leftMargin = config.WithMargin 
            ? context.PageMargin + config.LeftMargin 
            : context.PageMargin;

        for (int i = 0; i < config.Items.Count; i++)
        {
            context.EnsureSpace(RowHeight);

            // Draw alternating background if enabled
            if (config.AlternateRows && i % 2 == 0)
            {
                DrawRect(context, leftMargin, context.CurrentY - 4f, 
                    context.AvailableWidth - (config.WithMargin ? config.LeftMargin : 0), 
                    RowHeight, 
                    context.Colors.BackgroundAlt);
            }

            var color = config.UseMonospace ? context.Colors.TextPrimary : context.Colors.TextSecondary;
            var typeface = config.UseMonospace ? context.Fonts.Monospace : context.Fonts.Regular;

            string prefix = GetPrefix(config, i);
            string text = prefix + config.Items[i];

            DrawText(context, text, leftMargin + 8f, context.CurrentY + 16f, 12f, color, typeface);
            context.CurrentY += RowHeight;
        }
    }

    private string GetPrefix(ListConfig config, int index)
    {
        if (config.CustomPrefix != null)
            return config.CustomPrefix;

        if (config.IsNumbered)
            return $"{index + 1}. ";

        return "• ";
    }

    private void DrawRect(IRenderContext context, float x, float y, float width, float height, SKColor color)
    {
        using var paint = new SKPaint { Color = color, Style = SKPaintStyle.Fill };
        context.Canvas.DrawRect(x, y, width, height, paint);
    }

    private void DrawText(IRenderContext context, string text, float x, float y, float fontSize, SKColor color, SKTypeface? typeface)
    {
        using var font = new SKFont(typeface, fontSize);
        using var paint = new SKPaint(font)
        {
            Color = color,
            IsAntialias = true
        };

        context.Canvas.DrawText(text, x, y, font, paint);
    }
}
