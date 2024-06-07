using PHONEKART.Models;

namespace PHONEKART

{
    public interface IHomeRepository
    {
        Task<IEnumerable<Phone>> GetPhones(string sTerm = "", int brandId = 0);
        Task<IEnumerable<Brand>> Brands();
    }
}