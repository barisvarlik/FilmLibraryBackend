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
    public class StudioController : GenericController<Studio, StudioDto>
    {
        private readonly IStudioService _studioService;
        public StudioController(IGenericService<Studio> service, IMapper mapper, IStudioService studioService) : base(service, mapper)
        {
            _studioService = studioService;
        }

        [HttpGet("{id}/filmsProduced")]
        public async Task<IActionResult> GetFilms(int id)
        {
            return CreateActionResult(await _studioService.GetStudioByIdWithFilmsAsync(id));
        }
    }
}
