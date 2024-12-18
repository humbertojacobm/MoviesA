using FluentValidation;
using Movies.DTOs;

namespace Movies.WebAPI.Validator
{
    public class ActorDTOValidator : AbstractValidator<Actor>
    {
        public ActorDTOValidator()
        {
            RuleFor(actor => actor.Name)
                .NotEmpty().WithMessage("Actor name is required.")
                .MaximumLength(100).WithMessage("Actor name must be less than 100 characters.");

            RuleForEach(actor => actor.MovieTitles)
                .NotEmpty().WithMessage("Movie title cannot be empty.")
                .MaximumLength(100).WithMessage("Movie title must be less than 100 characters.");
        }
    }
}
