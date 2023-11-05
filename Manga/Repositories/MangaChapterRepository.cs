using Manga.Data;
using Manga.Models;
using Manga.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Manga.Repositories
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

        public async Task UpdateAsync(MangaChapter entity)
        {
            _dbContext.MangaChapters.Update(entity);
            await SaveAsync();
        }
    }
}
