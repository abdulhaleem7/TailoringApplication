using System.Linq.Expressions;
using TailoringApp.Entity;

namespace TailoringApp.Interface.IRepository
{
    public interface IColourRepository: IBaseRepository<Colour>
    {
        Task<Colour> GetAsync(int id);
        Task<Colour> GetAsync(Expression<Func<Colour, bool>> expression);
        Task<IList<Colour>> GetSelectedAsync(List<int> ids);
        Task<IList<Colour>> GetSelectedAsync(Expression<Func<Colour, bool>> expression);
        Task<IList<Colour>> GetAllAsync();
    }
}
