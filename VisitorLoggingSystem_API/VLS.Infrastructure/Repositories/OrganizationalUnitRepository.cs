using AutoMapper;
using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class OrganizationalUnitRepository : Repository<OrganizationalUnit, VMOrganizationalUnit, DTOOrganizationalUnit>, IOrganizationalUnitRepository
    {
        public OrganizationalUnitRepository(VLSDbContext context, ILogger<OrganizationalUnit> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
    }
}
