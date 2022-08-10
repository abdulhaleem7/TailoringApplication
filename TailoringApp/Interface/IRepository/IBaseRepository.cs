using System.Linq.Expressions;
using TailoringApp.Contract;
using TailoringApp.Identity;

namespace TailoringApp.Interface.IRepository
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        Task<T> Create(T entity);

        Task<T> Update(T entity);
        Task<bool> SaveChanges();
    }
}
