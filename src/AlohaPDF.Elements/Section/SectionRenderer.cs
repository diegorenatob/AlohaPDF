using AlohaPDF.Core.Contracts;
using SkiaSharp;

namespace AlohaPDF.Elements.Section;

/// <summary>
/// Renders section headings with optional pill styling.
/// </summary>
public class SectionRenderer
{
    public void Render(IRenderContext context, SectionConfig config)
    {
        context.EnsureSpace(config.Pill ? 48f : 32f);

        if (!config.Pill)
        {
            // Simple text heading
            using var font = new SKFont(context.Fonts.Medium, config.FontSize);
            using var paint = new SKPaint(font)
            {
                Color = context.Colors.TextPrimary,
                IsAntialias = true
            };

            context.Canvas.DrawText(config.Text, context.PageMargin, context.CurrentY, font, paint);
            context.CurrentY += 24f;
        }
        else
        {
            // Pill/badge style
            float pillHeight = 32f;
            float pillWidth = context.AvailableWidth;

            using var pillPaint = new SKPaint
            {
                Color = SKColor.Parse("#FFF5F2"), // Soft coral tint
                Style = SKPaintStyle.Fill,
                IsAntialias = true
            };

            var rect = new SKRect(context.PageMargin, context.CurrentY, context.PageMargin + pillWidth, context.CurrentY + pillHeight);
            context.Canvas.DrawRoundRect(rect, 16f, 16f, pillPaint);

            using var font = new SKFont(context.Fonts.Medium, 14f);
            using var textPaint = new SKPaint(font)
            {
                Color = context.Colors.Primary,
                IsAntialias = true
            };

            context.Canvas.DrawText(config.Text, context.PageMargin + 24f, context.CurrentY + 20f, font, textPaint);
            context.CurrentY += 48f;
        }
    }
}
