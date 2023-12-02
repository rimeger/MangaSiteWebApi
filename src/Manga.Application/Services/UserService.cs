using Manga.Application.Repositories;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task CreateAsync(User entity)
        {
             await _userRepository.CreateAsync(entity);
        }

        public async Task<List<MangaTitle>> GetBookmarksAsync(Guid userId)
        {
            return await _userRepository.GetBookmarksAsync(userId); ;
        }

        public async Task<User> GetByUserName(string username)
        {
           return await _userRepository.GetByUserName(username);
        }

        public async Task<List<MangaChapter>> GetLikedChaptersAsync(Guid userId)
        {
            return await _userRepository.GetLikedChaptersAsync(userId);
        }

        public void Remove(User entity)
        {
            _userRepository.Remove(entity);
        }

        public void Untrack(User entity)
        {
            _userRepository.Untrack(entity);
        }

        public void Update(User entity)
        {
            _userRepository.Untrack(entity);
        }
    }
}
