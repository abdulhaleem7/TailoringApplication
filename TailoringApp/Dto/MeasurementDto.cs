namespace TailoringApp.Dto
{
    public class MeasurementDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public int ClothId { get; set; }
    }
    public class MeasurementRequestModel
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public int ClothId { get; set; }
    }
}
