using FluentValidation;
using Movies.DTOs;

namespace Movies.WebAPI.Validator
{
    public class MovieDTOValidator : AbstractValidator<Movie>
    {
        public MovieDTOValidator()
        {
            RuleFor(movie => movie.Name)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must be less than 100 characters.");

            RuleFor(movie => movie.Genre)
                .NotEmpty().WithMessage("Genre is required.")
                .MaximumLength(50).WithMessage("Genre must be less than 50 characters.");

            RuleFor(movie => movie.ReleaseYear)
                .InclusiveBetween(1900, DateTime.Now.Year)
                .WithMessage($"ReleaseYear must be between 1900 and {DateTime.Now.Year}.");
        }
    }
}
