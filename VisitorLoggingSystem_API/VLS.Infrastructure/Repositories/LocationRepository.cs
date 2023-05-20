using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace VLS.Infrastructure.Repositories
{
    public class LocationRepository : Repository<Location, VMLocation, DTOLocation>, ILocationRepository
    {
        public LocationRepository(VLSDbContext context, ILogger<Location> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
        internal override Expression<Func<Location, bool>> GetWhereClauseByPK(object id)
        {
            return x => x.LocationId == Convert.ToInt32(id);
        }
    }
}
