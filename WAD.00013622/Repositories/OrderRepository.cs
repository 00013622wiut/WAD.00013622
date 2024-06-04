using Microsoft.EntityFrameworkCore;
using WAD._00013622.Data;
using WAD._00013622.Interfaces;
using WAD._00013622.Models;

namespace WAD._00013622.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetAllOrdersWithUsersAsync()
        {
            return await _context.Orders.Include(o => o.User).ToListAsync();
        }

        public async Task<Order> GetOrderByIdWithUserAsync(int id)
        {
            return await _context.Orders.Include(o => o.User).FirstOrDefaultAsync(o => o.OrderId == id);
        }
    }
}
