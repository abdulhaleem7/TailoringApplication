using System.Linq.Expressions;
using TailoringApp.Entity;

namespace TailoringApp.Interface.IRepository
{
    public interface ICartRepository:IBaseRepository<Cart>
    {
        Task<Cart> GetAsync(int id);
        Task<Cart> GetAsync(Expression<Func<Cart, bool>> expression);
        Task<IList<Cart>> GetSelectedAsync(List<int> ids);
        Task<IList<Cart>> GetSelectedAsync(Expression<Func<Cart, bool>> expression);
        Task<IList<Cart>> GetAllAsync();
    }
}
