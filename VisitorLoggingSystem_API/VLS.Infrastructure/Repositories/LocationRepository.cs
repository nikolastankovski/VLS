using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class LocationRepository : Repository<Location, VMLocation, DTOLocation>, ILocationRepository
    {
        public LocationRepository(VLSDbContext context, ILogger<Location> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
    }
}
