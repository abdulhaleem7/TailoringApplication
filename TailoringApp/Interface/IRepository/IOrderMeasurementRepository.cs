using System.Linq.Expressions;
using TailoringApp.Entity;

namespace TailoringApp.Interface.IRepository
{
    public interface IOrderMeasurementRepository : IBaseRepository<OrderMeasurement>
    {
        Task<OrderMeasurement> GetAsync(int id);
        Task<OrderMeasurement> GetAsync(Expression<Func<OrderMeasurement, bool>> expression);
        Task<IList<OrderMeasurement>> GetSelectedAsync(List<int> ids);
        Task<IList<OrderMeasurement>> GetSelectedAsync(Expression<Func<OrderMeasurement, bool>> expression);
        Task<IList<OrderMeasurement>> GetAllAsync();
    }
}
