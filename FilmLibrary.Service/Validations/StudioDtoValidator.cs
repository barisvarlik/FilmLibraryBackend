using FilmLibrary.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Service.Validations
{
    public class StudioDtoValidator : AbstractValidator<StudioDto>
    {
        public StudioDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(200).WithMessage("{PropertyName} should not be empty").NotEmpty();
            RuleFor(x => x.Location).NotNull().MaximumLength(200).WithMessage("{PropertyName} should not be empty").NotEmpty();
        }
    }
}
