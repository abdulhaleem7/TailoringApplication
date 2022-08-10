using TailoringApp.Entity;
using System.Collections.Generic;
using TailoringApp.Contract;

namespace TailoringApp.Identity
{
    public class User : AuditableEntity
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public Admin Admin { get; set; }
        public Customer Customer { get; set; }
        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
