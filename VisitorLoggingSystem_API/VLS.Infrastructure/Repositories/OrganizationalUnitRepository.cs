using Microsoft.Extensions.Logging;
using VLS.Domain.DbModels;
using VLS.Infrastructure.Data;
using VLS.Infrastructure.Interfaces.IRepositories;
using VLS.Infrastructure.Repositories.BaseRepositories;

namespace VLS.Infrastructure.Repositories
{
    public class OrganizationalUnitRepository : Repository<OrganizationalUnit>, IOrganizationalUnitRepository
    {
        public OrganizationalUnitRepository(VLSDbContext context, ILogger<OrganizationalUnit> logger) : base(context, logger)
        {
        }
    }
}
