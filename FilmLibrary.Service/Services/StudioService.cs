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
    public class StudioService : GenericService<Studio>, IStudioService
    {
        private readonly IStudioRepository _studioRepository;
        private readonly IMapper _mapper;
        public StudioService(IGenericRepository<Studio> repository, IUnitOfWork unitOfWork, IStudioRepository studioRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _studioRepository = studioRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<FilmsOfStudioDto>> GetStudioByIdWithFilmsAsync(int id)
        {
            var studio = await _studioRepository.GetStudioByIdWithFilmsAsync(id);
            var studioWithFilms = _mapper.Map<FilmsOfStudioDto>(studio);
            return ResponseDto<FilmsOfStudioDto>.Success(200, studioWithFilms);
        }
    }
}
