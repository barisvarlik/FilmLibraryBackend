using AutoMapper;
using FilmLibrary.Core.DTOs;
using FilmLibrary.Core.Models;
using FilmLibrary.Core.Services;
using FilmLibrary.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T, Y> where T : class
    {
        private readonly IGenericService<T> _service;
        private readonly IMapper _mapper;

        public GenericController(IGenericService<T> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult CreateActionResult<D>(ResponseDto<D> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,
            };
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var entity = await _service.GetAllAsync();
            var dto = _mapper.Map<List<Y>>(entity);

            return CreateActionResult(ResponseDto<List<Y>>.Success(200, dto));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            var dto = _mapper.Map<Y>(entity);

            return CreateActionResult(ResponseDto<Y>.Success(200, dto));
        }
        [HttpPost]
        public async Task<IActionResult> Save(Y dto)
        {
            var entity = _mapper.Map<T>(dto);
            var entitySaved = await _service.CreateAsync(entity);
            var dtoReturn = _mapper.Map<Y>(entitySaved);

            return CreateActionResult(ResponseDto<Y>.Success(201, dtoReturn));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Y dto)
        {
            await _service.UpdateAsync(_mapper.Map<T>(dto));
            return CreateActionResult(ResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            await _service.DeleteAsync(entity);

            return CreateActionResult(ResponseDto<NoContentDto>.Success(204));
        }
    }
}
