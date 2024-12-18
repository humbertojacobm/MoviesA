using FluentValidation;
using Movies.DTOs;

namespace Movies.WebAPI.Validator
{
    public class RatingDTOValidator : AbstractValidator<RatingDTO>
    {
        public RatingDTOValidator()
        {
            RuleFor(rating => rating.RatingValue)
                .InclusiveBetween(1, 5).WithMessage("RatingValue must be between 1 and 5.");

            RuleFor(rating => rating.VotersFullName)
                .NotEmpty().WithMessage("VotersFullName is required.")
                .MaximumLength(100).WithMessage("VotersFullName must be less than 100 characters.");
        }
    }
}
