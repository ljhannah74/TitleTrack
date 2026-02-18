using System;
using System.ComponentModel.DataAnnotations;

namespace TitleTrack.Api.Entities;

public class County
{
    [Key]
    public int CountyID { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string State { get; set; } = string.Empty;

    // Navigation
    public ICollection<AbstractReport> AbstractReports { get; set; } = new List<AbstractReport>();
}
