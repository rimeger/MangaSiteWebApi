using Manga.Application.Repositories;
using Manga.Domain.Entities;
using Manga.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Manga.Infrastructure.Repositories
{
    public class MangaPageRepository : Repository<MangaPage>, IMangaPageRepository
    {
        private readonly AppDbContext _dbContext;
        public MangaPageRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MangaPage>> GetAllByChapterAsync(MangaChapter mangaChapter)
        {
            return await _dbContext.MangaPages.Where(mp => mp.MangaChapter == mangaChapter).ToListAsync();
        }

        public void Update(MangaPage mangaPage)
        {
            _dbContext.MangaPages.Update(mangaPage);
        }
    }
}
