using TailoringApp.Contract;

namespace TailoringApp.Entity
{
    public class Location : AuditableEntity
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string Area { get; set; }
        public Customer Customer { get; set; }
    }
}
