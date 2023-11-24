using Manga.Domain.Entities;

namespace Manga.Application.Services.Interfaces
{
    public interface IMangaTitleService
    {
        Task<List<MangaTitle>> GetAllAsync();
        Task<MangaTitle> GetByIdAsync(Guid id);
        Task CreateAsync(MangaTitle entity);
        void Update(MangaTitle entity);
        void Remove(MangaTitle entity);
        void Untrack(MangaTitle entity);
    }
}
