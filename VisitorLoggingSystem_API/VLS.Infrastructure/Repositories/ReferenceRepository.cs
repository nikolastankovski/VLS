using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace VLS.Infrastructure.Repositories
{
    public class ReferenceRepository : Repository<Reference, VMReference, DTOReference>, IReferenceRepository
    {
        public ReferenceRepository(VLSDbContext context, ILogger<Reference> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
        internal override Expression<Func<Reference, bool>> GetWhereClauseByPK(object id)
        {
            return x => x.ReferenceId == Convert.ToInt32(id);
        }
    }
}
