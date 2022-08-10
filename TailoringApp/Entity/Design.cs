using TailoringApp.Contract;

namespace TailoringApp.Entity
{
    public class Design : AuditableEntity
    {
        public string Name { get; set; }
        public int ClothId { get; set; }
        public Cloth Cloth { get; set; }
        public string Picture { get; set; }
        public string Picture2 { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
