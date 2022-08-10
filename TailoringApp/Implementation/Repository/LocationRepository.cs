using TailoringApp.Context;
using TailoringApp.Entity;
using TailoringApp.Interface.IRepository;

namespace TailoringApp.Implementation.Repository
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        public LocationRepository(ApplicationContext context)
        {
            _context = context;
        }
    }
}
