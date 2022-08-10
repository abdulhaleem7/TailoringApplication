using System.Linq.Expressions;
using TailoringApp.Context;
using TailoringApp.Entity;
using TailoringApp.Interface.IRepository;

namespace TailoringApp.Implementation.Repository
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task<IList<Payment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GetAsync(Expression<Func<Payment, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Payment>> GetSelectedAsync(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Payment>> GetSelectedAsync(Expression<Func<Payment, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
