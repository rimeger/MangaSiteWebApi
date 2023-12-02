using Manga.Domain.Entities;

namespace Manga.Application.Repositories
{
    public interface IMangaChapterRepository : IRepository<MangaChapter>
    {
        void Update(MangaChapter entity);
        Task<List<MangaChapter>> GetAllByTitleAsync(MangaTitle mangaTitle);
        Task LikeChapter(UserChapter entity);
    }
}
