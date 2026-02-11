// MIT License - Copyright (c) 2025 Diego Belapatiño Farias

using SkiaSharp;
using AlohaPDF.Core;
using AlohaPDF.Elements;
using AlohaPDF.Styling;
using Svg.Skia;
using System.Text.RegularExpressions;

namespace AlohaPDF;

/// <summary>
/// Fluent PDF document generator for .NET MAUI applications.
/// </summary>
public class AlohaPdfDocument : IAlohaPdfDocument
{
    private readonly List<IPdfElement> _elements = new();
    private PdfDocumentOptions? _options;
    private bool _initialized;
    
    private SKTypeface? _regular;
    private SKTypeface? _bold;
    private SKTypeface? _medium;
    private SKTypeface? _monospace;
    private float _firstPageTopMargin;
    private float _repeatPageTopMargin;
    
    private float _currentY;
    private int _currentPage;
    private SKCanvas? _canvas;
    private SKDocument? _document;
    private List<SKPicture> _pages = new();
    private SKPictureRecorder? _recorder;

    /// <summary>
    /// Gets the current section counter for auto-numbered sections.
    /// </summary>
    public int SectionCounter { get; private set; }

    /// <summary>
    /// Initializes the PDF document with configuration options.
    /// </summary>
    public void Initialize(PdfDocumentOptions options)
    {
        if (_initialized) ResetInternal();

        _options = options ?? throw new ArgumentNullException(nameof(options));
        SectionCounter = 0;

        LoadFonts();
        CalculateMargins();
        _initialized = true;
    }

    /// <summary>
    /// Adds a numbered section heading.
    /// </summary>
    public IAlohaPdfDocument AddSection(string text, bool pill = false)
    {
        EnsureInitialized();
        SectionCounter++;
        _elements.Add(new SectionElement($"{SectionCounter}. {text}", pill));
        return this;
    }

    /// <summary>
    /// Adds a subtitle or heading.
    /// </summary>
    public IAlohaPdfDocument AddSubtitle(string text, bool pill = false)
    {
        EnsureInitialized();
        _elements.Add(new SubtitleElement(text, pill));
        return this;
    }

    /// <summary>
    /// Adds a subtitle with summary information.
    /// </summary>
    public IAlohaPdfDocument AddSubtitleWithSummary(string text, string summaryText, string summaryValue, bool pill = false)
    {
        EnsureInitialized();
        _elements.Add(new SubtitleWithSummaryElement(text, summaryText, summaryValue, pill));
        return this;
    }

    /// <summary>
    /// Adds a paragraph of text.
    /// </summary>
    public IAlohaPdfDocument AddParagraph(string text, float lineHeight = 0, bool isBold = false, float leftMargin = 0f)
    {
        EnsureInitialized();
        _elements.Add(new ParagraphElement(text, lineHeight, isBold, leftMargin));
        return this;
    }

    /// <summary>
    /// Adds a horizontal line.
    /// </summary>
    public IAlohaPdfDocument AddLine(float leftMargin = 0f, float rightMargin = 0f)
    {
        EnsureInitialized();
        _elements.Add(new LineElement(leftMargin, rightMargin));
        return this;
    }

    /// <summary>
    /// Adds vertical blank space.
    /// </summary>
    public IAlohaPdfDocument AddBlankSpace(int count = 1)
    {
        EnsureInitialized();
        _elements.Add(new BlankSpaceElement(count * 12f));
        return this;
    }

    /// <summary>
    /// Adds specific amount of vertical space.
    /// </summary>
    public IAlohaPdfDocument AddSpace(float points)
    {
        EnsureInitialized();
        _elements.Add(new BlankSpaceElement(points));
        return this;
    }

    /// <summary>
    /// Adds a list of items.
    /// </summary>
    public IAlohaPdfDocument AddList(IEnumerable<string> items, bool useMonospace = false, bool withMargin = false, 
        bool isNumbered = false, bool alternateRows = false, string? customPrefix = null)
    {
        EnsureInitialized();
        _elements.Add(new ListElement(items.ToList(), useMonospace, withMargin, isNumbered, alternateRows, customPrefix));
        return this;
    }

    /// <summary>
    /// Adds a data table.
    /// </summary>
    public IAlohaPdfDocument AddTable(string[] headers, IEnumerable<string[]> rows, bool alternateRows = true, 
        TableHeaderStyle headerStyle = TableHeaderStyle.Light, float leftMargin = 0f, float rightMargin = 0f, 
        bool repeatHeadersOnPageBreak = false)
    {
        EnsureInitialized();
        _elements.Add(new TableElement(headers, rows.ToList(), alternateRows, headerStyle, leftMargin, rightMargin, repeatHeadersOnPageBreak));
        return this;
    }

