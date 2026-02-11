using AlohaPDF.Core.Contracts;

namespace AlohaPDF.Elements.List;

/// <summary>
/// List element for bullet or numbered lists.
/// </summary>
public class ListElement : IPdfElement
{
    private readonly ListConfig _config;

    public ListElement(ListConfig config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }

    public float GetRequiredHeight(IRenderContext context)
    {
        const float rowHeight = 24f;
        return _config.Items.Count * rowHeight;
    }

    public void Render(IRenderContext context)
    {
        var renderer = new ListRenderer();
        renderer.Render(context, _config);
    }
}
