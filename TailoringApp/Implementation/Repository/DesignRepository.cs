using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TailoringApp.Context;
using TailoringApp.Entity;
using TailoringApp.Interface.IRepository;

namespace TailoringApp.Implementation.Repository
{
    public class DesignRepository : BaseRepository<Design>, IDesignRepository
    {

        public DesignRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Design Get(Expression<Func<Design, bool>> expression)
        {
            return _context.Designs.Include(x => x.Cloth).FirstOrDefault(expression);
        }

        public async Task<IList<Design>> GetAllAsync()
        {
            return await _context.Designs.Include(x => x.Cloth).ToListAsync();
        }

        public async Task<Design> GetAsync(int id)
        {
            return await _context.Designs.Include(x => x.Cloth).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Design> GetAsync(Expression<Func<Design, bool>> expression)
        {
            return await _context.Designs.Include(x => x.Cloth).FirstOrDefaultAsync(expression);
        }

        public async Task<IList<Design>> GetSelectedAsync(List<int> ids)
        {
            return await _context.Designs.Include(x=>x.Cloth).Where(x=>ids.Contains(x.Id) && x.IsDeleted == false).ToListAsync();
        }

        public async Task<IList<Design>> GetSelectedAsync(Expression<Func<Design, bool>> expression)
        {
            return await _context.Designs.Include(x=>x.Cloth).Where(expression).ToListAsync();
        }
    }
}
