using AutoMapper;
using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class TransactionVisitorRepository : Repository<TransactionVisitor, VMTransactionVisitor, DTOTransactionVisitor>, ITransactionVisitorRepository
    {
        public TransactionVisitorRepository(VLSDbContext context, ILogger<TransactionVisitor> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
    }
}
