using System;
using Microsoft.EntityFrameworkCore;
using TitleTrackAPI.Data;
using TitleTrackAPI.Models;

namespace TitleTrackAPI.Repositories;

public class TitleAbstractRepository : ITitleAbstractRepository
{
    private readonly AppDbContext _context;
    public TitleAbstractRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddTitleAbstractAsync(TitleAbstract titleAbstract)
    {
        await _context.TitleAbstracts.AddAsync(titleAbstract);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTitleAbstractAsync(int id)
    {
        var titleAbstract = _context.TitleAbstracts.Find(id);
        if (titleAbstract == null)
        {
            throw new KeyNotFoundException($"TitleAbstract with ID {id} not found.");
        }

        _context.TitleAbstracts.Remove(titleAbstract);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TitleAbstract>> GetAllAsync()
    {
        return await _context.TitleAbstracts.ToListAsync();
    }

    public async Task<TitleAbstract?> GetByIdAsync(int id)
    {
        return await _context.TitleAbstracts.FindAsync(id);
    }

    public async Task<TitleAbstract?> GetByOrderNoAsync(string orderNumber)
    {
        return await _context.TitleAbstracts
            .FirstOrDefaultAsync(ta => ta.OrderNo == orderNumber);
    }

    public async Task UpdateTitleAbstractAsync(TitleAbstract titleAbstract)
    {
        _context.TitleAbstracts.Update(titleAbstract);
        await _context.SaveChangesAsync();
    }
}
