using Microsoft.EntityFrameworkCore;
using PHONEKART.Data;
using PHONEKART.Models;
using PHONEKART.Models.DTOs;

namespace PHONEKART.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Stock?> GetStockByPhoneId(int PhoneId) => await _context.Stocks.FirstOrDefaultAsync(s => s.PhoneId == PhoneId);

        public async Task ManageStock(StockDTO stockToManage)
        {
            // if there is no stock for given phone id, then add new record
            // if there is already stock for given phone id, update stock's quantity
            var existingStock = await GetStockByPhoneId(stockToManage.PhoneId);
            if (existingStock is null)
            {
                var stock = new Stock { PhoneId = stockToManage.PhoneId, Quantity = stockToManage.Quantity };
                _context.Stocks.Add(stock);
            }
            else
            {
                existingStock.Quantity = stockToManage.Quantity;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StockDisplayModel>> GetStocks(string sTerm = "")
        {
            var stocks = await (from phone in _context.phones
                                join stock in _context.Stocks
                                on phone.Id equals stock.PhoneId
                                into phone_stock
                                from phoneStock in phone_stock.DefaultIfEmpty()
                                where string.IsNullOrWhiteSpace(sTerm) || phone.Model.ToLower().Contains(sTerm.ToLower())
                                select new StockDisplayModel
                                {
                                    PhoneId = phone.Id,
                                    PhoneName = phone.Model,
                                    Quantity = phoneStock == null ? 0 : phoneStock.Quantity
                                }
                                ).ToListAsync();
            return stocks;
        }

    }

    public interface IStockRepository
    {
        Task<IEnumerable<StockDisplayModel>> GetStocks(string sTerm = "");
        Task<Stock?> GetStockByPhoneId(int PhoneId);
        Task ManageStock(StockDTO stockToManage);
    }
}
