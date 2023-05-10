using Microsoft.Extensions.Logging;
using VLS.Domain.DbModels;
using VLS.Infrastructure.Data;
using VLS.Infrastructure.Interfaces.IRepositories;
using VLS.Infrastructure.Repositories.BaseRepositories;

namespace VLS.Infrastructure.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(VLSDbContext context, ILogger<Company> logger) : base(context, logger)
        {
        }
    }
}
