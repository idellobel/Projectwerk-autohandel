using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.ViewModels.UserViewModels
{
    public class UserViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        [Display(Name = "Paswoord-versleuteld")]
        public string PaswoordHash { get; set; }
        [Display(Name = "Mislukte logins")]
        public int MislukteLogin { get; set; }
    }
}
