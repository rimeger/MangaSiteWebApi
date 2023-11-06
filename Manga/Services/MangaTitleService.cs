using Manga.Models;
using Manga.Repositories.IRepositories;
using Manga.Services.IServices;

namespace Manga.Services
{
    public class MangaTitleService : IMangaTitleService
    {
        private readonly IMangaTitleRepository _titleRepository;

        public MangaTitleService(IMangaTitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }
        public async Task CreateAsync(MangaTitle entity)
        {
            await _titleRepository.CreateAsync(entity);
        }

        public async Task<List<MangaTitle>> GetAllAsync()
        {
            return await _titleRepository.GetAllAsync();
        }

        public async Task<MangaTitle> GetByIdAsync(Guid id)
        {
            return await _titleRepository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(MangaTitle entity)
        {
            await _titleRepository.RemoveAsync(entity);
        }

        public async Task Untrack(MangaTitle entity)
        {
             await _titleRepository.Untrack(entity);
        }

        public async Task UpdateAsync(MangaTitle entity)
        {
            await _titleRepository.UpdateAsync(entity);
        }
    }
}
