using AutoMapper;
using FilmLibrary.Core.DTOs;
using FilmLibrary.Core.Models;
using FilmLibrary.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : GenericController<Person, PersonDto>
    {
        private readonly IPersonService _personService;

        public PersonController(IGenericService<Person> service, IMapper mapper, IPersonService personService) : base(service, mapper)
        {
            _personService = personService;
        }

        [HttpGet("{id}/starred")]
        public async Task<IActionResult> GetByIdWithMoviesStarredAsync(int id)
        {
            return CreateActionResult(await _personService.GetPersonByIdWithFilmsStarredAsync(id));
        }
        [HttpGet("{id}/directed")]
        public async Task<IActionResult> GetByIdWithMoviesDirectedAsync(int id)
        {
            return CreateActionResult(await _personService.GetPersonByIdWithFilmsDirectedAsync(id));
        }
    }
}
