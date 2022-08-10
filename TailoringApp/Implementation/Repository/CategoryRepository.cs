using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TailoringApp.Context;
using TailoringApp.Entity;
using TailoringApp.Interface.IRepository;

namespace TailoringApp.Implementation.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<Category>> GetAllAsync()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            return await _context.Category.FirstOrDefaultAsync(x=>x.Id == id && x.IsDeleted == false);
        }

        public async Task<Category> GetAsync(Expression<Func<Category, bool>> expression)
        {
            return await _context.Category.FirstOrDefaultAsync(expression);
        }

        public async Task<IList<Category>> GetSelectedAsync(List<int> ids)
        {
            return await _context.Category.Where(x => ids.Contains(x.Id) && x.IsDeleted == false).ToListAsync();
        }

        public async Task<IList<Category>> GetSelectedAsync(Expression<Func<Category, bool>> expression)
        {
            return await _context.Category.Where(expression).ToListAsync();
        }
    }
}
