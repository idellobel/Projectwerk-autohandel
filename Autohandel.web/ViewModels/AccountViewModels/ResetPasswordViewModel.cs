﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.ViewModels.AccountViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Gelieve je {0} in te geven")]
        [EmailAddress(ErrorMessage = "Gelieve een correct {0} in te geven")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gelieve je {0} in te geven")]
        [StringLength(100, ErrorMessage = "Het {0} moet minimaal {2} en maximaal {1} ​​tekens lang zijn.", MinimumLength = 6)]
        [DataType(DataType.Password, ErrorMessage = "Paswoorden dienen minstens 1 'alphanumeric character' te bevatten en 1 hoofdletter('A' - 'Z').")]
        [Display(Name = "Paswoord")]
        public string Password { get; set; }

        [DataType(DataType.Password, ErrorMessage = "Paswoorden dienen minstens 1 'alphanumeric character' te bevatten en 1 hoofdletter('A' - 'Z').")]
        [Display(Name = "Bevestig paswoord")]
        [Compare("Password", ErrorMessage = "Het paswoord en de bevestiging komen niet overeen.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
