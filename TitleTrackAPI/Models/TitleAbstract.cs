using System;
using System.ComponentModel.DataAnnotations;

namespace TitleTrackAPI.Models;

public class TitleAbstract
{
    public int TitleAbstractID { get; set; }

    [Required]
    public string OrderNo { get; set; }

    [Required]
    public DateTime SearchDate { get; set; }
    public DateTime EffectiveDate { get; set; }
    public string Client { get; set; }
    public string ClientRefNo { get; set; }
    public string PropertyAddress { get; set; }
    public string ProductType { get; set; }
}
