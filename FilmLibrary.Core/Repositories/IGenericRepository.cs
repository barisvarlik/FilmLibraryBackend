using FilmLibrary.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Core.Repositories
{
    public interface IGenericRepository<T> where T : class, IDeletable
    {
        Task CreateAsync(T entity);
        Task CreateRangeAsync(IEnumerable<T> entities);
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
