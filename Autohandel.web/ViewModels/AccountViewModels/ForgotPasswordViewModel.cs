using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.ViewModels.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Gelieve je {0} in te geven")]
        [EmailAddress(ErrorMessage = "Gelieve een correct {0} in te geven")]
        public string Email { get; set; }
    }
}
