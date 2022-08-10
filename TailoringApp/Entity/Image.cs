using TailoringApp.Contract;

namespace TailoringApp.Entity
{
    public class Image: AuditableEntity
    {
        public string Name { get; set; }
        public string Picture { get; set; }

    }
}
