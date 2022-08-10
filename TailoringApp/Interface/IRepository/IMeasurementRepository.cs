using System.Linq.Expressions;
using TailoringApp.Entity;

namespace TailoringApp.Interface.IRepository
{
    public interface IMeasurementRepository : IBaseRepository<Measurement>
    {
        Task<Measurement> GetAsync(int id);
        Task<Measurement> GetAsync(Expression<Func<Measurement, bool>> expression);
        Task<IList<Measurement>> GetSelectedAsync(List<int> ids);
        Task<IList<Measurement>> GetSelectedAsync(Expression<Func<Measurement, bool>> expression);
        Task<IList<Measurement>> GetAllAsync();
    }
}
