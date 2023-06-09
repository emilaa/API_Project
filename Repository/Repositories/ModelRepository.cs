using DomainLayer.Entities;
using Repository.DAL;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class ModelRepository : Repository<Model>, IModelRepository
    {
        public ModelRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
