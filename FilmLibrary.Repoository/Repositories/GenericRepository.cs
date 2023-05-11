using FilmLibrary.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FilmLibrary.Core.Interfaces;

namespace FilmLibrary.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IDeletable
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task CreateRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
            }
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable().Where(x => x.IsDeleted == false);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity.IsDeleted == false)
                return entity;
            else return null;
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
