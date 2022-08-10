using System.Linq.Expressions;
using TailoringApp.Entity;

namespace TailoringApp.Interface.IRepository
{
    public interface IPaymentRepository:IBaseRepository<Payment>
    {
        Task<Payment> GetAsync(int id);
        Task<Payment> GetAsync(Expression<Func<Payment, bool>> expression);
        Task<IList<Payment>> GetSelectedAsync(List<int> ids);
        Task<IList<Payment>> GetSelectedAsync(Expression<Func<Payment, bool>> expression);
        Task<IList<Payment>> GetAllAsync();
    }
}
