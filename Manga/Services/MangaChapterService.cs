using Manga.Models;
using Manga.Repositories.IRepositories;
using Manga.Services.IServices;

namespace Manga.Services
{
    public class MangaChapterService : IMangaChapterService
    {
        private readonly IMangaChapterRepository _chapterRepository;

        public MangaChapterService(IMangaChapterRepository chapterRepository)
        {
            _chapterRepository = chapterRepository;
        }
        public async Task CreateAsync(MangaChapter entity)
        {
            await _chapterRepository.CreateAsync(entity);
        }

        public async Task<List<MangaChapter>> GetAllAsync()
        {
            return await _chapterRepository.GetAllAsync();
        }

        public async Task<List<MangaChapter>> GetAllByTitleAsync(MangaTitle mangaTitle)
        {
            return await _chapterRepository.GetAllByTitleAsync(mangaTitle);
        }

        public async Task<MangaChapter> GetByIdAsync(Guid id)
        {
            return await _chapterRepository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(MangaChapter entity)
        {
            await _chapterRepository.RemoveAsync(entity);
        }

        public async Task Untrack(MangaChapter entity)
        {
            await _chapterRepository.Untrack(entity);
        }

        public async Task UpdateAsync(MangaChapter entity)
        {
            await _chapterRepository.UpdateAsync(entity);
        }
    }
}
