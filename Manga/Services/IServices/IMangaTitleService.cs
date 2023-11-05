using Manga.Models;

namespace Manga.Services.IServices
{
    public interface IMangaTitleService
    {
        Task<List<MangaTitle>> GetAllAsync();
        Task<MangaTitle> GetByIdAsync(Guid id);
        Task CreateAsync(MangaTitle entity);
        Task UpdateAsync(MangaTitle entity);
        Task RemoveAsync(MangaTitle entity);
    }
}
