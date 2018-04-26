
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Autohandel.Domain.Entities
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "AppGebruikerId")]
        public long? PersoonId { get; set; }
    }
}
