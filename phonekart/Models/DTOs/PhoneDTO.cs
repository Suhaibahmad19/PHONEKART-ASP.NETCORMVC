using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PHONEKART.Models.DTOs;
public class PhoneDTO
{
    public int Id { get; set; }

    [Required]
    public string? PhoneName { get; set; }

    
    [Required]
    public double Price { get; set; }
    public string? Image { get; set; }
    [Required]
    public int BrandId { get; set; }
    public IFormFile? ImageFile { get; set; }
    public IEnumerable<SelectListItem>? BrandList { get; set; }
}
