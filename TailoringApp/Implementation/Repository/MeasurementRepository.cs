using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TailoringApp.Context;
using TailoringApp.Entity;
using TailoringApp.Interface.IRepository;

namespace TailoringApp.Implementation.Repository
{
    public class MeasurementRepository : BaseRepository<Measurement>, IMeasurementRepository
    {

        public MeasurementRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<Measurement>> GetAllAsync()
        {
            return await _context.Measurements.Include(x => x.Cloth).ToListAsync();
        }

        public async Task<Measurement> GetAsync(int id)
        {
            return await _context.Measurements.Include(x => x.Cloth).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Measurement> GetAsync(Expression<Func<Measurement, bool>> expression)
        {
            return await _context.Measurements.Include(x => x.Cloth).FirstOrDefaultAsync(expression);
        }

        public async Task<IList<Measurement>> GetSelectedAsync(List<int> ids)
        {
            return await _context.Measurements.Include(x => x.Cloth).Where(x => ids.Contains(x.Id) && x.IsDeleted == false).ToListAsync();
        }

        public async Task<IList<Measurement>> GetSelectedAsync(Expression<Func<Measurement, bool>> expression)
        {
            return await _context.Measurements.Include(x => x.Cloth).Where(expression).ToListAsync();
        }
    }
}
