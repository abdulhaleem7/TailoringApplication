using System.Linq.Expressions;
using TailoringApp.Entity;

namespace TailoringApp.Interface.IRepository
{
    public interface IOrderRepository: IBaseRepository<Order>
    {
        Task<Order> GetAsync(int id);
        Task<Order> GetAsync(Expression<Func<Order, bool>> expression);
        Task<IList<Order>> GetSelectedAsync(List<int> ids);
        Task<IList<Order>> GetSelectedAsync(Expression<Func<Order, bool>> expression);
        Task<IList<Order>> GetAllAsync();
    }
}
