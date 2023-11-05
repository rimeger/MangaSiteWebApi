using Manga.Models;
using Manga.Repositories.IRepositories;
using Manga.Services.IServices;

namespace Manga.Services
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

        public async Task RemoveAsync(MangaPage entity)
        {
            await _pageRepository.RemoveAsync(entity);
        }

        public async Task UpdateAsync(MangaPage entity)
        {
            await _pageRepository.UpdateAsync(entity);
        }
    }
}
