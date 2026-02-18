using System;
using System.ComponentModel.DataAnnotations;

namespace TitleTrack.Api.Dtos;

public class CreateAbstractReportDto
{
   [Required]
    public string OrderNumber { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }

    public DateTime SearchDate { get; set; }

    public DateTime EffectiveDate { get; set; }

    [Required]
    public string PropertyAddress { get; set; } = string.Empty;

    [Required]
    public string ProductType { get; set; } = string.Empty;

    public int CountyID { get; set; }
}
