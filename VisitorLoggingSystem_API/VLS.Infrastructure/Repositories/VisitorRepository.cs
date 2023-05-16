using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class VisitorRepository : Repository<Visitor>, IVisitorRepository
    {
        public VisitorRepository(VLSDbContext context, ILogger<Visitor> logger) : base(context, logger)
        {
        }
    }
}
