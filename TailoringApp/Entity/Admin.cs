using TailoringApp.Contract;
using TailoringApp.Identity;

namespace TailoringApp.Entity
{
    public class Admin : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
