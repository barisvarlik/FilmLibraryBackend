using AutoMapper;
using FilmLibrary.Core.DTOs;
using FilmLibrary.Core.Models;
using FilmLibrary.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmLibrary.API.Controllers
{
    public class FilmsController : GenericController<Film, FilmDto>
    {
        private readonly IFilmService _filmService;
        public FilmsController(IMapper mapper, IGenericService<Film> service, IFilmService filmService) : base(service, mapper)
        {
            _filmService = filmService;
        }
        [HttpGet("{id}/castAndCrew")]
        public async Task<IActionResult> GetCastAndCrew(int id)
        {
            return CreateActionResult(await _filmService.GetFilmByIdWithCastAndCrewAsync(id));
        }
        [HttpGet("{id}/cast")]
        public async Task<IActionResult> GetCast(int id)
        {
            return CreateActionResult(await _filmService.GetFilmByIdWithCastAsync(id));
        }
    }
}
