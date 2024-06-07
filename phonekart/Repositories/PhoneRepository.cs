using Microsoft.EntityFrameworkCore;
using PHONEKART.Data;
using PHONEKART.Models;

namespace PHONEKART.Repositories
{
    public interface IPhoneRepository
    {
        Task Addphone(Phone phone);
        Task Deletephone(Phone phone);
        Task<Phone?> GetphoneById(int id);
        Task<IEnumerable<Phone>> Getphones();
        Task Updatephone(Phone phone);
    }

    public class phoneRepository : IPhoneRepository
    {
        private readonly ApplicationDbContext _context;
        public phoneRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Addphone(Phone phone)
        {
            _context.phones.Add(phone);
            await _context.SaveChangesAsync();
        }

        public async Task Updatephone(Phone phone)
        {
            _context.phones.Update(phone);
            await _context.SaveChangesAsync();
        }

        public async Task Deletephone(Phone phone)
        {
            _context.phones.Remove(phone);
            await _context.SaveChangesAsync();
        }

        public async Task<Phone?> GetphoneById(int id) => await _context.phones.FindAsync(id);

        public async Task<IEnumerable<Phone>> Getphones() => await _context.phones.Include(a=>a.Brand).ToListAsync();
    }
}
