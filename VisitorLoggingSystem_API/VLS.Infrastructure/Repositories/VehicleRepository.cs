using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace VLS.Infrastructure.Repositories
{
    public class VehicleRepository : Repository<Vehicle, VMVehicle, DTOVehicle>, IVehicleRepository
    {
        public VehicleRepository(VLSDbContext context, ILogger<Vehicle> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
        internal override Expression<Func<Vehicle, bool>> GetWhereClauseByPK(object id)
        {
            return x => x.VehicleId == Convert.ToInt64(id);
        }
    }
}
