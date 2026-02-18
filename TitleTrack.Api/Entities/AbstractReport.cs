using System;
using System.ComponentModel.DataAnnotations;

namespace TitleTrack.Api.Entities;

public class AbstractReport
{
   [Key]
    public int ReportID { get; set; }

    [Required]
    public string OrderNumber { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }
    public DateTime SearchDate { get; set; }
    public DateTime EffectiveDate { get; set; }

    [Required]
    public string PropertyAddress { get; set; } = string.Empty;

    [Required]
    public string ProductType { get; set; } = string.Empty;

    // FK
    public int CountyID { get; set; }

    // Audit
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; } = false;

    // Navigation

    // these will be added later
    // [ForeignKey(nameof(CountyID))]
    // public County County { get; set; } = null!;

    // public ICollection<Deed> Deeds { get; set; } = new List<Deed>();
    // public ICollection<Mortgage> Mortgages { get; set; } = new List<Mortgage>();
    // public ICollection<Judgment> Judgments { get; set; } = new List<Judgment>();
    // public ICollection<TaxInfo> TaxInfos { get; set; } = new List<TaxInfo>();
    // public ICollection<Document> Documents { get; set; } = new List<Document>();
}
