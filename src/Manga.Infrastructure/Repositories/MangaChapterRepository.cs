using Manga.Application.Repositories;
using Manga.Domain.Entities;
using Manga.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Manga.Infrastructure.Repositories
{
    public class MangaChapterRepository : Repository<MangaChapter>, IMangaChapterRepository
    {
        private readonly AppDbContext _dbContext;
        public MangaChapterRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MangaChapter>> GetAllByTitleAsync(MangaTitle mangaTitle)
        {
            return await _dbContext.MangaChapters.Where(mc => mc.MangaTitle == mangaTitle).ToListAsync();
        }

        public void Update(MangaChapter entity)
        {
            _dbContext.MangaChapters.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
