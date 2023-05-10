using AutoMapper;
using FilmLibrary.Core.DTOs;
using FilmLibrary.Core.Models;
using FilmLibrary.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmLibrary.API.Controllers
{
    public class FilmsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IFilmService _filmService;

        public FilmsController(IMapper mapper, IFilmService filmService)
        {
            _mapper = mapper;
            _filmService = filmService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var films = await _filmService.GetAllAsync();
            var filmsDto = _mapper.Map<List<FilmDto>>(films);

            return CreateActionResult(ResponseDto<List<FilmDto>>.Success(200, filmsDto));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var film = await _filmService.GetByIdAsync(id);
            var filmDto = _mapper.Map<FilmDto>(film);

            return CreateActionResult(ResponseDto<FilmDto>.Success(200, filmDto));
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
        [HttpPost]
        public async Task<IActionResult> Save(FilmDto filmDto)
        {
            var film = _mapper.Map<Film>(filmDto);
            var filmSaved = await _filmService.CreateAsync(film);
            var filmToReturn = _mapper.Map<FilmDto>(filmSaved);

            return CreateActionResult(ResponseDto<FilmDto>.Success(201, filmToReturn));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var film = await _filmService.GetByIdAsync(id);
            await _filmService.UpdateAsync(film);

            return CreateActionResult(ResponseDto<FilmDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var film = await _filmService.GetByIdAsync(id);
            await _filmService.DeleteAsync(film);

            return CreateActionResult(ResponseDto<FilmDto>.Success(204));
        }
    }
}
