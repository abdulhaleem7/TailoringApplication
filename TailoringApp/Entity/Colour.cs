using TailoringApp.Contract;

namespace TailoringApp.Entity
{
    public class Colour :AuditableEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public IList<Cloth> Cloths { get; set; }
    }
}
