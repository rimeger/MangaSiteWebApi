using Manga.Domain.Entities;

namespace Manga.Application.Repositories
{
    public interface IMangaTitleRepository : IRepository<MangaTitle>
    {
        Task UpdateAsync(MangaTitle entity);
    }
}
