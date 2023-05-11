using FilmLibrary.Core.Models;
using FilmLibrary.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Repository.Repositories
{
    public class FilmRepository : GenericRepository<Film>, IFilmRepository
    {
        public FilmRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Film> GetFilmByIdWithCastAndCrewAsync(int id)
        {
            return await _context.Films.Where(x => x.Id == id).Include(x => x.Cast).SingleOrDefaultAsync();
        }

        public async Task<Film> GetFilmByIdWithCastAsync(int id)
        {
            return await _context.Films.Where(x => x.Id == id).Include(x => x.Cast).SingleOrDefaultAsync();
        }
    }
}
