using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FilmLibrary.Core.DTOs;
using FilmLibrary.Core.Models;

namespace FilmLibrary.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Film, FilmDto>().ReverseMap();
            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Studio, StudioDto>().ReverseMap();
            CreateMap<Film, FilmWithCastDto>();
            CreateMap<Film, FilmWithCastAndCrewDto>();
            CreateMap<Person, ActorWithFilmsDto>();
            CreateMap<Person, DirectorWithFilmsDto>();
            CreateMap<Studio, FilmsOfStudioDto>();
        }
    }
}
