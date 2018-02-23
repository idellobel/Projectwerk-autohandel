using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autohandel.Domain.Entities
{
    public class User : Persoon
    {
        public long UserId { get; set; }
        public string UserName { get; set; }

        [Required]
        public string PaswoordHash { get; set; } //wachtwoord bewaren als een versleutelde MD5 hash 

        public ICollection<Role> Roles { get; set; }
    }
}