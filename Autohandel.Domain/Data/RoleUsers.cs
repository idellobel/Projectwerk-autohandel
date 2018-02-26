using Autohandel.Domain.Entities;

namespace Autohandel.Domain.Data
{
    public class RoleUsers
    {
        /// <summary>
        /// The Foreign key of the Role entity
        /// </summary>
        public long Role_RoleId { get; set; }

        /// <summary>
        /// The Foreign key of the User entity
        /// </summary>
        public long User_UserId { get; set; }

        /// <summary>
        /// A navigation property to User entity
        /// </summary>
        public User User { get; set; }


        /// <summary>
        /// A navigation property to Role entity
        /// </summary>
        public Role Role { get; set; }


    }
}