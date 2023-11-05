using Manga.Models;

namespace Manga.Repositories.IRepositories
{
    public interface IMangaTitleRepository : IRepository<MangaTitle>
    {
        Task UpdateAsync(MangaTitle entity);
        Task Untrack(MangaTitle entity);
    }
}
