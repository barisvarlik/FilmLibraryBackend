using FilmLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Core.Repositories
{
    public interface IFilmRepository : IGenericRepository<Film>
    {
        Task<Film> GetFilmByIdWithCastAsync(int id);
        Task<Film> GetFilmByIdWithCastAndCrewAsync(int id);
    }
}
