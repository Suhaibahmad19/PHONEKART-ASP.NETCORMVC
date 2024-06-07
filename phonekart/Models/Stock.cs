using System.ComponentModel.DataAnnotations.Schema;

namespace PHONEKART.Models
{
    [Table("Stock")]
    public class Stock
    {
        public int Id { get; set; }
        public int PhoneId { get; set; }
        public int Quantity { get; set; }

        public Phone? Phone { get; set; }
    }
}
