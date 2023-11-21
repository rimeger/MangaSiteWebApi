using Manga.Domain.Entities;

namespace Manga.Application.Repositories
{
    public interface IMangaChapterRepository : IRepository<MangaChapter>
    {
        Task UpdateAsync(MangaChapter entity);
        Task<List<MangaChapter>> GetAllByTitleAsync(MangaTitle mangaTitle);
    }
}
