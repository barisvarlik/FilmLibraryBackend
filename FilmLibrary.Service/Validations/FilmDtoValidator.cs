using FilmLibrary.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Service.Validations
{
    public class FilmDtoValidator : AbstractValidator<FilmDto>
    {
        public FilmDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(200).WithMessage("{PropertyName} is required").NotEmpty();
            RuleFor(x => x.Length).InclusiveBetween(5, 1000).WithMessage("{PropertyName} should be in minutes");
            RuleFor(x => x.Year).InclusiveBetween(DateTime.MinValue, DateTime.UtcNow).WithMessage("{PropertyName} should be a valid year");
            RuleFor(x => x.GenreId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} should be greater than 0");
            RuleFor(x => x.DirectorId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} should be greater than 0");
            RuleFor(x => x.StudioId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} should be greater than 0");
        }
    }
}
