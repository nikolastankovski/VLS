using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class TransactionVehicleRepository : Repository<TransactionVehicle>, ITransactionVehicleRepository
    {
        public TransactionVehicleRepository(VLSDbContext context, ILogger<TransactionVehicle> logger) : base(context, logger)
        {
        }
    }
}
