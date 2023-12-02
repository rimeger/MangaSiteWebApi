using Manga.Application.Repositories;
using Manga.Domain.Entities;
using Manga.Infrastructure.DataContext;

namespace Manga.Infrastructure.Repositories
{
    public class MangaTitleRepository : Repository<MangaTitle>, IMangaTitleRepository
    {
        private readonly AppDbContext _dbContext;

        public MangaTitleRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task BookmarkTitle(UserTitle entity)
        {
            await _dbContext.UserTitles.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Update(MangaTitle entity)
        {
            _dbContext.MangaTitles.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
