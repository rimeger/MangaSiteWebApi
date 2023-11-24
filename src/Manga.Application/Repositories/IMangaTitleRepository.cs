using Manga.Domain.Entities;

namespace Manga.Application.Repositories
{
    public interface IMangaTitleRepository : IRepository<MangaTitle>
    {
        void Update(MangaTitle entity);
    }
}
