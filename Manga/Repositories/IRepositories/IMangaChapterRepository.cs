using Manga.Models;

namespace Manga.Repositories.IRepositories
{
    public interface IMangaChapterRepository : IRepository<MangaChapter>
    {
        Task UpdateAsync(MangaChapter entity);
        Task<List<MangaChapter>> GetAllByTitleAsync(MangaTitle mangaTitle);
    }
}
