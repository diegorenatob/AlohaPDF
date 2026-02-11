using AlohaPDF.Core.Contracts;

namespace AlohaPDF.Elements.Section;

/// <summary>
/// Section heading element.
/// </summary>
public class SectionElement : IPdfElement
{
    private readonly SectionConfig _config;

    public SectionElement(SectionConfig config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }

    public float GetRequiredHeight(IRenderContext context)
    {
        return _config.Pill ? 48f : 24f;
    }

    public void Render(IRenderContext context)
    {
        var renderer = new SectionRenderer();
        renderer.Render(context, _config);
    }
}
