using DomainLayer.Entities;
using Repository.DAL;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class MarkaRepository : Repository<Marka>, IMarkaRepository
    {
        public MarkaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
