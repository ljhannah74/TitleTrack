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
    public DbSet<County> Counties => Set<County>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AbstractReportConfig());
        modelBuilder.ApplyConfiguration(new CountyConfig());

        // ✅ Seed data
        SeedData.Seed(modelBuilder);
    }
}
