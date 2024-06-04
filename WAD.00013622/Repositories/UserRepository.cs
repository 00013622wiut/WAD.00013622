using Microsoft.EntityFrameworkCore;
using WAD._00013622.Data;
using WAD._00013622.Interfaces;
using WAD._00013622.Models;

namespace WAD._00013622.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetAllUsersWithOrdersAsync()
        {
            return await _context.Users.Include(u => u.Orders).ToListAsync();
        }

        public async Task<User> GetUserByIdWithOrdersAsync(int id)
        {
            return await _context.Users.Include(u => u.Orders).FirstOrDefaultAsync(u => u.UserId == id);
        }
    }
}
