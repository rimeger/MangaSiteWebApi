using Manga.Data;
using Manga.Models;
using Manga.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Manga.Repositories
{
    public class MangaTitleRepository : Repository<MangaTitle>, IMangaTitleRepository
    {
        private readonly AppDbContext _dbContext;

        public MangaTitleRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Untrack(MangaTitle entity)
        {
            _dbContext.Entry(entity).State = EntityState.Detached;
        }

        public async Task UpdateAsync(MangaTitle entity)
        {
            _dbContext.MangaTitles.Update(entity);
            await SaveAsync();
        }
    }
}
