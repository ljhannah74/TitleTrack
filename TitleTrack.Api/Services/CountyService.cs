using System;
using Microsoft.EntityFrameworkCore;
using TitleTrack.Api.Data;
using TitleTrack.Api.Entities;

namespace TitleTrack.Api.Services;

public class CountyService
{
    private readonly TitleTrackDbContext _db;

    public CountyService(TitleTrackDbContext db)
    {
        _db = db;
    }

    public async Task<List<County>> GetAllAsync()
    {
        return await _db.Counties
            .OrderBy(c => c.State)
            .ThenBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<County> CreateAsync(string name, string state)
    {
        var county = new County
        {
            Name = name,
            State = state
        };

        _db.Counties.Add(county);
        await _db.SaveChangesAsync();
        return county;
    }
}
