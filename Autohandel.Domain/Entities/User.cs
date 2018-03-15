using Autohandel.Domain.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autohandel.Domain.Entities
{
    public class User : Persoon
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }
        public string UserName { get; set; }

        [Required]
        public string PaswoordHash { get; set; } //wachtwoord bewaren als een versleutelde MD5 hash 

        public bool RememberMe { get; set; }

       
        public virtual ICollection<RoleUsers> RoleUsers { get; set; }
    }
}