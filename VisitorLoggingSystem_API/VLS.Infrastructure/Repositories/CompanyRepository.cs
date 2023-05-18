using AutoMapper;
using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class CompanyRepository : Repository<Company, VMCompany, DTOCompany>, ICompanyRepository
    {
        public CompanyRepository(VLSDbContext context, ILogger<Company> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
    }
}
