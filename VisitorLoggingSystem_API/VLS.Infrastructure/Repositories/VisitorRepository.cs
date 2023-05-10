using Microsoft.Extensions.Logging;
using VLS.Domain.DbModels;
using VLS.Infrastructure.Data;
using VLS.Infrastructure.Interfaces.IRepositories;
using VLS.Infrastructure.Repositories.BaseRepositories;

namespace VLS.Infrastructure.Repositories
{
    public class VisitorRepository : Repository<Visitor>, IVisitorRepository
    {
        public VisitorRepository(VLSDbContext context, ILogger<Visitor> logger) : base(context, logger)
        {
        }
    }
}
