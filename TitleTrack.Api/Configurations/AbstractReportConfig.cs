using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TitleTrack.Api.Entities;

namespace TitleTrack.Api.Configurations;

public class AbstractReportConfig : IEntityTypeConfiguration<AbstractReport>
{
    public void Configure(EntityTypeBuilder<AbstractReport> builder)
    {
        builder.ToTable("AbstractReports");

        builder.HasKey(x => x.ReportID);

        builder.Property(x => x.OrderNumber)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.PropertyAddress)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(x => x.ProductType)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.OrderDate)
            .IsRequired();

        builder.Property(x => x.EffectiveDate)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasIndex(x => x.OrderNumber)
            .IsUnique();

        builder.HasIndex(x => x.PropertyAddress);

        builder.HasQueryFilter(x => !x.IsDeleted); // soft delete filter

        builder.Property(x => x.SearchDate)
            .IsRequired();

        builder.HasIndex(x => x.SearchDate);
    }
}
