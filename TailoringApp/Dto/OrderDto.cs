using TailoringApp.Enum;

namespace TailoringApp.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int DesignId { get; set; }
        public int Quantity { get; set; }
        public string DesignName { get; set; }
        public string DesignImage { get; set; }
        public  decimal TotalPrice { get; set; }
        public decimal Price { get; set; }
        public int CartId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string? CustomerDesign { get; set; }
        public int CustomerId { get; set; }
        public int ColourId { get; set; }
        public string ColourName { get; set; }
        public int DateDiff { get; set; }
        public string DeliveryDae { get; set; }
        public string Description { get; set; }
    }
    public class OrderRequestModel
    {
        public string? SuitLenght { get; set; }
        public string? SuitWaist { get; set; }
        public string? SuitChest { get; set; }
        public string? SuitShoulder { get; set; }
        public string? SuitSleeve { get; set; }
        public string? TrouserLenght { get; set; }
        public string? TrouserWaist { get; set; }
        public string? TrouserTight { get; set; }
        public string? TrouserKnee { get; set; }
        public string? ShirtLenght { get; set; }
        public string? ShirtWaist { get; set; }
        public string? ShirtSleeve { get; set; }
        public string? ShirtShoulder { get; set; }
        public string? WaistCoatLenght { get; set; }
        public string? WaistCoatWaist { get; set; }
        public string? NativeLenght { get; set; }
        public string? NativeWaist { get; set; }
        public string? NativeShoulder { get; set; }
        public string? NativeSleeve { get; set; }
        public string? NativeTrouserLenght { get; set; }
        public string? NativeTrouserTight { get; set; }
        public string? NativeTrouserKnee { get; set; }
        public string? KneekerLenght { get; set; }
        public string? KneekerWaist { get; set; }
        public string? KneekerTight { get; set; }
        public string? AgbadaLenght { get; set; }
        public string? NativeCap { get; set; }
        public string? CustomerDesign { get; set; }
        public int CartId { get; set; }
        public int DesignId { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public int ColourId { get; set; }
        public string Description { get; set; }
    }
}
