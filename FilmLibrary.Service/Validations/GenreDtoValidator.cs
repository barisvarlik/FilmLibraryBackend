using FilmLibrary.Core.DTOs;
using FilmLibrary.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Service.Validations
{
    public class GenreDtoValidator : AbstractValidator<GenreDto>
    {
        public GenreDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(200).WithMessage("{PropertyName} should not be empty").NotEmpty();
        }
    }
}
