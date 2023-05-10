using FilmLibrary.Core.DTOs;
using FilmLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Core.Services
{
    public interface IFilmService : IGenericService<Film>
    {
        Task<ResponseDto<FilmWithCastDto>> GetFilmByIdWithCastAsync(int id);
        Task<ResponseDto<FilmWithCastAndCrewDto>> GetFilmByIdWithCastAndCrewAsync(int id);
    }
}
