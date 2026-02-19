using System;

namespace TitleTrack.Api.Dtos;

public class DocumentDto
{
    public int Id { get; set; }
    public int AbstractReportId { get; set; }

    public string DocumentType { get; set; } = "";
    public string InstrumentNumber { get; set; } = "";
    public DateTime RecordingDate { get; set; }

    public string Grantor { get; set; } = "";
    public string Grantee { get; set; } = "";

    public decimal? Amount { get; set; }

    public string Book { get; set; } = "";
    public string Page { get; set; } = "";

    public string Notes { get; set; } = "";
}
