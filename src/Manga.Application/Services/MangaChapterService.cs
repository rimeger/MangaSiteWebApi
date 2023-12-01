using Manga.Application.Repositories;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;

namespace Manga.Application.Services
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

        public async Task LikeChapter(User user, MangaChapter entity)
        {
            UserChapter likedChapter = new UserChapter
            {
                User = user,
                UserId = user.Id,
                MangaChapter = entity,
                ChapterId = entity.Id
            };
            await _chapterRepository.LikeChapter(likedChapter);
        }

        public void Remove(MangaChapter entity)
        {
            _chapterRepository.Remove(entity);
        }

        public void Untrack(MangaChapter entity)
        {
            _chapterRepository.Untrack(entity);
        }

        public void Update(MangaChapter entity)
        {
            _chapterRepository.Update(entity);
        }
    }
}
