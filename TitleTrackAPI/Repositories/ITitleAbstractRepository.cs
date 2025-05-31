using System;
using TitleTrackAPI.Models;

namespace TitleTrackAPI.Repositories;

public interface ITitleAbstractRepository
{
    Task<IEnumerable<TitleAbstract>> GetAllAsync();
    Task<TitleAbstract?> GetByIdAsync(int id);
    Task<TitleAbstract?> GetByOrderNoAsync(string orderNumber);
    Task AddTitleAbstractAsync(TitleAbstract titleAbstract);
    Task UpdateTitleAbstractAsync(TitleAbstract titleAbstract);
    Task DeleteTitleAbstractAsync(int id);
}
