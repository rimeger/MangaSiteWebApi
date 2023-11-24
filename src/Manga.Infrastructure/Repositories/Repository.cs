﻿using Manga.Application.Repositories;
using Manga.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Manga.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Untrack(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Detached;
        }
    }
}