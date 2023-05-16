using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class TransactionVisitorRepository : Repository<TransactionVisitor>, ITransactionVisitorRepository
    {
        public TransactionVisitorRepository(VLSDbContext context, ILogger<TransactionVisitor> logger) : base(context, logger)
        {
        }
    }
}
