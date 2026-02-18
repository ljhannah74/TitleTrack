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

    public async Task<AbstractReportDto?> GetByIdAsync(int id)
    {
        return await _db.AbstractReports
            .Where(r => r.ReportID == id)
            .Select(r => new AbstractReportDto
            {
                Id = r.ReportID,
                OrderNumber = r.OrderNumber,
                OrderDate = r.OrderDate,
                SearchDate = r.SearchDate,
                EffectiveDate = r.EffectiveDate,
                PropertyAddress = r.PropertyAddress,
                ProductType = r.ProductType,
                CountyId = r.CountyID,
                CountyName = r.County.Name
            })
            .FirstOrDefaultAsync();
    }

    public async Task<List<AbstractReportDto>> SearchAsync(
    DateTime? fromDate,
    DateTime? toDate,
    int? countyId,
    string? productType)
    {
        var query = _db.AbstractReports.AsQueryable();

        if (fromDate.HasValue)
            query = query.Where(r => r.SearchDate >= fromDate.Value);

        if (toDate.HasValue)
            query = query.Where(r => r.SearchDate <= toDate.Value);

        if (countyId.HasValue)
            query = query.Where(r => r.CountyID == countyId.Value);

        if (!string.IsNullOrEmpty(productType))
            query = query.Where(r => r.ProductType == productType);

        return await query
            .Select(r => new AbstractReportDto
            {
                Id = r.ReportID,
                OrderNumber = r.OrderNumber,
                OrderDate = r.OrderDate,
                SearchDate = r.SearchDate,
                EffectiveDate = r.EffectiveDate,
                PropertyAddress = r.PropertyAddress,
                ProductType = r.ProductType,
                CountyId = r.CountyID,
                CountyName = r.County.Name
            })
            .OrderByDescending(r => r.SearchDate)
            .ToListAsync();
    }

}
