using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace VLS.Infrastructure.Repositories
{
    public class ReferenceTypeRepository : Repository<ReferenceType, VMReferenceType, DTOReferenceType>, IReferenceTypeRepository
    {
        public ReferenceTypeRepository(VLSDbContext context, ILogger<ReferenceType> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
        internal override Expression<Func<ReferenceType, bool>> GetWhereClauseByPK(object id)
        {
            return x => x.ReferenceTypeId == Convert.ToInt32(id);
        }
    }
}
