﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TailoringApp.Context;
using TailoringApp.Entity;
using TailoringApp.Interface.IRepository;

namespace TailoringApp.Implementation.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<Customer>> GetAllAsync()
        {
            return await _context.Customer.Include(x => x.User).ToListAsync();
        }

        public async Task<Customer> GetAsync(int id)
        {
            return await _context.Customer.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<Customer> GetAsync(Expression<Func<Customer, bool>> expression)
        {
            return await _context.Customer.Include(x=>x.User).FirstOrDefaultAsync(expression);
        }

        public async Task<IList<Customer>> GetSelectedAsync(List<int> ids)
        {
            return await _context.Customer.Include(x => x.User).Where(x => ids.Contains(x.Id) && x.IsDeleted == false).ToListAsync();
        }

        public async Task<IList<Customer>> GetSelectedAsync(Expression<Func<Customer, bool>> expression)
        {
            return await _context.Customer.Include(x => x.User).Where(expression).ToListAsync();
        }
    }
}
