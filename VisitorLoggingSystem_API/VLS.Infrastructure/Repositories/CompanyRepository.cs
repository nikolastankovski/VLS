using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace VLS.Infrastructure.Repositories
{
    public class CompanyRepository : Repository<Company, VMCompany, DTOCompany>, ICompanyRepository
    {
        public CompanyRepository(VLSDbContext context, ILogger<Company> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
        internal override Expression<Func<Company, bool>> GetWhereClauseByPK(object id)
        {
            return x => x.CompanyId == Convert.ToInt32(id);
        }
    }
}
