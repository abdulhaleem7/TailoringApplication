using TailoringApp.Entity;

namespace TailoringApp.Dto
{
    public class ClothDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IList<Design> Designs { get; set; }
        public IList<Measurement> Measurements { get; set; }

    }
    public class ClothRequestModel
    {
        public int CategoryId { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
