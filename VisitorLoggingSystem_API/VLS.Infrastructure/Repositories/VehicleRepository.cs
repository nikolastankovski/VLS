using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(VLSDbContext context, ILogger<Vehicle> logger) : base(context, logger)
        {
        }
    }
}
