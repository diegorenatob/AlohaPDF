namespace AlohaPDF.Core;

/// <summary>
/// Standard paper sizes for PDF documents.
/// Following ISO 216 (A-series) and North American standards.
/// </summary>
public enum PageSize
{
    /// <summary>
    /// A4 paper size (210mm × 297mm / 8.27" × 11.69").
    /// Most common international standard.
    /// Points: 595 × 842
    /// </summary>
    A4,

    /// <summary>
    /// US Letter size (8.5" × 11" / 215.9mm × 279.4mm).
    /// Standard in North America.
    /// Points: 612 × 792
    /// </summary>
    Letter,

    /// <summary>
    /// US Legal size (8.5" × 14" / 215.9mm × 355.6mm).
    /// Common for legal documents in North America.
    /// Points: 612 × 1008
    /// </summary>
    Legal,

    /// <summary>
    /// A3 paper size (297mm × 420mm / 11.69" × 16.54").
    /// Double the size of A4.
    /// Points: 842 × 1191
    /// </summary>
    A3,

    /// <summary>
    /// A5 paper size (148mm × 210mm / 5.83" × 8.27").
    /// Half the size of A4.
    /// Points: 420 × 595
    /// </summary>
    A5,

    /// <summary>
    /// Tabloid/Ledger size (11" × 17" / 279.4mm × 431.8mm).
    /// Common for large prints in North America.
    /// Points: 792 × 1224
    /// </summary>
    Tabloid,

    /// <summary>
    /// Executive size (7.25" × 10.5" / 184.15mm × 266.7mm).
    /// Smaller format, used for personal stationery.
    /// Points: 522 × 756
    /// </summary>
    Executive,

    /// <summary>
    /// B4 paper size (250mm × 353mm / 9.84" × 13.90").
    /// ISO 216 B-series, between A3 and A4.
    /// Points: 709 × 1001
    /// </summary>
    B4,

    /// <summary>
    /// B5 paper size (176mm × 250mm / 6.93" × 9.84").
    /// ISO 216 B-series, between A4 and A5.
    /// Points: 499 × 709
    /// </summary>
    B5
}
