using System.Linq.Expressions;
using TailoringApp.Entity;

namespace TailoringApp.Interface.IRepository
{
    public interface IClothRepository: IBaseRepository<Cloth>
    {
        Task<Cloth> GetAsync(int id);
        Task<Cloth> GetAsync(Expression<Func<Cloth, bool>> expression);
        Task<IList<Cloth>> GetSelectedAsync(List<int> ids);
        Task<IList<Cloth>> GetSelectedAsync(Expression<Func<Cloth, bool>> expression);
        Task<IList<Cloth>> GetAllAsync();
    }
}
