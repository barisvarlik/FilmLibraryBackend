using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Core.Services
{
    public interface IGenericService<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> entities);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}
