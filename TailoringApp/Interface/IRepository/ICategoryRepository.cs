using System.Linq.Expressions;
using TailoringApp.Entity;

namespace TailoringApp.Interface.IRepository
{
    public interface ICategoryRepository: IBaseRepository<Category>
    {
        Task<Category> GetAsync(int id);
        Task<Category> GetAsync(Expression<Func<Category, bool>> expression);
        Task<IList<Category>> GetSelectedAsync(List<int> ids);
        Task<IList<Category>> GetSelectedAsync(Expression<Func<Category, bool>> expression);
        Task<IList<Category>> GetAllAsync();
    }
}
