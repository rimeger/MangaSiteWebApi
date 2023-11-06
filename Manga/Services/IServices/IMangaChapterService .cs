using Manga.Models;

namespace Manga.Services.IServices
{
    public interface IMangaChapterService
    {
        Task<List<MangaChapter>> GetAllAsync();
        Task<MangaChapter> GetByIdAsync(Guid id);
        Task CreateAsync(MangaChapter entity);
        Task UpdateAsync(MangaChapter entity);
        Task RemoveAsync(MangaChapter entity);
        Task Untrack(MangaChapter entity);
        Task<List<MangaChapter>> GetAllByTitleAsync(MangaTitle mangaTitle);
    }
}
