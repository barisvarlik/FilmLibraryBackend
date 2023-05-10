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
    public class PersonDtoValidator : AbstractValidator<PersonDto>
    {
        public PersonDtoValidator()
        {
            RuleFor(x => x.FirstName).NotNull().MaximumLength(200).WithMessage("{PropertyName} should not be empty").NotEmpty();
            RuleFor(x => x.LastName).NotNull().MaximumLength(200).WithMessage("{PropertyName} should not be empty").NotEmpty();
            RuleFor(x => x.DateOfBirth).InclusiveBetween(new DateTime(1900, 1, 1), DateTime.UtcNow).WithMessage("{PropertyName} should be in a valid date");
            RuleFor(x => x.Gender).Must(x => x == "Male" || x == "Female" || x == "Other").WithMessage("{PropertyName} should not be in detail.");
            RuleFor(x => x.Nationality).NotNull().MaximumLength(20).WithMessage("{PropertyName} should not be empty").NotEmpty();
        }
    }
}
