using TailoringApp.Entity;
using TailoringApp.Enum;

namespace TailoringApp.Dto
{
    public class PaymentDto
    {
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderReference { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
    public class PaymentRequestModel
    {
        public int UserId { get; set; }
    }
}
