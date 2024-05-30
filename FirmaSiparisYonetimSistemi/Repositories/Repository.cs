﻿using FirmaSiparisYonetimSistemi.Data;
using Microsoft.EntityFrameworkCore;

namespace FirmaSiparisYonetimSistemi.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            _dbSet.AddAsync(entity);
        }


        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void  Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
