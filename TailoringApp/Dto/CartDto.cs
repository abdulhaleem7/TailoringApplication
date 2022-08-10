using TailoringApp.Entity;

namespace TailoringApp.Dto
{
    public class CartDto
    {
        public int Id { get; set; }
        public List<Order> Orders { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string SendDeliveryDate { get; set; }
        public int Count { get; set; }
        public decimal TotalAmount { get; set; }
    }
    public class CartRequestModel
    {
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
