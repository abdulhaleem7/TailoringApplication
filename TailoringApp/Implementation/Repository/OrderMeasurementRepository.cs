using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TailoringApp.Context;
using TailoringApp.Entity;
using TailoringApp.Interface.IRepository;

namespace TailoringApp.Implementation.Repository
{
    public class OrderMeasurementRepository : BaseRepository<OrderMeasurement>, IOrderMeasurementRepository
    {
        public OrderMeasurementRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<OrderMeasurement>> GetAllAsync()
        {
            return await _context.OrderMeasurements.Include(x => x.Customer).ToListAsync();
        }

        public async Task<OrderMeasurement> GetAsync(int id)
        {
            return await _context.OrderMeasurements.Include(x => x.Customer).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<OrderMeasurement> GetAsync(Expression<Func<OrderMeasurement, bool>> expression)
        {
            return await _context.OrderMeasurements.Include(x => x.Customer).FirstOrDefaultAsync(expression);
        }

        public async Task<IList<OrderMeasurement>> GetSelectedAsync(List<int> ids)
        {
            return await _context.OrderMeasurements.Include(x => x.Customer).Where(x => ids.Contains(x.Id) && x.IsDeleted == false).ToListAsync();
        }

        public async Task<IList<OrderMeasurement>> GetSelectedAsync(Expression<Func<OrderMeasurement, bool>> expression)
        {
            return await _context.OrderMeasurements.Include(x => x.Customer).Where(expression).ToListAsync();
        }
    }
}
