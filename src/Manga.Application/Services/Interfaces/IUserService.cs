using Manga.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByUserName(string username);
        Task CreateAsync(User entity);
        void Update(User entity);
        void Remove(User entity);
        void Untrack(User entity);
        Task<List<MangaChapter>> GetLikedChaptersAsync(Guid userId);
    }
}
