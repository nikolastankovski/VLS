using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(VLSDbContext context, ILogger<Location> logger) : base(context, logger)
        {
        }
    }
}
