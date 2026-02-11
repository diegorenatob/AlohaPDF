namespace AlohaPDF.Elements;

/// <summary>
/// Represents a renderable element in a PDF document.
/// </summary>
internal interface IPdfElement
{
    /// <summary>
    /// Renders the element on the PDF document.
    /// </summary>
    /// <param name="document">The PDF document instance.</param>
    void Render(AlohaPdfDocument document);
}
