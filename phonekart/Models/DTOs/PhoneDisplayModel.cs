namespace PHONEKART.Models.DTOs
{
    public class PhoneDisplayModel
    {
        public IEnumerable<Phone> Phones { get; set; }
        public IEnumerable<Brand> brands { get; set; }
        public string STerm { get; set; } = "";
        public int BrandId { get; set; } = 0;
    }
}
