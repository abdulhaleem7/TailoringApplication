using TailoringApp.Contract;
using TailoringApp.Identity;

namespace TailoringApp.Entity
{
    public class Customer : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public OrderMeasurement OrderMeasurement { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }      
    }
}
