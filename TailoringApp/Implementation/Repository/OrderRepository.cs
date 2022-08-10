using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TailoringApp.Context;
using TailoringApp.Entity;
using TailoringApp.Interface.IRepository;

namespace TailoringApp.Implementation.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {

        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<Order>> GetAllAsync()
        {
            return await _context.Order.Include(x => x.Colour).Include(x => x.Customer).Include(x => x.Design).ToListAsync();
        }

        public async Task<Order> GetAsync(int id)
        {
            return await _context.Order.Include(x => x.Colour).Include(x => x.Customer).Include(x=>x.Design).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Order> GetAsync(Expression<Func<Order, bool>> expression)
        {
            return await _context.Order.Include(x => x.Colour).Include(x => x.Customer).Include(x => x.Design).FirstOrDefaultAsync(expression);
        }

        public async Task<IList<Order>> GetSelectedAsync(List<int> ids)
        {
            return await _context.Order.Include(x => x.Colour).Include(x => x.Customer).Include(x => x.Design).Where(x => ids.Contains(x.Id) && x.IsDeleted == false).ToListAsync();
        }

        public async Task<IList<Order>> GetSelectedAsync(Expression<Func<Order, bool>> expression)
        {
            var get = await _context.Order.Include(x => x.Colour).Include(x => x.Customer).Include(x => x.Design).Where(expression).ToListAsync();
            return get;
        }
    }
}
