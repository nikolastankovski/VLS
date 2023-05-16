using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(VLSDbContext context, ILogger<Company> logger) : base(context, logger)
        {
        }
    }
}
