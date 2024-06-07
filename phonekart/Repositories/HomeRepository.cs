

using PHONEKART;
using Microsoft.EntityFrameworkCore;
using PHONEKART.Data;
using PHONEKART.Models;

namespace PHONEKART.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;

        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Brand>> Brands()
        {
            return await _db.brands.ToListAsync();
        }
        public async Task<IEnumerable<Phone>> GetPhones(string sTerm = "", int BrandId = 0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<Phone> phones = await (from phone in _db.phones
                         join Brand in _db.brands
                         on phone.BrandId equals Brand.Id
                         join stock in _db.Stocks
                         on phone.Id equals stock.PhoneId
                         into phone_stocks
                         from phoneWithStock in phone_stocks.DefaultIfEmpty()
                         where string.IsNullOrWhiteSpace(sTerm) || (phone != null && phone.Model.ToLower().StartsWith(sTerm))
                         
                        select new Phone
                         {
                             Id = phone.Id,
                             Image = phone.Image,
                             Model = phone.Model,
                             BrandId = phone.BrandId,
                             Price = phone.Price,
                             BrandName = Brand.BrandName,
                             Quantity=phoneWithStock==null? 0:phoneWithStock.Quantity
                         }
                         ).ToListAsync();
            if (BrandId > 0)
            {

                phones = phones.Where(a => a.BrandId == BrandId).ToList();
            }
            return phones;

        }
    }
}
