using DomainLayer.Common;
using System.Linq.Expressions;

namespace Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task SoftDelete(T entity);
        Task<List<T>> FindAll(Expression<Func<T, bool>> predicate);
        Task<bool> IsExists(Expression<Func<T, bool>> predicate);
    }
}
