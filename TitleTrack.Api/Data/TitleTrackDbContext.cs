using Microsoft.EntityFrameworkCore;
using TitleTrack.Api.Configurations;
using TitleTrack.Api.Entities;

namespace TitleTrack.Api.Data;

public class TitleTrackDbContext : DbContext
{
    public TitleTrackDbContext(DbContextOptions<TitleTrackDbContext> options)
        : base(options)
    {
    }

    public DbSet<AbstractReport> AbstractReports => Set<AbstractReport>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AbstractReportConfig());
    }
}
