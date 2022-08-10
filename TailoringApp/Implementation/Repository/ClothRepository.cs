using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TailoringApp.Context;
using TailoringApp.Entity;
using TailoringApp.Interface.IRepository;

namespace TailoringApp.Implementation.Repository
{
    public class ClothRepository : BaseRepository<Cloth>, IClothRepository
    {

        public ClothRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<Cloth>> GetAllAsync()
        {
            return await _context.Cloths.Include(x => x.Category).ToListAsync();
        }

        public async Task<Cloth> GetAsync(int id)
        {
            return await _context.Cloths.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Cloth> GetAsync(Expression<Func<Cloth, bool>> expression)
        {
            return await _context.Cloths.Include(x => x.Category).FirstOrDefaultAsync(expression);
        }

        public async Task<IList<Cloth>> GetSelectedAsync(List<int> ids)
        {
            return await _context.Cloths.Include(x => x.Category).Where(x => ids.Contains(x.Id) && x.IsDeleted == false).ToListAsync();
        }

        public async Task<IList<Cloth>> GetSelectedAsync(Expression<Func<Cloth, bool>> expression)
        {
            return await _context.Cloths.Include(x => x.Category).Where(expression).ToListAsync();
        }
    }
}
