using FilmLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Core.Repositories
{
    public interface IStudioRepository : IGenericRepository<Studio>
    {
        Task<Studio> GetStudioByIdWithFilmsAsync(int id);
    }
}
