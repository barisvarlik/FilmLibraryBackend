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
    public class PersonService : GenericService<Person>, IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public PersonService(IGenericRepository<Person> repository, IUnitOfWork unitOfWork, IPersonRepository personRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<DirectorWithFilmsDto>> GetPersonByIdWithFilmsDirectedAsync(int id)
        {
            var person = await _personRepository.GetPersonByIdWithFilmsDirectedAsync(id);
            var personDto = _mapper.Map<DirectorWithFilmsDto>(person);
            return ResponseDto<DirectorWithFilmsDto>.Success(200, personDto);
        }

        public async Task<ResponseDto<ActorWithFilmsDto>> GetPersonByIdWithFilmsStarredAsync(int id)
        {
            var person = await _personRepository.GetPersonByIdWithFilmsStarredAsync(id);
            var personDto = _mapper.Map<ActorWithFilmsDto>(person);
            return ResponseDto<ActorWithFilmsDto>.Success(200, personDto);
        }
    }
}
