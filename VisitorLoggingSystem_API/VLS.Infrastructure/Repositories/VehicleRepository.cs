using AutoMapper;
using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class VehicleRepository : Repository<Vehicle, VMVehicle, DTOVehicle>, IVehicleRepository
    {
        public VehicleRepository(VLSDbContext context, ILogger<Vehicle> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
    }
}
