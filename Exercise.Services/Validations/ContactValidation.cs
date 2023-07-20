using Exercise.Services.Models;
using FluentValidation;

namespace Exercise.Services.Validations
{
    public class ContactValidation : AbstractValidator<ContactServiceModel>
    {
        public ContactValidation()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage("Contact name cannot be empty");
            RuleFor(x => x.Company.Key).Equal(0).WithMessage("You must select a company");
            RuleFor(x => x.Country.Key).Equal(0).WithMessage("You must select a country");
        }
    }
}
