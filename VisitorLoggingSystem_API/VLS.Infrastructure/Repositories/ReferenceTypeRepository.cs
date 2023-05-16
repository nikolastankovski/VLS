using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class ReferenceTypeRepository : Repository<ReferenceType>, IReferenceTypeRepository
    {
        public ReferenceTypeRepository(VLSDbContext context, ILogger<ReferenceType> logger) : base(context, logger)
        {
        }
    }
}
