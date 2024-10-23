using FluentValidation;
using ReservationSystem.Core.Models;

namespace ReservationSystem.Business.Validation
{
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.Date).NotEmpty().WithMessage("Reservation must have a date");
            RuleFor(x => x.Ranking).GreaterThanOrEqualTo(0).LessThan(6).WithMessage("Reservation rankings are between 1 and 5");
        }
    }
}
