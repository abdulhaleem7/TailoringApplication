using TailoringApp.Contract;
using TailoringApp.Enum;

namespace TailoringApp.Entity
{
    public class Order: AuditableEntity
    {
        public int DesignId { get; set; }
        public Design Design { get; set; }
        public int Quantity { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int CustomerId { get; set; }
        public int CartId { get; set; }
        public string? CustomerDesign { get; set; }
        public Cart Cart{ get; set; }
        public Customer Customer { get; set; }
        public string Description { get; set; }
        public int ColourId { get; set; }
        public Colour Colour { get; set; }
    }
}
