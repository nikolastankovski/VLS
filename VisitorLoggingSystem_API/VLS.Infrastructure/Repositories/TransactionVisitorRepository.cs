using Microsoft.Extensions.Logging;
using VLS.Domain.DbModels;
using VLS.Infrastructure.Data;
using VLS.Infrastructure.Interfaces.IRepositories;
using VLS.Infrastructure.Repositories.BaseRepositories;

namespace VLS.Infrastructure.Repositories
{
    public class TransactionVisitorRepository : Repository<TransactionVisitor>, ITransactionVisitorRepository
    {
        public TransactionVisitorRepository(VLSDbContext context, ILogger<TransactionVisitor> logger) : base(context, logger)
        {
        }
    }
}
