using TailoringApp.Entity;

namespace TailoringApp.Dto
{
    public class ColourDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public IList<Cloth> Cloths { get; set; }
    }
    public class ColourRequestModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
