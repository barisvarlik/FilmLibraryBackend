using FilmLibrary.Core.DTOs;
using FilmLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Core.Services
{
    public interface IStudioService : IGenericService<Studio>
    {
        Task<ResponseDto<FilmsOfStudioDto>> GetStudioByIdWithFilmsAsync(int id);
    }
}
