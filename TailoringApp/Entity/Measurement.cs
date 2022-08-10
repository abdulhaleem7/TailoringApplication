using TailoringApp.Contract;

namespace TailoringApp.Entity
{
    public class Measurement:AuditableEntity
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public int ClothId { get; set; }
        public Cloth Cloth { get; set; }
    }
}
