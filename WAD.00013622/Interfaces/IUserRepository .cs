using WAD._00013622.Models;

namespace WAD._00013622.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IEnumerable<User>> GetAllUsersWithOrdersAsync();
        Task<User> GetUserByIdWithOrdersAsync(int id);
    }
}
