using TailoringApp.Contract;

namespace TailoringApp.Entity
{
    public class Cloth : AuditableEntity
    {
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public IList<Design> Designs { get; set; }
        public IList<Measurement> Measurements { get; set; }
    }
}
