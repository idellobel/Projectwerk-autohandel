using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.ViewModels.AccountViewModels
{
    public class LoginWith2faViewModel
    {
        [Required]
        [StringLength(7, ErrorMessage = "Het {0} moet minimaal {2} en maximaal {1} ​​tekens lang zijn.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Authenticatie code")]
        public string TwoFactorCode { get; set; }

        [Display(Name = "Onthoud dit toestel")]
        public bool RememberMachine { get; set; }

        public bool RememberMe { get; set; }
    }
}
