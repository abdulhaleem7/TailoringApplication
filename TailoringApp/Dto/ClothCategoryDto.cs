namespace TailoringApp.Dto
{
    public class ClothCategoryDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

    }
    public class ClothCategoryUpdateModel
    {
        public string Name { get; set; }
        public string Images { get; set; }

    }
    
}
