using Manga.Models;

namespace Manga.Repositories.IRepositories
{
    public interface IMangaPageRepository : IRepository<MangaPage>
    {
        Task UpdateAsync(MangaPage mangaPage);
        Task<List<MangaPage>> GetAllByChapter(MangaChapter mangaChapter);
    }
}
