using FluentValidation;
using ReservationSystem.Core.Models;

namespace ReservationSystem.Business.Validation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Contact must have a name");
            RuleFor(x => x.ContactTypeId).NotEmpty().WithMessage("Contact must have a contact type id");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Contact must have a birth date");
        }
    }
}
