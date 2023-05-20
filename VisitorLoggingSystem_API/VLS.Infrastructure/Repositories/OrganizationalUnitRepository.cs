using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace VLS.Infrastructure.Repositories
{
    public class OrganizationalUnitRepository : Repository<OrganizationalUnit, VMOrganizationalUnit, DTOOrganizationalUnit>, IOrganizationalUnitRepository
    {
        public OrganizationalUnitRepository(VLSDbContext context, ILogger<OrganizationalUnit> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
        internal override Expression<Func<OrganizationalUnit, bool>> GetWhereClauseByPK(object id)
        {
            return x => x.OrganizationalUnitId == Convert.ToInt32(id);
        }
    }
}
