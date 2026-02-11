namespace AlohaPDF.Core.Contracts;

/// <summary>
/// Represents a renderable PDF element.
/// Single Responsibility: Only defines rendering contract.
/// </summary>
public interface IPdfElement
{
    /// <summary>
    /// Renders the element using the provided rendering context.
    /// </summary>
    /// <param name="context">The rendering context with canvas, fonts, and layout information.</param>
    void Render(IRenderContext context);
    
    /// <summary>
    /// Calculates the height this element will occupy.
    /// Used for page break calculations.
    /// </summary>
    /// <param name="context">The rendering context.</param>
    /// <returns>Height in points.</returns>
    float GetRequiredHeight(IRenderContext context);
}
