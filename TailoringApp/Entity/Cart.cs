using TailoringApp.Contract;
using TailoringApp.Enum;

namespace TailoringApp.Entity
{
    public class Cart : AuditableEntity
    {
        public List<Order> Orders { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Cartstatus CartStatus { get; set; }
        public Payment Payment { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
