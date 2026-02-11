using AlohaPDF.Core.Contracts;
using SkiaSharp;

namespace AlohaPDF.Elements.Table;

/// <summary>
/// Table element that can be rendered in a PDF document.
/// Single Responsibility: Represents a table element.
/// </summary>
public class TableElement : IPdfElement
{
    private readonly TableConfig _config;

    public TableElement(TableConfig config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }

    public float GetRequiredHeight(IRenderContext context)
    {
        const float headerHeight = 40f;
        const float rowHeight = 32f;

        float total = 0f;
        if (_config.ShowHeaders && _config.Headers.Length > 0)
            total += headerHeight;

        total += _config.Rows.Count * rowHeight;
        total += 8f; // Bottom spacing

        return total;
    }

    public void Render(IRenderContext context)
    {
        var renderer = new TableRenderer();
        renderer.Render(context, _config);
    }
}
