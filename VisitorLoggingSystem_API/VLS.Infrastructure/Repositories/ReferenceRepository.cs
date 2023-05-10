using Microsoft.Extensions.Logging;
using VLS.Domain.DbModels;
using VLS.Infrastructure.Data;
using VLS.Infrastructure.Interfaces.IRepositories;
using VLS.Infrastructure.Repositories.BaseRepositories;

namespace VLS.Infrastructure.Repositories
{
    public class ReferenceRepository : Repository<Reference>, IReferenceRepository
    {
        public ReferenceRepository(VLSDbContext context, ILogger<Reference> logger) : base(context, logger)
        {
        }
    }
}
