namespace Manga.Application.Repositories
{
    public interface IRepository<T> where T: class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync (Guid id);
        Task CreateAsync (T entity);
        Task RemoveAsync (T entity);
        Task Untrack(T entity);
        Task SaveAsync();
    }
}
