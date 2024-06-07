using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PHONEKART.Models
{
    [Table("Phone")]
    public class Phone
    {
        public int Id { get; set; }

        [Required]
        public string? Model { get; set; }

        [Required]
        public double Price { get; set; }
        public string? Image { get; set; }
        [Required]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
        public List<CartDetail> CartDetail { get; set; }
        public Stock Stock { get; set; }

        [NotMapped]
        public string BrandName { get; set; }
        [NotMapped]
        public int Quantity { get; set; }


    }
}
