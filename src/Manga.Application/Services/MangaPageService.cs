using Manga.Application.Repositories;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;

namespace Manga.Application.Services
{
    public class MangaPageService : IMangaPageService
    {
        private readonly IMangaPageRepository _pageRepository;

        public MangaPageService(IMangaPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }
        public async Task CreateAsync(MangaPage entity)
        {
            await _pageRepository.CreateAsync(entity);
        }

        public async Task<List<MangaPage>> GetAllAsync()
        {
            return await _pageRepository.GetAllAsync();
        }

        public async Task<List<MangaPage>> GetAllByChapterAsync(MangaChapter mangaChapter)
        {
            return await _pageRepository.GetAllByChapterAsync(mangaChapter);
        }

        public async Task<MangaPage> GetByIdAsync(Guid id)
        {
            return await _pageRepository.GetByIdAsync(id);
        }

        public void Remove(MangaPage entity)
        {
            _pageRepository.Remove(entity);
        }

        public void Untrack(MangaPage entity)
        {
            _pageRepository.Untrack(entity);
        }

        public void Update(MangaPage entity)
        {
            _pageRepository.Update(entity);
        }
    }
}
