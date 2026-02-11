using AlohaPDF.Core.Contracts;

namespace AlohaPDF.Elements.Paragraph;

/// <summary>
/// Paragraph element with automatic word wrapping.
/// </summary>
public class ParagraphElement : IPdfElement
{
    private readonly ParagraphConfig _config;

    public ParagraphElement(ParagraphConfig config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }

    public float GetRequiredHeight(IRenderContext context)
    {
        var availableWidth = context.AvailableWidth - _config.LeftMargin;
        var typeface = _config.IsBold ? context.Fonts.Bold : context.Fonts.Regular;
        var lines = context.WrapText(_config.Text, availableWidth, _config.FontSize, typeface);
        
        return lines.Count * (16f + _config.LineHeight);
    }

    public void Render(IRenderContext context)
    {
        var renderer = new ParagraphRenderer();
        renderer.Render(context, _config);
    }
}
