using Manga.Data;
using Manga.Models;
using Manga.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Manga.Repositories
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

        public async Task UpdateAsync(MangaPage mangaPage)
        {
            _dbContext.MangaPages.Update(mangaPage);
            await SaveAsync();
        }
    }
}
