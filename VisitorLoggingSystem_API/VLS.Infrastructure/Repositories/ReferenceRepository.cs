using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class ReferenceRepository : Repository<Reference>, IReferenceRepository
    {
        public ReferenceRepository(VLSDbContext context, ILogger<Reference> logger) : base(context, logger)
        {
        }
    }
}
