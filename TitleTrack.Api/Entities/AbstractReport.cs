using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    [ForeignKey(nameof(CountyID))]
    public County County { get; set; } = null!;

    public ICollection<Document> Documents { get; set; } = new List<Document>();
}