    /// <summary>
    /// Adds a styled list with title.
    /// </summary>
    public IAlohaPdfDocument AddStyledList(string title, IEnumerable<string> items, int baseNumber = 1, bool addBottomMargin = true)
    {
        EnsureInitialized();
        _elements.Add(new StyledListElement(title, items.ToList(), baseNumber, addBottomMargin));
        return this;
    }

    /// <summary>
    /// Adds a styled item.
    /// </summary>
    public IAlohaPdfDocument AddStyledItem(string title, string text, string number = "1", bool addLineSeparator = false, bool addBottomMargin = false)
    {
        EnsureInitialized();
        _elements.Add(new StyledItemElement(title, text, number, addLineSeparator, addBottomMargin));
        return this;
    }

    /// <summary>
    /// Generates the PDF and saves to specified path.
    /// </summary>
    public void Generate(string outputPath)
    {
        if (File.Exists(outputPath)) File.Delete(outputPath);
        
        EnsureInitialized();

        using var fileStream = new FileStream(outputPath, FileMode.Create);
        _document = SKDocument.CreatePdf(fileStream);
        _pages.Clear();
        _currentPage = 0;

        StartNewPage();

        foreach (var element in _elements)
        {
            element.Render(this);
        }

        FinalizePage();
        FinalizeDocument();
        ResetInternal();
    }

