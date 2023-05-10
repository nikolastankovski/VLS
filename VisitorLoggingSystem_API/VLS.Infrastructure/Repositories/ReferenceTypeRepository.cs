using Microsoft.Extensions.Logging;
using VLS.Domain.DbModels;
using VLS.Infrastructure.Data;
using VLS.Infrastructure.Interfaces.IRepositories;
using VLS.Infrastructure.Repositories.BaseRepositories;

namespace VLS.Infrastructure.Repositories
{
    public class ReferenceTypeRepository : Repository<ReferenceType>, IReferenceTypeRepository
    {
        public ReferenceTypeRepository(VLSDbContext context, ILogger<ReferenceType> logger) : base(context, logger)
        {
        }
    }
}
