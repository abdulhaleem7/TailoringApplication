using TailoringApp.Contract;

namespace TailoringApp.Identity
{
    public class UserRole : AuditableEntity
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
