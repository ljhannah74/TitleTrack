using System;
using Microsoft.EntityFrameworkCore;
using TitleTrack.Api.Entities;

namespace TitleTrack.Api.Data;

public class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<County>().HasData(
            new County { CountyID = 1, Name = "Miami-Dade", State = "FL" },
            new County { CountyID = 2, Name = "Broward", State = "FL" },
            new County { CountyID = 3, Name = "Palm Beach", State = "FL" },
            new County { CountyID = 4, Name = "Los Angeles", State = "CA" },
            new County { CountyID = 5, Name = "Orange", State = "CA" }
        );
    }
}
