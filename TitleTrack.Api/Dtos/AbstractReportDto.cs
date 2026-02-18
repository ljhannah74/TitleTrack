using System;

namespace TitleTrack.Api.Dtos;

public class AbstractReportDto
{
    public int Id { get; set; }
    public string OrderNumber { get; set; } = "";
    public DateTime OrderDate { get; set; }
    public DateTime SearchDate { get; set; }
    public DateTime EffectiveDate { get; set; }
    public string PropertyAddress { get; set; } = "";
    public string ProductType { get; set; } = "";

    public int CountyId { get; set; }
    public string CountyName { get; set; } = "";
}
