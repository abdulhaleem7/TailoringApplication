﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TailoringApp.Context;
using TailoringApp.Identity;
using TailoringApp.Interface.IRepository;

namespace TailoringApp.Implementation.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IList<User>> GetAllAsync()
        {
            return await _context.Users.Include(x => x.UserRoles).ThenInclude(y => y.Role).Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<User> GetAsync(int id)
        {
            return await _context.Users.Include(x => x.UserRoles).ThenInclude(y => y.Role).FirstOrDefaultAsync(x => x.IsDeleted == false && x.Id == id);
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> expression)
        {
            return await _context.Users.Include(x => x.UserRoles).ThenInclude(y => y.Role).FirstOrDefaultAsync(expression);
        }

        public async Task<IList<User>> GetSelectedAsync(List<int> ids)
        {
            return await _context.Users.Include(x => x.UserRoles).ThenInclude(y => y.Role).Where(x => ids.Contains(x.Id) && x.IsDeleted == false).ToListAsync();
        }

        public async Task<IList<User>> GetSelectedAsync(Expression<Func<User, bool>> expression)
        {
            return await _context.Users.Include(x => x.UserRoles).ThenInclude(y => y.Role).Where(expression).ToListAsync();
        }
    }
}
