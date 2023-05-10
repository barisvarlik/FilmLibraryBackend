using AutoMapper;
using FilmLibrary.Core.DTOs;
using FilmLibrary.Core.Models;
using FilmLibrary.Core.Repositories;
using FilmLibrary.Core.Services;
using FilmLibrary.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Service.Services
{
    public class FilmService : GenericService<Film>, IFilmService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;
        public FilmService(IGenericRepository<Film> repository, IUnitOfWork unitOfWork, IFilmRepository filmRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<FilmWithCastAndCrewDto>> GetFilmByIdWithCastAndCrewAsync(int id)
        {
            var film = await _filmRepository.GetFilmByIdWithCastAndCrewAsync(id);
            var filmWithCastAndCrew = _mapper.Map<FilmWithCastAndCrewDto>(film);
            return ResponseDto<FilmWithCastAndCrewDto>.Success(200, filmWithCastAndCrew);
        }

        public async Task<ResponseDto<FilmWithCastDto>> GetFilmByIdWithCastAsync(int id)
        {
            var film = await _filmRepository.GetFilmByIdWithCastAsync(id);
            var filmWithCast = _mapper.Map<FilmWithCastDto>(film);
            return ResponseDto<FilmWithCastDto>.Success(200, filmWithCast);
        }
    }
}
