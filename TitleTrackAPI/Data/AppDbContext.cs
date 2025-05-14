using System;
using Microsoft.EntityFrameworkCore;
using TitleTrackAPI.Models;

namespace TitleTrackAPI.Data;

public class AppDbContext : DbContext
{
    public DbSet<TitleAbstract> TitleAbstracts { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }
}
