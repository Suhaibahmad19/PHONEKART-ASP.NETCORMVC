using System.ComponentModel.DataAnnotations;

namespace PHONEKART.Models.DTOs
{
    public class BrandDTO
    {
        public int Id { get; set; }

        [Required]
        public string BrandName { get; set; }
    }
}
