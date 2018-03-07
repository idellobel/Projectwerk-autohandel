using B4.EE.DellobelI.Domain.Models;
using FluentValidation;

namespace B4.EE.DellobelI.Domain.Validators
{
   public class WerkUrenValidator : AbstractValidator<WerkUren>
    {
        public WerkUrenValidator()
        {
            RuleFor(werkUren => werkUren.Datum)
                .NotEmpty()
                .WithMessage("Mag niet leeg zijn");

            RuleFor(werkUren => werkUren.BeginTijd)
               .NotEmpty()
               .WithMessage("Mag niet leeg zijn");

            RuleFor(werkUren => werkUren.EindTijd)
               .NotEmpty()
               .WithMessage("Mag niet leeg zijn")
               .GreaterThanOrEqualTo(werkUren => werkUren.BeginTijd )
               .WithMessage("Dient groter dan begintijd");
               

        }

    }
}
