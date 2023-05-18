using AutoMapper;
using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class ReferenceRepository : Repository<Reference, VMReference, DTOReference>, IReferenceRepository
    {
        public ReferenceRepository(VLSDbContext context, ILogger<Reference> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
    }
}
