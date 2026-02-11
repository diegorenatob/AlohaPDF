using AlohaPDF.Core.Contracts;
using SkiaSharp;

namespace AlohaPDF.Elements.Line;

/// <summary>
/// Horizontal line/separator element.
/// </summary>
public class LineElement : IPdfElement
{
    private readonly LineConfig _config;

    public LineElement(LineConfig config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }

    public float GetRequiredHeight(IRenderContext context) => 8f;

    public void Render(IRenderContext context)
    {
        context.EnsureSpace(8f);

        float x1 = context.PageMargin + _config.LeftMargin;
        float x2 = context.PageMargin + context.AvailableWidth - _config.RightMargin;

        using var paint = new SKPaint
        {
            Color = context.Colors.Border,
            StrokeWidth = _config.StrokeWidth,
            Style = SKPaintStyle.Stroke,
            IsAntialias = true
        };

        context.Canvas.DrawLine(x1, context.CurrentY, x2, context.CurrentY, paint);
        context.CurrentY += 8f;
    }
}
