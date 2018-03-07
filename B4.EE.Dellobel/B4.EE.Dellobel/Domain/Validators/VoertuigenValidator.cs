using B4.EE.DellobelI.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace B4.EE.DellobelI.Domain.Validators
{
    public class VoertuigenValidator : AbstractValidator<Voertuigen>
    {
        public VoertuigenValidator()
        {
            RuleFor(voertuigenStatus => voertuigenStatus.VoertuigenStatus.ToString())
                .NotEmpty()
                .WithMessage("Mag niet leeg zijn");
               

        }
    }
}
