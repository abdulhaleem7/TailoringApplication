using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TailoringApp.Context;
using TailoringApp.Entity;
using TailoringApp.Interface.IRepository;

namespace TailoringApp.Implementation.Repository
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<Cart>> GetAllAsync()
        {
            return await _context.Carts.Include(x => x.Customer).Where(x=>x.IsDeleted == false).ToListAsync();
        }

        public async Task<Cart> GetAsync(int id)
        {
            return await _context.Carts.Include(x => x.Customer).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Cart> GetAsync(Expression<Func<Cart, bool>> expression)
        {
            return await _context.Carts.Include(x => x.Customer).FirstOrDefaultAsync(expression);
        }

        public async Task<IList<Cart>> GetSelectedAsync(List<int> ids)
        {
            return await _context.Carts.Include(x => x.Customer).Where(x => ids.Contains(x.Id) && x.IsDeleted == false).ToListAsync();
        }

        public async Task<IList<Cart>> GetSelectedAsync(Expression<Func<Cart, bool>> expression)
        {
            return await _context.Carts.Include(x => x.Customer).Where(expression).ToListAsync();
        }
    }
}
