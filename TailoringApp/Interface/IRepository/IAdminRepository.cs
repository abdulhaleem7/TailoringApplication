using System.Linq.Expressions;
using TailoringApp.Entity;

namespace TailoringApp.Interface.IRepository
{
    public interface IAdminRepository : IBaseRepository<Admin>
    {
        Task<Admin> GetAsync(int id);
        Task<Admin> GetAsync(Expression<Func<Admin, bool>> expression);
        Task<IList<Admin>> GetSelectedAsync(List<int> ids);
        Task<IList<Admin>> GetSelectedAsync(Expression<Func<Admin, bool>> expression);
        Task<IList<Admin>> GetAllAsync();
    }
}
