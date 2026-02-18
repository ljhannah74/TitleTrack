using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TitleTrack.Api.Entities;

namespace TitleTrack.Api.Configurations;

public class CountyConfig : IEntityTypeConfiguration<County>
{
    public void Configure(EntityTypeBuilder<County> builder)
    {
        builder.ToTable("Counties");

        builder.HasKey(c => c.CountyID);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.State)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(c => new { c.Name, c.State })
            .IsUnique();
    }
}
