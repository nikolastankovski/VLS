using Microsoft.Extensions.Logging;
using VLS.Domain.DbModels;
using VLS.Infrastructure.Data;
using VLS.Infrastructure.Interfaces.IRepositories;
using VLS.Infrastructure.Repositories.BaseRepositories;

namespace VLS.Infrastructure.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(VLSDbContext context, ILogger<Location> logger) : base(context, logger)
        {
        }
    }
}
