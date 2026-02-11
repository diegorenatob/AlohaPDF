using AlohaPDF.Core.Contracts;
using SkiaSharp;

namespace AlohaPDF.Rendering.Elements;

/// <summary>
/// Renders a simple, single-line document info header.
/// Format: "Author • Created on Date"
/// COMPLETELY DIFFERENT from TKE design - no table, no complex layout.
/// </summary>
public class SimpleDocInfoElement : IPdfElement
{
    private readonly string? _author;
    private readonly DateTime _date;
    private readonly bool _showInHeader;

    public SimpleDocInfoElement(string? author, DateTime date, bool showInHeader = true)
    {
        _author = author;
        _date = date;
        _showInHeader = showInHeader;
    }

    public float GetRequiredHeight(IRenderContext context)
    {
        return _showInHeader ? 24f : 0f; // Single line + spacing
    }

    public void Render(IRenderContext context)
    {
        if (!_showInHeader || string.IsNullOrWhiteSpace(_author))
            return;

        // Simple format: "Author • Created on Feb 11, 2025"
        var text = $"{_author} • Created on {_date:MMM dd, yyyy}";

        using var font = new SKFont(context.Fonts.Regular, 10f);
        using var paint = new SKPaint(font)
        {
            Color = context.Colors.TextSecondary,
            IsAntialias = true
        };

        // Center it horizontally
        var textWidth = context.MeasureText(text, font);
        var x = (context.PageMargin + context.AvailableWidth - textWidth) / 2f;

        context.Canvas.DrawText(text, x, context.CurrentY + 12f, font, paint);
        context.CurrentY += 20f; // Small spacing after

        // Optional: subtle separator line
        using var linePaint = new SKPaint
        {
            Color = context.Colors.Border.WithAlpha(80),
            StrokeWidth = 0.5f,
            Style = SKPaintStyle.Stroke
        };
        context.Canvas.DrawLine(
            context.PageMargin,
            context.CurrentY,
            context.PageMargin + context.AvailableWidth,
            context.CurrentY,
            linePaint
        );
        context.CurrentY += 4f;
    }
}
