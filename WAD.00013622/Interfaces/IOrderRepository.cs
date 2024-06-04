using WAD._00013622.Models;

namespace WAD._00013622.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IEnumerable<Order>> GetAllOrdersWithUsersAsync();
        Task<Order> GetOrderByIdWithUserAsync(int id);
    }
}
