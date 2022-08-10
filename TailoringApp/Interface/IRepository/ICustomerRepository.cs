using System.Linq.Expressions;
using TailoringApp.Entity;
namespace TailoringApp.Interface.IRepository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<Customer> GetAsync(int id);
        Task<Customer> GetAsync(Expression<Func<Customer, bool>> expression);
        Task<IList<Customer>> GetSelectedAsync(List<int> ids);
        Task<IList<Customer>> GetSelectedAsync(Expression<Func<Customer, bool>> expression);
        Task<IList<Customer>> GetAllAsync();
    }
}
