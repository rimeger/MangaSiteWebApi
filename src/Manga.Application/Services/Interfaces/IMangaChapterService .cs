using Manga.Domain.Entities;

namespace Manga.Application.Services.Interfaces
{
    public interface IMangaChapterService
    {
        Task<List<MangaChapter>> GetAllAsync();
        Task<MangaChapter> GetByIdAsync(Guid id);
        Task CreateAsync(MangaChapter entity);
        void Update(MangaChapter entity);
        void Remove(MangaChapter entity);
        void Untrack(MangaChapter entity);
        Task<List<MangaChapter>> GetAllByTitleAsync(MangaTitle mangaTitle);
    }
}
