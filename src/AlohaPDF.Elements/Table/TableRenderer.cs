using AlohaPDF.Core.Contracts;
using SkiaSharp;

namespace AlohaPDF.Elements.Table;

/// <summary>
/// Renders tables with proper spacing, colors, and page breaks.
/// Single Responsibility: Only handles table rendering logic.
/// </summary>
public class TableRenderer
{
    private const float TableHeaderHeight = 40f;
    private const float TableRowHeight = 32f;
    private const float TableCellPadding = 12f;

    public void Render(IRenderContext context, TableConfig config)
    {
        float effectiveLeftMargin = config.LeftMargin > 0 
            ? context.PageMargin + config.LeftMargin 
            : context.PageMargin;
        
        float effectiveRightMargin = config.RightMargin > 0 
            ? config.RightMargin 
            : context.PageMargin;
        
        float availableWidth = context.AvailableWidth - config.LeftMargin - (config.RightMargin > 0 ? config.RightMargin - context.PageMargin : 0);
        float columnWidth = availableWidth / config.Headers.Length;

        var (headerBg, headerText) = GetHeaderColors(context, config.HeaderStyle);

        bool showHeaders = config.ShowHeaders && config.Headers.Length > 0 && !string.IsNullOrWhiteSpace(config.Headers[0]);

        // Draw initial header
        if (showHeaders)
        {
            context.EnsureSpace(TableHeaderHeight);
            DrawTableHeader(context, config, effectiveLeftMargin, availableWidth, columnWidth, headerBg, headerText);
        }

        // Draw rows with page break handling
        for (int rowIndex = 0; rowIndex < config.Rows.Count; rowIndex++)
        {
            // Check for page break
            if (context.CurrentY + TableRowHeight > 800f - 64f) // Page height minus footer
            {
                int currentPageBeforeBreak = context.CurrentPage;
                context.EnsureSpace(TableRowHeight);

                // Repeat header if we moved to a new page
                if (context.CurrentPage > currentPageBeforeBreak && config.RepeatHeadersOnPageBreak && showHeaders)
                {
                    DrawTableHeader(context, config, effectiveLeftMargin, availableWidth, columnWidth, headerBg, headerText);
                }
            }

            var row = config.Rows[rowIndex];
            var rowBg = config.AlternateRows && rowIndex % 2 == 1 
                ? context.Colors.BackgroundAlt 
                : context.Colors.Background;

            // Draw row background
            DrawRect(context, effectiveLeftMargin, context.CurrentY, availableWidth, TableRowHeight, rowBg);

            // Draw cells
            for (int colIndex = 0; colIndex < Math.Min(row.Length, config.Headers.Length); colIndex++)
            {
                float textX = effectiveLeftMargin + (colIndex * columnWidth) + TableCellPadding;
                DrawText(context, row[colIndex], textX, context.CurrentY + 16f, 12f, context.Colors.TextSecondary);

                // Draw vertical separator (except for last column)
                if (colIndex < config.Headers.Length - 1)
                {
                    float lineX = effectiveLeftMargin + ((colIndex + 1) * columnWidth);
                    DrawLine(context, lineX, context.CurrentY, lineX, context.CurrentY + TableRowHeight, context.Colors.Border.WithAlpha(128), 0.5f);
                }
            }

            context.CurrentY += TableRowHeight;
        }

        context.CurrentY += 8f; // Bottom spacing
    }

    private void DrawTableHeader(IRenderContext context, TableConfig config, float startX, float availableWidth, float columnWidth, SKColor headerBg, SKColor headerText)
    {
        if (config.HeaderStyle == TableHeaderStyle.Minimal)
        {
            // Minimal style: just text with bottom border
            for (int i = 0; i < config.Headers.Length; i++)
            {
                float textX = startX + (i * columnWidth) + TableCellPadding;
                DrawText(context, config.Headers[i], textX, context.CurrentY + 16f, 12f, headerText, isBold: true);
            }
            DrawLine(context, startX, context.CurrentY + TableHeaderHeight - 4f, startX + availableWidth, context.CurrentY + TableHeaderHeight - 4f, context.Colors.Border, 2f);
        }
        else
        {
            // Draw header background
            float radius = (config.HeaderStyle == TableHeaderStyle.Primary || config.HeaderStyle == TableHeaderStyle.Secondary) ? 8f : 0f;
            DrawRect(context, startX, context.CurrentY, availableWidth, TableHeaderHeight, headerBg, radius);

            // Draw header text
            for (int i = 0; i < config.Headers.Length; i++)
            {
                float textX = startX + (i * columnWidth) + TableCellPadding;
                DrawText(context, config.Headers[i], textX, context.CurrentY + 24f, 12f, headerText, isBold: true);
            }
        }

        context.CurrentY += TableHeaderHeight;
    }

    private (SKColor bg, SKColor text) GetHeaderColors(IRenderContext context, TableHeaderStyle style)
    {
        return style switch
        {
            TableHeaderStyle.Dark => (SKColor.Parse("#2C2C2C"), SKColors.White),
            TableHeaderStyle.Primary => (context.Colors.Primary, SKColors.White),
            TableHeaderStyle.Secondary => (context.Colors.Secondary, SKColors.White),
            TableHeaderStyle.Minimal => (context.Colors.Background, context.Colors.TextPrimary),
            _ => (SKColor.Parse("#F5F5F5"), context.Colors.TextPrimary)
        };
    }

    private void DrawRect(IRenderContext context, float x, float y, float width, float height, SKColor color, float cornerRadius = 0f)
    {
        using var paint = new SKPaint { Color = color, Style = SKPaintStyle.Fill, IsAntialias = true };

        if (cornerRadius > 0)
        {
            var rect = new SKRect(x, y, x + width, y + height);
            context.Canvas.DrawRoundRect(rect, cornerRadius, cornerRadius, paint);
        }
        else
        {
            context.Canvas.DrawRect(x, y, width, height, paint);
        }
    }

    private void DrawLine(IRenderContext context, float x1, float y1, float x2, float y2, SKColor color, float strokeWidth = 1f)
    {
        using var paint = new SKPaint 
        { 
            Color = color, 
            StrokeWidth = strokeWidth, 
            Style = SKPaintStyle.Stroke,
            IsAntialias = true
        };
        context.Canvas.DrawLine(x1, y1, x2, y2, paint);
    }

    private void DrawText(IRenderContext context, string text, float x, float y, float fontSize, SKColor color, bool isBold = false)
    {
        var typeface = isBold ? context.Fonts.Medium : context.Fonts.Regular;
        using var font = new SKFont(typeface, fontSize);
        using var paint = new SKPaint(font)
        {
            Color = color,
            IsAntialias = true
        };

        context.Canvas.DrawText(text, x, y, font, paint);
    }
}
