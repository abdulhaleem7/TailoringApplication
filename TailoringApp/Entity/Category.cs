using System.Collections.Generic;
using TailoringApp.Contract;

namespace TailoringApp.Entity
{
    public class Category : AuditableEntity

    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Cloth> Cloths { get; set; } = new HashSet<Cloth>();
    }
}
