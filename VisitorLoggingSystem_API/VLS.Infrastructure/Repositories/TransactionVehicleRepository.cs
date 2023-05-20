using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace VLS.Infrastructure.Repositories
{
    public class TransactionVehicleRepository : Repository<TransactionVehicle, VMTransactionVehicle, DTOTransactionVehicle>, ITransactionVehicleRepository
    {
        public TransactionVehicleRepository(VLSDbContext context, ILogger<TransactionVehicle> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
        internal override Expression<Func<TransactionVehicle, bool>> GetWhereClauseByPK(object id)
        {
            return x => x.TransactionVehicleId == Convert.ToInt64(id);
        }
    }
}
