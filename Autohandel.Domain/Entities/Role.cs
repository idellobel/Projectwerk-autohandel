using Autohandel.Domain.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autohandel.Domain.Entities
{
    public class Role
    {
        [Key]
        public long RoleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RoleUsers> RoleUsers { get; set; }
    }
}