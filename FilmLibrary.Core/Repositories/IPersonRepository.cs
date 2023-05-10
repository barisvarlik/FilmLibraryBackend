using FilmLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Core.Repositories
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<Person> GetPersonByIdWithFilmsStarredAsync(int id);
        Task<Person> GetPersonByIdWithFilmsDirectedAsync(int id);
    }
}
