using FilmLibrary.Core.Models;
using FilmLibrary.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Repoository.Repositories
{
    public class StudioRepository : GenericRepository<Studio>, IStudioRepository
    {
        public StudioRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Studio> GetStudioByIdWithFilmsAsync(int id)
        {
            return await _context.Studios.Where(x => x.Id == id).Include(x => x.FilmsProduced).SingleOrDefaultAsync();
        }
    }
}
