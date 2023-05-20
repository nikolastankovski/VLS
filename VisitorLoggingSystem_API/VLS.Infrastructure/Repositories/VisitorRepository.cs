using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace VLS.Infrastructure.Repositories
{
    public class VisitorRepository : Repository<Visitor, VMVisitor, DTOVisitor>, IVisitorRepository
    {
        public VisitorRepository(VLSDbContext context, ILogger<Visitor> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
        internal override Expression<Func<Visitor, bool>> GetWhereClauseByPK(object id)
        {
            return x => x.VisitorId == Convert.ToInt64(id);
        }
    }
}