    /// <summary>
    /// Generates the PDF and returns the file path.
    /// </summary>
    public string Generate(string fileName, bool useAppDataDirectory)
    {
        if (!useAppDataDirectory)
        {
            Generate(fileName);
            return fileName;
        }

        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);
        Generate(path);
        return path;
    }

    #region Internal Helper Methods

    internal List<string> WrapText(string text, float maxWidth, float fontSize, SKTypeface? typeface = null)
    {
        var lines = new List<string>();
        if (string.IsNullOrEmpty(text)) return lines;

        var normalizedText = text.Replace("\r\n", "\n").Replace("\r", "\n");
        var textLines = normalizedText.Split('\n', StringSplitOptions.None);
        using var font = new SKFont(typeface ?? _regular, fontSize);

        foreach (var textLine in textLines)
        {
            if (string.IsNullOrEmpty(textLine))
            {
                lines.Add(string.Empty);
                continue;
            }

            var words = textLine.Split(' ');
            var currentLine = string.Empty;

            foreach (var word in words)
            {
                var testLine = string.IsNullOrEmpty(currentLine) ? word : $"{currentLine} {word}";
                var lineWidth = MeasureText(testLine, font);

                if (lineWidth <= maxWidth)
                {
                    currentLine = testLine;
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentLine))
                    {
                        lines.Add(currentLine);
                        currentLine = word;
                    }
                    else
                    {
                        lines.Add(word);
                    }
                }
            }

            if (!string.IsNullOrEmpty(currentLine))
            {
                lines.Add(currentLine);
            }
        }

        return lines;
    }

    internal void CheckPageBreak(float requiredHeight)
    {
        if (_currentY + requiredHeight > PdfLayout.PageHeight - PdfLayout.FooterHeight)
        {
            StartNewPage();
        }
    }

    internal float MeasureText(string text, SKFont font)
    {
        using var paint = new SKPaint(font);
        return paint.MeasureText(text);
    }

    internal void DrawText(string text, float x, float y, float fontSize, SKColor color, SKTypeface? typeface = null, SKTextAlign align = SKTextAlign.Left)
    {
        if (_canvas == null) return;

        using var font = new SKFont(typeface ?? _regular, fontSize);
        using var paint = new SKPaint(font)
        {
            Color = color,
            IsAntialias = true,
            TextAlign = align
        };

        _canvas.DrawText(text, x, y, font, paint);
    }

    internal void DrawRect(float x, float y, float width, float height, SKColor color, float cornerRadius = 0f)
    {
        if (_canvas == null) return;

        using var paint = new SKPaint { Color = color, Style = SKPaintStyle.Fill };

        if (cornerRadius > 0)
        {
            var rect = new SKRect(x, y, x + width, y + height);
            _canvas.DrawRoundRect(rect, cornerRadius, cornerRadius, paint);
        }
        else
        {
            _canvas.DrawRect(x, y, width, height, paint);
        }
    }

    internal void DrawLine(float x1, float y1, float x2, float y2, SKColor color, float strokeWidth = 1f)
    {
        if (_canvas == null) return;

        using var paint = new SKPaint { Color = color, StrokeWidth = strokeWidth, Style = SKPaintStyle.Stroke };
        _canvas.DrawLine(x1, y1, x2, y2, paint);
    }

    internal float CurrentY
    {
        get => _currentY;
        set => _currentY = value;
    }

    internal int CurrentPage => _currentPage;
    internal SKTypeface? RegularFont => _regular;
    internal SKTypeface? BoldFont => _bold;
    internal SKTypeface? MediumFont => _medium;
    internal SKTypeface? MonospaceFont => _monospace;
    internal float PageMargin => _options?.PageMargin ?? PdfLayout.MarginDefault;

    #endregion

    #region Private Methods

    private void LoadFonts()
    {
        try
        {
            if (_options?.Fonts?.Regular != null)
                _regular = SKTypeface.FromStream(_options.Fonts.Regular);
            else
                _regular = SKTypeface.Default;

            if (_options?.Fonts?.Bold != null)
                _bold = SKTypeface.FromStream(_options.Fonts.Bold);
            else
                _bold = SKTypeface.FromFamilyName("Arial", SKFontStyle.Bold);

            if (_options?.Fonts?.Medium != null)
                _medium = SKTypeface.FromStream(_options.Fonts.Medium);
            else
                _medium = SKTypeface.FromFamilyName("Arial", SKFontStyle.Bold);

            if (_options?.Fonts?.Monospace != null)
                _monospace = SKTypeface.FromStream(_options.Fonts.Monospace);
            else
                _monospace = SKTypeface.FromFamilyName("Courier New", SKFontStyle.Normal);
        }
        catch
        {
            _regular = SKTypeface.Default;
            _bold = SKTypeface.FromFamilyName("Arial", SKFontStyle.Bold);
            _medium = _bold;
            _monospace = SKTypeface.FromFamilyName("Courier New", SKFontStyle.Normal);
        }
    }

    private void CalculateMargins()
    {
        if (_options == null) return;

        int rowPairs = (int)Math.Ceiling(_options.Metadata.Count / 2f);
        float metadataBlockHeight = rowPairs > 0 
            ? PdfLayout.SpaceMd + (rowPairs * PdfLayout.SpaceMd) + ((rowPairs - 1) * PdfLayout.SpaceSm) + PdfLayout.SpaceLg 
            : 0f;

        _firstPageTopMargin = PdfLayout.HeaderHeight + metadataBlockHeight;
        _repeatPageTopMargin = Math.Max(
            (_options.RepeatHeader ? PdfLayout.HeaderHeight : 0f) + (_options.RepeatMetadata ? metadataBlockHeight : 0f),
            PdfLayout.MarginDefault);
    }

    private void EnsureInitialized()
    {
        if (!_initialized)
            throw new InvalidOperationException("Initialize() must be called before adding content.");
    }

    private void StartNewPage()
    {
        FinalizePage();

        _currentPage++;
        _recorder = new SKPictureRecorder();
        _canvas = _recorder.BeginRecording(new SKRect(0, 0, PdfLayout.PageWidth, PdfLayout.PageHeight));

        _currentY = _currentPage == 1 ? _firstPageTopMargin : _repeatPageTopMargin;

        if (_currentPage == 1 || _options?.RepeatHeader == true) DrawHeader();
        if ((_currentPage == 1 || _options?.RepeatMetadata == true) && _options?.Metadata.Count > 0) DrawMetadataBlock();
    }

    private void FinalizePage()
    {
        if (_canvas == null || _recorder == null) return;

        DrawFooter();

        var picture = _recorder.EndRecording();
        _pages.Add(picture);

        _canvas = null;
        _recorder?.Dispose();
        _recorder = null;
    }

    private void FinalizeDocument()
    {
        if (_document == null) return;

        foreach (var page in _pages)
        {
            using var canvas = _document.BeginPage(PdfLayout.PageWidth, PdfLayout.PageHeight);
            canvas.DrawPicture(page);
            _document.EndPage();
        }

        _document.Close();
        _document.Dispose();
        _document = null;

        foreach (var page in _pages)
            page.Dispose();
        _pages.Clear();
    }

    private void DrawHeader()
    {
        if (_canvas == null || _options == null) return;

        using var paint = new SKPaint();

        // Draw header background with primary color
        paint.Color = PdfColors.PrimaryDark;
        _canvas.DrawRect(0, 0, PdfLayout.PageWidth, PdfLayout.HeaderHeight, paint);

        // Draw title
        using var titleFont = new SKFont(_bold, PdfTypography.Heading1);
        paint.Color = SKColors.White;
        paint.TextAlign = SKTextAlign.Left;
        _canvas.DrawText(_options.Title, PageMargin, PdfLayout.SpaceLg + PdfTypography.Heading1, titleFont, paint);

        // Draw subtitle
        using var subtitleFont = new SKFont(_regular, PdfTypography.Heading3);
        _canvas.DrawText(_options.Subtitle, PageMargin, PdfLayout.SpaceLg + PdfTypography.Heading1 + PdfTypography.Heading3 + PdfLayout.SpaceSm, subtitleFont, paint);

        // Draw logo if available
        if (_options.HeaderLogo != null)
        {
            DrawLogo(_options.HeaderLogo, PdfLayout.PageWidth - PageMargin - 52f, PdfLayout.SpaceLg, 52f, 32f);
        }
    }

    private void DrawMetadataBlock()
    {
        if (_canvas == null || _options?.Metadata == null) return;

        var rightItems = _options.Metadata.Where(kv =>
            kv.Key.Contains("date", StringComparison.OrdinalIgnoreCase) ||
            kv.Key.Contains("time", StringComparison.OrdinalIgnoreCase))
            .ToList();
        var leftItems = _options.Metadata.Except(rightItems).ToList();

        int rows = Math.Max(leftItems.Count, rightItems.Count);
        if (rows == 0) return;

        float yPosition = PdfLayout.HeaderHeight + PdfLayout.SpaceLg;

        using var labelFont = new SKFont(_regular, PdfTypography.Caption);
        using var valueFont = new SKFont(_medium, PdfTypography.Caption);
        using var labelPaint = new SKPaint(labelFont) { Color = PdfColors.TextSecondary, TextAlign = SKTextAlign.Left };
        using var valuePaint = new SKPaint(valueFont) { Color = PdfColors.TextPrimary, TextAlign = SKTextAlign.Left };
        using var linePaint = new SKPaint { Color = PdfColors.Divider, StrokeWidth = 1f, Style = SKPaintStyle.Stroke };

        for (int row = 0; row < rows; row++)
        {
            if (row < leftItems.Count)
                DrawMetadataPair(leftItems[row].Key, leftItems[row].Value.ToUpper(), PageMargin, yPosition, labelFont, valueFont, labelPaint, valuePaint);

            if (row < rightItems.Count)
            {
                string label = rightItems[row].Key;
                string value = rightItems[row].Value.ToUpper();
                float labelWidth = MeasureText(label, labelFont);
                float valueWidth = MeasureText(value, valueFont);
                float xPosition = PdfLayout.PageWidth - PageMargin - (labelWidth + PdfLayout.SpaceSm + valueWidth);
                DrawMetadataPair(label, value, xPosition, yPosition, labelFont, valueFont, labelPaint, valuePaint);
            }

            _canvas.DrawLine(PageMargin, yPosition + PdfLayout.SpaceSm, PdfLayout.PageWidth - PageMargin, yPosition + PdfLayout.SpaceSm, linePaint);
            yPosition += PdfLayout.SpaceLg;
        }
    }

    private void DrawMetadataPair(string label, string value, float x, float y, SKFont labelFont, SKFont valueFont, SKPaint labelPaint, SKPaint valuePaint)
    {
        if (_canvas == null) return;

        _canvas.DrawText(label, x, y, labelFont, labelPaint);

        float labelWidth = MeasureText(label, labelFont);
        _canvas.DrawText(value, x + labelWidth + PdfLayout.SpaceSm, y, valueFont, valuePaint);
    }

    private void DrawFooter()
    {
        if (_canvas == null || _options == null) return;

        float yPos = PdfLayout.PageHeight - PdfLayout.SpaceLg;

        using var paint = new SKPaint();
        using var footerFont = new SKFont(_regular, PdfTypography.Caption);

        if (_currentPage > 1)
        {
            paint.Color = PdfColors.Border;
            paint.StrokeWidth = 0.5f;
            paint.Style = SKPaintStyle.Stroke;
            _canvas.DrawLine(0, PdfLayout.PageHeight - PdfLayout.FooterHeight, PdfLayout.PageWidth, PdfLayout.PageHeight - PdfLayout.FooterHeight, paint);

            if (_options.FooterLogo != null)
            {
                DrawLogo(_options.FooterLogo, PageMargin, PdfLayout.PageHeight - PdfLayout.SpaceLg - 16f, 34f, 16f);
            }

            float xAfterLogo = PageMargin + 34f + PdfLayout.SpaceLg;
            paint.Color = PdfColors.TextSecondary;
            paint.Style = SKPaintStyle.Fill;
            paint.TextAlign = SKTextAlign.Left;

            _canvas.DrawText(_options.Title, xAfterLogo, yPos, footerFont, paint);
            float titleWidth = MeasureText(_options.Title, footerFont);
            _canvas.DrawText(_options.Subtitle, xAfterLogo + titleWidth + PdfLayout.SpaceSm, yPos, footerFont, paint);
        }

        string pageText = _currentPage.ToString();
        float pageTextWidth = MeasureText(pageText, footerFont);
        paint.Color = PdfColors.TextSecondary;
        paint.TextAlign = SKTextAlign.Left;
        _canvas.DrawText(pageText, PdfLayout.PageWidth - PageMargin - pageTextWidth, yPos, footerFont, paint);
    }

    private void DrawLogo(Stream logoStream, float x, float y, float width, float height)
    {
        if (_canvas == null) return;

        try
        {
            logoStream.Position = 0;
            
            var svg = new SKSvg();
            if (svg.Load(logoStream) != null)
            {
                var svgSize = svg.Picture.CullRect.Size;
                var scaleX = width / svgSize.Width;
                var scaleY = height / svgSize.Height;
                var scale = Math.Min(scaleX, scaleY);

                _canvas.Save();
                _canvas.Translate(x + ((width - (svgSize.Width * scale)) / 2), y + ((height - (svgSize.Height * scale)) / 2));
                _canvas.Scale(scale);
                _canvas.DrawPicture(svg.Picture);
                _canvas.Restore();
                return;
            }

            logoStream.Position = 0;
            var bitmap = SKBitmap.Decode(logoStream);
            if (bitmap != null)
            {
                var destRect = new SKRect(x, y, x + width, y + height);
                _canvas.DrawBitmap(bitmap, destRect);
                bitmap.Dispose();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error loading logo: {ex.Message}");
        }
    }

    private void ResetInternal()
    {
        _initialized = false;
        _elements.Clear();
        _canvas = null;
        _document?.Dispose();
        _document = null;
        _recorder?.Dispose();
        _recorder = null;

        foreach (var page in _pages)
            page.Dispose();
        _pages.Clear();

        _currentPage = 0;
        _regular?.Dispose();
        _bold?.Dispose();
        _medium?.Dispose();
        _monospace?.Dispose();
    }

    #endregion

    #region Element Implementations

    private record SectionElement(string Text, bool Pill) : IPdfElement
    {
        public void Render(AlohaPdfDocument doc)
        {
            doc.CheckPageBreak(PdfLayout.Space2xl);

            if (!Pill)
            {
                doc.DrawText(Text, doc.PageMargin, doc.CurrentY, PdfTypography.Heading2, PdfColors.TextPrimary, doc.MediumFont);
                doc.CurrentY += PdfLayout.SpaceLg;
            }
            else
            {
                doc.DrawRect(doc.PageMargin, doc.CurrentY, PdfLayout.PageWidth - (2 * doc.PageMargin), PdfLayout.PillHeight, PdfColors.BackgroundAccent, PdfLayout.PillRadius);
                doc.DrawText(Text, doc.PageMargin + PdfLayout.SpaceLg, doc.CurrentY + PdfLayout.SpaceLg + PdfLayout.SpaceSm, PdfTypography.Heading3, PdfColors.Primary, doc.MediumFont);
                doc.CurrentY += PdfLayout.Space2xl;
            }
        }
    }

    private record SubtitleElement(string Text, bool Pill) : IPdfElement
    {
        public void Render(AlohaPdfDocument doc)
        {
            doc.CheckPageBreak(PdfLayout.SpaceXl);

            if (!Pill)
            {
                doc.DrawText(Text, doc.PageMargin, doc.CurrentY, PdfTypography.Heading3, PdfColors.TextPrimary, doc.MediumFont);
                doc.CurrentY += PdfLayout.SpaceMd;
            }
            else
            {
                doc.DrawRect(doc.PageMargin, doc.CurrentY, PdfLayout.PageWidth - (2 * doc.PageMargin), PdfLayout.PillHeight, PdfColors.BackgroundAlt, PdfLayout.CardRadius);
                doc.DrawText(Text, doc.PageMargin + PdfLayout.SpaceMd, doc.CurrentY + PdfLayout.SpaceLg, PdfTypography.Body, PdfColors.TextPrimary, doc.MediumFont);
                doc.CurrentY += PdfLayout.SpaceXl;
            }
        }
    }

    private record SubtitleWithSummaryElement(string Text, string SummaryText, string SummaryValue, bool Pill) : IPdfElement
    {
        public void Render(AlohaPdfDocument doc)
        {
            doc.CheckPageBreak(PdfLayout.SpaceXl);

            if (!Pill)
            {
                doc.DrawText(Text, doc.PageMargin, doc.CurrentY, PdfTypography.Heading3, PdfColors.TextPrimary, doc.BoldFont);
                doc.CurrentY += PdfLayout.SpaceMd;
            }
            else
            {
                doc.DrawRect(doc.PageMargin, doc.CurrentY, PdfLayout.PageWidth - (2 * doc.PageMargin), PdfLayout.PillHeight, PdfColors.BackgroundAlt, PdfLayout.CardRadius);
                doc.DrawText(Text, doc.PageMargin + PdfLayout.SpaceLg, doc.CurrentY + PdfLayout.SpaceLg, PdfTypography.Body, PdfColors.TextPrimary, doc.MediumFont);

                using var summaryFont = new SKFont(doc.RegularFont, PdfTypography.Body);
                using var valueFont = new SKFont(doc.MediumFont, PdfTypography.Heading3);

                float summaryWidth = doc.MeasureText(SummaryText, summaryFont);
                float valueWidth = doc.MeasureText(SummaryValue, valueFont);
                float rightX = PdfLayout.PageWidth - doc.PageMargin - PdfLayout.SpaceLg - summaryWidth - PdfLayout.SpaceXs - valueWidth;

                doc.DrawText(SummaryText, rightX, doc.CurrentY + PdfLayout.SpaceLg, PdfTypography.Body, PdfColors.TextSecondary, doc.RegularFont);
                doc.DrawText(SummaryValue, rightX + summaryWidth + PdfLayout.SpaceXs, doc.CurrentY + PdfLayout.SpaceLg, PdfTypography.Heading3, PdfColors.Primary, doc.MediumFont);

                doc.CurrentY += PdfLayout.SpaceXl;
            }
        }
    }

    private record ParagraphElement(string Text, float LineHeight, bool IsBold, float LeftMargin) : IPdfElement
    {
        public void Render(AlohaPdfDocument doc)
        {
            doc.CheckPageBreak(PdfLayout.SpaceMd);
            var font = IsBold ? doc.BoldFont : doc.RegularFont;
            var color = LeftMargin > 0 ? PdfColors.TextSecondary : PdfColors.TextPrimary;

            var availableWidth = PdfLayout.PageWidth - (2 * doc.PageMargin) - LeftMargin;
            var lines = doc.WrapText(Text, availableWidth, PdfTypography.Body, font);

            foreach (var line in lines)
            {
                doc.DrawText(line, doc.PageMargin + LeftMargin, doc.CurrentY, PdfTypography.Body, color, font);
                doc.CurrentY += PdfLayout.SpaceMd + LineHeight;
            }
        }
    }

    private record LineElement(float LeftMargin, float RightMargin) : IPdfElement
    {
        public void Render(AlohaPdfDocument doc)
        {
            doc.CheckPageBreak(PdfLayout.SpaceSm);
            float strokeWidth = (LeftMargin > 0 || RightMargin > 0) ? 1f : 0.5f;
            doc.DrawLine(doc.PageMargin + LeftMargin, doc.CurrentY, PdfLayout.PageWidth - doc.PageMargin - RightMargin, doc.CurrentY, PdfColors.Border, strokeWidth);
            doc.CurrentY += PdfLayout.SpaceSm;
        }
    }

    private record BlankSpaceElement(float Space) : IPdfElement
    {
        public void Render(AlohaPdfDocument doc)
        {
            doc.CurrentY += Space;
        }
    }

    private record ListElement(List<string> Items, bool UseMonospace, bool WithMargin, bool IsNumbered, bool AlternateRows, string? CustomPrefix) : IPdfElement
    {
        public void Render(AlohaPdfDocument doc)
        {
            float leftMargin = WithMargin ? doc.PageMargin + PdfLayout.SpaceLg : doc.PageMargin;

            for (int i = 0; i < Items.Count; i++)
            {
                doc.CheckPageBreak(PdfLayout.TableRowHeight);

                if (AlternateRows && i % 2 == 0)
                {
                    doc.DrawRect(leftMargin, doc.CurrentY - PdfLayout.SpaceXs, PdfLayout.PageWidth - leftMargin - doc.PageMargin, PdfLayout.TableRowHeight, PdfColors.BackgroundAlt);
                }

                var color = UseMonospace ? PdfColors.TextPrimary : PdfColors.TextSecondary;
                var font = UseMonospace ? doc.MonospaceFont : doc.RegularFont;

                string prefix = CustomPrefix ?? (IsNumbered ? $"{i + 1}. " : "• ");

                doc.DrawText(prefix + Items[i], leftMargin + PdfLayout.SpaceSm, doc.CurrentY + PdfLayout.SpaceMd, PdfTypography.Body, color, font);
                doc.CurrentY += PdfLayout.TableRowHeight;
            }
        }
    }

    private record TableElement(string[] Headers, List<string[]> Rows, bool AlternateRows, TableHeaderStyle HeaderStyle, 
        float LeftMargin, float RightMargin, bool RepeatHeadersOnPageBreak) : IPdfElement
    {
        public void Render(AlohaPdfDocument doc)
        {
            float effectiveLeftMargin = LeftMargin > 0 ? doc.PageMargin + LeftMargin : doc.PageMargin;
            float effectiveRightMargin = RightMargin > 0 ? RightMargin : doc.PageMargin;
            float availableWidth = PdfLayout.PageWidth - effectiveLeftMargin - effectiveRightMargin;
            float columnWidth = availableWidth / Headers.Length;

            var (headerBg, headerText) = HeaderStyle switch
            {
                TableHeaderStyle.Dark => (PdfColors.TableHeaderDark, SKColors.White),
                TableHeaderStyle.Primary => (PdfColors.Primary, SKColors.White),
                TableHeaderStyle.Minimal => (PdfColors.Background, PdfColors.TextPrimary),
                _ => (PdfColors.TableHeader, PdfColors.TextPrimary)
            };

            bool showHeaders = Headers.Length > 0 && !string.IsNullOrWhiteSpace(Headers[0]);

            if (showHeaders)
            {
                doc.CheckPageBreak(PdfLayout.TableHeaderHeight);
                DrawTableHeader(doc, effectiveLeftMargin, availableWidth, columnWidth, headerBg, headerText);
            }

            for (int rowIndex = 0; rowIndex < Rows.Count; rowIndex++)
            {
                if (doc.CurrentY + PdfLayout.TableRowHeight > PdfLayout.PageHeight - PdfLayout.FooterHeight - PdfLayout.SpaceLg)
                {
                    int currentPageBeforeBreak = doc.CurrentPage;
                    doc.CheckPageBreak(PdfLayout.TableRowHeight);

                    if (doc.CurrentPage > currentPageBeforeBreak && RepeatHeadersOnPageBreak && showHeaders)
                    {
                        DrawTableHeader(doc, effectiveLeftMargin, availableWidth, columnWidth, headerBg, headerText);
                    }
                }

                var row = Rows[rowIndex];
                var rowBg = AlternateRows && rowIndex % 2 == 1 ? PdfColors.TableRowAlt : PdfColors.Background;

                doc.DrawRect(effectiveLeftMargin, doc.CurrentY, availableWidth, PdfLayout.TableRowHeight, rowBg);

                for (int colIndex = 0; colIndex < Math.Min(row.Length, Headers.Length); colIndex++)
                {
                    float textX = effectiveLeftMargin + (colIndex * columnWidth) + PdfLayout.TableCellPadding;
                    doc.DrawText(row[colIndex], textX, doc.CurrentY + PdfLayout.SpaceMd, PdfTypography.Body, PdfColors.TextSecondary, doc.RegularFont);
                }

                doc.CurrentY += PdfLayout.TableRowHeight;
            }

            doc.CurrentY += PdfLayout.SpaceSm;
        }

        private void DrawTableHeader(AlohaPdfDocument doc, float startX, float availableWidth, float columnWidth, SKColor headerBg, SKColor headerText)
        {
            if (HeaderStyle == TableHeaderStyle.Minimal)
            {
                for (int i = 0; i < Headers.Length; i++)
                {
                    float textX = startX + (i * columnWidth) + PdfLayout.TableCellPadding;
                    doc.DrawText(Headers[i], textX, doc.CurrentY + PdfLayout.SpaceMd, PdfTypography.Body, headerText, doc.MediumFont);
                }
                doc.DrawLine(startX, doc.CurrentY + PdfLayout.TableHeaderHeight - PdfLayout.SpaceXs, startX + availableWidth, doc.CurrentY + PdfLayout.TableHeaderHeight - PdfLayout.SpaceXs, PdfColors.Border, 2f);
            }
            else
            {
                doc.DrawRect(startX, doc.CurrentY, availableWidth, PdfLayout.TableHeaderHeight, headerBg, (HeaderStyle == TableHeaderStyle.Primary || HeaderStyle == TableHeaderStyle.Secondary) ? PdfLayout.CardRadius : 0f);

                for (int i = 0; i < Headers.Length; i++)
                {
                    float textX = startX + (i * columnWidth) + PdfLayout.TableCellPadding;
                    doc.DrawText(Headers[i], textX, doc.CurrentY + PdfLayout.SpaceLg, PdfTypography.Body, headerText, doc.MediumFont);
                }
            }

            doc.CurrentY += PdfLayout.TableHeaderHeight;
        }
    }

    private record StyledListElement(string Title, List<string> Items, int BaseNumber, bool AddBottomMargin) : IPdfElement
    {
        public void Render(AlohaPdfDocument doc)
        {
            if (!string.IsNullOrEmpty(Title))
            {
                doc.CheckPageBreak(PdfLayout.SpaceXl);
                doc.DrawRect(doc.PageMargin + PdfLayout.SpaceLg, doc.CurrentY, PdfLayout.PageWidth - doc.PageMargin - PdfLayout.SpaceLg - doc.PageMargin, PdfLayout.PillHeight, PdfColors.BackgroundAccent, PdfLayout.CardRadius);
                doc.DrawText(Title, doc.PageMargin + PdfLayout.Space2xl, doc.CurrentY + PdfLayout.SpaceLg, PdfTypography.Heading3, PdfColors.TextSecondary, doc.RegularFont);
                doc.CurrentY += PdfLayout.SpaceXl + PdfLayout.SpaceXs;
            }

            for (int i = 0; i < Items.Count; i++)
            {
                string number = $"{BaseNumber}.{i + 1}";
                var wrappedLines = doc.WrapText(Items[i], PdfLayout.PageWidth - 120f - doc.PageMargin, PdfTypography.Body, doc.RegularFont);
                float itemHeight = wrappedLines.Count * PdfLayout.SpaceMd;
                doc.CheckPageBreak(itemHeight + PdfLayout.SpaceSm);

                doc.DrawText(number, doc.PageMargin + PdfLayout.SpaceLg, doc.CurrentY + PdfLayout.SpaceMd, PdfTypography.Body, PdfColors.TextSecondary, doc.RegularFont);

                for (int lineIndex = 0; lineIndex < wrappedLines.Count; lineIndex++)
                {
                    doc.DrawText(wrappedLines[lineIndex], 100f, doc.CurrentY + PdfLayout.SpaceMd, PdfTypography.Body, PdfColors.TextSecondary, doc.RegularFont);
                    doc.CurrentY += PdfLayout.SpaceMd;
                }

                doc.CurrentY += PdfLayout.SpaceXs;
                doc.DrawLine(doc.PageMargin + PdfLayout.SpaceLg, doc.CurrentY, PdfLayout.PageWidth - doc.PageMargin, doc.CurrentY, PdfColors.Divider, 0.5f);
                doc.CurrentY += PdfLayout.SpaceSm;
            }

            if (AddBottomMargin)
                doc.CurrentY += PdfLayout.SpaceSm;
        }
    }

    private record StyledItemElement(string Title, string Text, string Number, bool AddLineSeparator, bool AddBottomMargin) : IPdfElement
    {
        public void Render(AlohaPdfDocument doc)
        {
            float leftMargin = doc.PageMargin + PdfLayout.SpaceLg;

            if (!string.IsNullOrEmpty(Title))
            {
                doc.CheckPageBreak(PdfLayout.SpaceXl);
                doc.DrawRect(leftMargin, doc.CurrentY, PdfLayout.PageWidth - leftMargin - doc.PageMargin, PdfLayout.PillHeight, PdfColors.BackgroundAlt, PdfLayout.CardRadius);
                doc.DrawText(Title, leftMargin + PdfLayout.SpaceLg, doc.CurrentY + PdfLayout.SpaceLg, PdfTypography.Heading3, PdfColors.TextPrimary, doc.MediumFont);
                doc.CurrentY += PdfLayout.SpaceXl;
            }

            doc.CheckPageBreak(PdfLayout.SpaceMd);

            doc.DrawText(Number, leftMargin, doc.CurrentY + PdfLayout.SpaceMd, PdfTypography.Body, PdfColors.TextSecondary, doc.RegularFont);

            using var font = new SKFont(doc.RegularFont, PdfTypography.Body);
            float numberWidth = doc.MeasureText(Number, font);
            doc.DrawText(Text, leftMargin + numberWidth + PdfLayout.SpaceSm, doc.CurrentY + PdfLayout.SpaceMd, PdfTypography.Body, PdfColors.TextSecondary, doc.RegularFont);
            doc.CurrentY += PdfLayout.SpaceMd;

            if (AddLineSeparator)
            {
                doc.DrawLine(leftMargin, doc.CurrentY, PdfLayout.PageWidth - doc.PageMargin, doc.CurrentY, PdfColors.Divider, 0.5f);
                doc.CurrentY += PdfLayout.SpaceXs;
            }

            if (AddBottomMargin)
                doc.CurrentY += PdfLayout.SpaceSm;
        }
    }

    #endregion
}


