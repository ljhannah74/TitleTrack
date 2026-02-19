using System;
using Microsoft.EntityFrameworkCore;
using TitleTrack.Api.Data;
using TitleTrack.Api.Dtos;
using TitleTrack.Api.Entities;

namespace TitleTrack.Api.Services;

public class DocumentService
{
    private readonly TitleTrackDbContext _db;

    public DocumentService(TitleTrackDbContext db)
    {
        _db = db;
    }

    public async Task<List<DocumentDto>> GetByAbstractReportAsync(int abstractReportId)
    {
        return await _db.Documents
            .Where(d => d.AbstractReportId == abstractReportId)
            .Select(d => new DocumentDto
            {
                Id = d.Id,
                AbstractReportId = d.AbstractReportId,
                DocumentType = d.DocumentType,
                InstrumentNumber = d.InstrumentNumber,
                RecordingDate = d.RecordingDate,
                Grantor = d.Grantor,
                Grantee = d.Grantee,
                Amount = d.Amount,
                Book = d.Book,
                Page = d.Page,
                Notes = d.Notes
            })
            .ToListAsync();
    }

    public async Task<DocumentDto> CreatAsync(DocumentDto dto)
    {
        // Validation
        var reportExists = await _db.AbstractReports.AnyAsync(r => r.ReportID == dto.AbstractReportId);

        if (!reportExists)
            throw new Exception("AbstractReport not found");

        var doc = new Document
        {
            AbstractReportId = dto.AbstractReportId,
            DocumentType = dto.DocumentType,
            InstrumentNumber = dto.InstrumentNumber,
            RecordingDate = dto.RecordingDate,
            Grantor = dto.Grantor,
            Grantee = dto.Grantee,
            Amount = dto.Amount,
            Book = dto.Book,
            Page = dto.Page,
            Notes = dto.Notes
        };

        _db.Documents.Add(doc);
        await _db.SaveChangesAsync();

        dto.Id = doc.Id;
        return dto; 
    }
}
