
using System.Linq.Expressions;
using TailoringApp.Identity;

namespace TailoringApp.Interface.IRepository
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<Role> GetAsync(int id);
        Task<Role> GetAsync(Expression<Func<Role, bool>> expression);
        Task<IList<Role>> GetSelectedAsync(List<int> ids);
        Task<IList<Role>> GetSelectedAsync(Expression<Func<Role, bool>> expression);
        Task<IList<Role>> GetAllAsync();
    }
}
