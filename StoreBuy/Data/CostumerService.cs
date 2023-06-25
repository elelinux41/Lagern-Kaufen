using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace StoreBuy.Data
{
    public class CostumerService
    {
        private readonly ApplicationDbContext _context;
        public CostumerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Costumer>> GetAllUsers()
        {
            return await _context.Costumers.ToListAsync();
        }
        public async Task<string> GetBankBalance(string id)
        {
            Costumer costumer = await _context.Costumers.SingleOrDefaultAsync(u => u.Id == id);
            return costumer.Email;
        }
    }
}
