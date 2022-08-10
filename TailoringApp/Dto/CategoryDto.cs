using TailoringApp.Entity;

namespace TailoringApp.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Cloth> Cloths { get; set; }
    }
    public class CategoryRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
