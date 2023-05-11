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
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Person> GetPersonByIdWithFilmsDirectedAsync(int id)
        {
            return await _context.People.Where(x => x.Id == id).Include(x => x.FilmsDirected).SingleOrDefaultAsync();
        }

        public async Task<Person> GetPersonByIdWithFilmsStarredAsync(int id)
        {
            return await _context.People.Where(x => x.Id == id).Include(x => x.FilmsStarred).SingleOrDefaultAsync();
        }
    }
}
