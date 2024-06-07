namespace PHONEKART.Models.DTOs
{
    public class StockDisplayModel
    {
        public int Id { get; set; }
        public int PhoneId { get; set; }
        public int Quantity { get; set; }
        public string? PhoneName { get; set; }
    }
}
