using Manga.Domain.Entities;

namespace Manga.Application.Repositories
{
    public interface IMangaPageRepository : IRepository<MangaPage>
    {
        Task UpdateAsync(MangaPage mangaPage);
        Task<List<MangaPage>> GetAllByChapterAsync(MangaChapter mangaChapter);
    }
}
