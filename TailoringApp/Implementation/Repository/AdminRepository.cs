using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TailoringApp.Context;
using TailoringApp.Entity;
using TailoringApp.Interface.IRepository;

namespace TailoringApp.Implementation.Repository
{
    public class AdminRepository : BaseRepository<Admin>,IAdminRepository
    {
       
        public AdminRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<Admin>> GetAllAsync()
        {
            return await _context.Admin.Include(x => x.User).ToListAsync();
        }

        public async Task<Admin> GetAsync(int id)
        {
            return await _context.Admin.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Admin> GetAsync(Expression<Func<Admin, bool>> expression)
        {
            return await _context.Admin.Include(x => x.User).FirstOrDefaultAsync(expression);
        }

        public async Task<IList<Admin>> GetSelectedAsync(List<int> ids)
        {
            return await _context.Admin.Include(x => x.User).Where(x => ids.Contains(x.Id) && x.IsDeleted == false).ToListAsync();
        }

        public async Task<IList<Admin>> GetSelectedAsync(Expression<Func<Admin, bool>> expression)
        {
            return await _context.Admin.Include(x => x.User).Where(expression).ToListAsync();
        }
    }
}
