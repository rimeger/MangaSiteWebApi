using Manga.Domain.Entities;

namespace Manga.Application.Services.Interfaces
{
    public interface IMangaTitleService
    {
        Task<List<MangaTitle>> GetAllAsync();
        Task<MangaTitle> GetByIdAsync(Guid id);
        Task CreateAsync(MangaTitle entity);
        Task UpdateAsync(MangaTitle entity);
        Task RemoveAsync(MangaTitle entity);
        Task Untrack(MangaTitle entity);
    }
}
