using System.Linq.Expressions;
using TailoringApp.Entity;

namespace TailoringApp.Interface.IRepository
{
    public interface IDesignRepository: IBaseRepository<Design>
    {
        Task<Design> GetAsync(int id);
        Task<Design> GetAsync(Expression<Func<Design, bool>> expression);
        Design Get(Expression<Func<Design, bool>> expression);
        Task<IList<Design>> GetSelectedAsync(List<int> ids);
        Task<IList<Design>> GetSelectedAsync(Expression<Func<Design, bool>> expression);
        Task<IList<Design>> GetAllAsync();
    }
}
