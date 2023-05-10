using Microsoft.Extensions.Logging;
using VLS.Domain.DbModels;
using VLS.Infrastructure.Data;
using VLS.Infrastructure.Interfaces.IRepositories;
using VLS.Infrastructure.Repositories.BaseRepositories;

namespace VLS.Infrastructure.Repositories
{
    public class TransactionVehicleRepository : Repository<TransactionVehicle>, ITransactionVehicleRepository
    {
        public TransactionVehicleRepository(VLSDbContext context, ILogger<TransactionVehicle> logger) : base(context, logger)
        {
        }
    }
}
