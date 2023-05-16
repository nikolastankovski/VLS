using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class OrganizationalUnitRepository : Repository<OrganizationalUnit>, IOrganizationalUnitRepository
    {
        public OrganizationalUnitRepository(VLSDbContext context, ILogger<OrganizationalUnit> logger) : base(context, logger)
        {
        }
    }
}
