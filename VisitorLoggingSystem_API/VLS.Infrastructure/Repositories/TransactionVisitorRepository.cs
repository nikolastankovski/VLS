using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace VLS.Infrastructure.Repositories
{
    public class TransactionVisitorRepository : Repository<TransactionVisitor, VMTransactionVisitor, DTOTransactionVisitor>, ITransactionVisitorRepository
    {
        public TransactionVisitorRepository(VLSDbContext context, ILogger<TransactionVisitor> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
        internal override Expression<Func<TransactionVisitor, bool>> GetWhereClauseByPK(object id)
        {
            return x => x.TransactionVisitorId == Convert.ToInt64(id);
        }
    }
}
