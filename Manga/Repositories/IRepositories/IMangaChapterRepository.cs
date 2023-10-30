using Manga.Models;

namespace Manga.Repositories.IRepositories
{
    public interface IMangaChapter : IRepository<MangaChapter>
    {
        Task UpdateAsync(MangaChapter entity);
        Task<List<MangaChapter>> GetAllByTitle(MangaTitle mangaTitle);
    }
}
