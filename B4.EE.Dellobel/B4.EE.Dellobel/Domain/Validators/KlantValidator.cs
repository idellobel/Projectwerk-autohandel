using B4.EE.DellobelI.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace B4.EE.DellobelI.Domain.Validators
{
    public class KlantValidator : AbstractValidator<Klant>
    {

        public KlantValidator()
        {
            RuleFor(klant => klant.Naam)
                .NotEmpty()
                .WithMessage("Mag niet leeg zijn");

            RuleFor(Klant => Klant.Telefoonnummer)
                .NotEmpty()
                .WithMessage("Mag niet leeg zijn")
                .Length(9, 15)
                .WithMessage("Zie telefoonnummer na");

        }     

    }
}
  
