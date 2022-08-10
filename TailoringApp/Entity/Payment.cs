using TailoringApp.Contract;
using TailoringApp.Enum;

namespace TailoringApp.Entity
{
    public class Payment:AuditableEntity 
    {
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public int CartId{get;set; }
        public Cart Cart { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderReference { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
