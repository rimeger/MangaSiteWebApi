using Manga.Application.Repositories;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;

namespace Manga.Application.Services
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

        public void Remove(MangaTitle entity)
        {
             _titleRepository.Remove(entity);
        }

        public void Untrack(MangaTitle entity)
        {
            _titleRepository.Untrack(entity);
        }

        public void Update(MangaTitle entity)
        {
            _titleRepository.Update(entity);
        }
    }
}
