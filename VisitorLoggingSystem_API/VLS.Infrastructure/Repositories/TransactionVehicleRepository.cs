using AutoMapper;
using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class TransactionVehicleRepository : Repository<TransactionVehicle, VMTransactionVehicle, DTOTransactionVehicle>, ITransactionVehicleRepository
    {
        public TransactionVehicleRepository(VLSDbContext context, ILogger<TransactionVehicle> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
    }
}
