using System.Collections.Generic;
using TailoringApp.Contract;

namespace TailoringApp.Identity
{
    public class Role : AuditableEntity
    {
        public string Name { get; set; }
        public List<UserRole> UserRole { get; set; } = new List<UserRole>();
    }
}
