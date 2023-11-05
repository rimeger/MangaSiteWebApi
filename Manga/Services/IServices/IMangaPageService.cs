using Manga.Models;

namespace Manga.Services.IServices
{
    public interface IMangaPageService
    {
        Task<List<MangaPage>> GetAllAsync();
        Task<MangaPage> GetByIdAsync(Guid id);
        Task CreateAsync(MangaPage entity);
        Task UpdateAsync(MangaPage entity);
        Task RemoveAsync(MangaPage entity);
        Task<List<MangaPage>> GetAllByChapterAsync(MangaChapter mangaChapter);
    }
}
