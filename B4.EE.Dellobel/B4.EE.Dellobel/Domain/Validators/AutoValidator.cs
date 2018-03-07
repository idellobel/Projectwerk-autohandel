using B4.EE.DellobelI.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace B4.EE.DellobelI.Domain.Validators
{
    public class AutoValidator : AbstractValidator<Auto>
    {
        public AutoValidator()
        {
            RuleFor(auto => auto.Merk)
                .NotEmpty()
                .WithMessage("Mag niet leeg zijn");

            RuleFor(auto => auto.Model)
               .NotEmpty()
               .WithMessage("Mag niet leeg zijn");

            RuleFor(auto => auto.Bouwjaar)
               .NotEmpty()
               .WithMessage("Mag niet leeg zijn")
               .InclusiveBetween(2012, 2017)
               .WithMessage("max 6 jaar!");
              

            RuleFor(auto => auto.Prijs)
                .NotEmpty()
                .WithMessage("Mag niet leeg zijn");


        }

    }
}
  