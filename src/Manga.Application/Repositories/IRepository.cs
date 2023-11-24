namespace Manga.Application.Repositories
{
    public interface IRepository<T> where T: class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync (Guid id);
        Task CreateAsync (T entity);
        void Remove (T entity);
        void Untrack(T entity);
    }
}
