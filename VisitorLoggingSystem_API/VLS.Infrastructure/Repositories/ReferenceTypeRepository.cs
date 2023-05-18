using AutoMapper;
using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class ReferenceTypeRepository : Repository<ReferenceType, VMReferenceType, DTOReferenceType>, IReferenceTypeRepository
    {
        public ReferenceTypeRepository(VLSDbContext context, ILogger<ReferenceType> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
    }
}
