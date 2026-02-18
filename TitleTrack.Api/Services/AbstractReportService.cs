using System;
using Microsoft.EntityFrameworkCore;
using TitleTrack.Api.Data;
using TitleTrack.Api.Dtos;
using TitleTrack.Api.Entities;

namespace TitleTrack.Api.Services;

public class AbstractReportService
{
    private readonly TitleTrackDbContext _db;

    public AbstractReportService(TitleTrackDbContext db)
    {
        _db = db;
    }

    public async Task<AbstractReport> CreateAsync(CreateAbstractReportDto dto)
    {
        // Guardrails (domain rules)
        if (dto.SearchDate < dto.OrderDate)
            throw new Exception("SearchDate cannot be before OrderDate");

        if (dto.EffectiveDate < dto.SearchDate)
            throw new Exception("EffectiveDate cannot be before SearchDate");

        // ✅ County validation
        var countyExists = await _db.Counties.AnyAsync(c => c.CountyID == dto.CountyID);
        if (!countyExists)
            throw new Exception($"County with ID {dto.CountyID} does not exist");

        var report = new AbstractReport
        {
            OrderNumber = dto.OrderNumber,
            OrderDate = dto.OrderDate,
            SearchDate = dto.SearchDate,
            EffectiveDate = dto.EffectiveDate,
            PropertyAddress = dto.PropertyAddress,
            ProductType = dto.ProductType,
            CountyID = dto.CountyID,
            CreatedAt = DateTime.UtcNow
        };

        _db.AbstractReports.Add(report);
        await _db.SaveChangesAsync();

        return report;
    }

    public async Task<List<AbstractReport>> GetAllAsync()
    {
        return await _db.AbstractReports
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }
}
