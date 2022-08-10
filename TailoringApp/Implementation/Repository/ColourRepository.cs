using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TailoringApp.Context;
using TailoringApp.Entity;
using TailoringApp.Interface.IRepository;

namespace TailoringApp.Implementation.Repository
{
    public class ColourRepository : BaseRepository<Colour>, IColourRepository
    {

        public ColourRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<Colour>> GetAllAsync()
        {
            return await _context.Colours.ToListAsync();
        }

        public async Task<Colour> GetAsync(int id)
        {
            return await _context.Colours.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Colour> GetAsync(Expression<Func<Colour, bool>> expression)
        {
            return await _context.Colours.FirstOrDefaultAsync(expression);
        }

        public async Task<IList<Colour>> GetSelectedAsync(List<int> ids)
        {
            return await _context.Colours.Where(x => ids.Contains(x.Id) && x.IsDeleted == false).ToListAsync();
        }

        public async Task<IList<Colour>> GetSelectedAsync(Expression<Func<Colour, bool>> expression)
        {
            return await _context.Colours.Where(expression).ToListAsync();
        }
    }
}
