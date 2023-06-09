using DomainLayer.Common;
using Microsoft.EntityFrameworkCore;
using Repository.DAL;
using Repository.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<T> _entities;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _entities = _appDbContext.Set<T>();
        }

        public async Task Create(T entity)
        {
            if (entity == null) throw new ArgumentNullException();
            await _entities.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException();
            _entities.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task SoftDelete(T entity)
        {
            T model = await _entities.FirstOrDefaultAsync(m => m.Id == entity.Id) ?? throw new NullReferenceException();
            model.IsDeleted = true;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _entities.FindAsync(id) ?? throw new NullReferenceException();
        }

        public async Task<List<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<List<T>> FindAll(Expression<Func<T, bool>> predicate)
        {
            return await _entities.Where(predicate).ToListAsync();
        }

        public async Task Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException();
            _entities.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> IsExists(Expression<Func<T, bool>> predicate)
        {
            return await _entities.AnyAsync(predicate);
        }
    }
}
