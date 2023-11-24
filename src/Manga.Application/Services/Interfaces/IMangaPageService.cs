using Manga.Domain.Entities;

namespace Manga.Application.Services.Interfaces
{
    public interface IMangaPageService
    {
        Task<List<MangaPage>> GetAllAsync();
        Task<MangaPage> GetByIdAsync(Guid id);
        Task CreateAsync(MangaPage entity);
        void Update(MangaPage entity);
        void Remove(MangaPage entity);
        void Untrack(MangaPage entity);
        Task<List<MangaPage>> GetAllByChapterAsync(MangaChapter mangaChapter);
    }
}
