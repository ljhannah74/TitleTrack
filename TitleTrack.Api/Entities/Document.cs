using System;

namespace TitleTrack.Api.Entities;

public class Document
{
    public int Id { get; set; }

    // FK
    public int AbstractReportId { get; set; }
    public AbstractReport AbstractReport { get; set; } = null!;

    // Core fields
    public string DocumentType { get; set; } = "";   // Deed, Mortgage, Lien, etc
    public string InstrumentNumber { get; set; } = "";

    public DateTime RecordingDate { get; set; }

    // Parties
    public string Grantor { get; set; } = "";
    public string Grantee { get; set; } = "";

    // Financial
    public decimal? Amount { get; set; }

    // Recording reference
    public string Book { get; set; } = "";
    public string Page { get; set; } = "";

    public string Notes { get; set; } = "";
}
