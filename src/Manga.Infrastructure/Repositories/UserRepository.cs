using Manga.Application.Repositories;
using Manga.Domain.Entities;
using Manga.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByUserName(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName.Equals(username));
        }

        public async Task<List<MangaChapter>> GetLikedChaptersAsync(Guid userId)
        {
            return await _dbContext.UserChapters
                .Where(uc => uc.UserId == userId)
                .Select(uc => uc.MangaChapter)
                .ToListAsync();    
        }

        public void Update(User entity)
        {
            _dbContext.Users.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
