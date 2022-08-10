using TailoringApp.Entity;

namespace TailoringApp.Dto
{
    public class DesignDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ClothName { get; set; }
        public string Picture { get; set; }
        public string Picture2 { get; set; }
        public ICollection<OrderDto> Orders { get; set; }
    }
    public class DesignRequestModel
    {
        public string Name { get; set; }
        public int ClothId { get; set; }
        public string Picture { get; set; }
        public string Picture2 { get; set; }
    }
}
