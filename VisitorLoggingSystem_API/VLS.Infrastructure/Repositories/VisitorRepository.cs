using AutoMapper;
using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class VisitorRepository : Repository<Visitor, VMVisitor, DTOVisitor>, IVisitorRepository
    {
        public VisitorRepository(VLSDbContext context, ILogger<Visitor> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
    }
}
