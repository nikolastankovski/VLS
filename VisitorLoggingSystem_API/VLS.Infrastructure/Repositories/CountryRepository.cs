using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace VLS.Infrastructure.Repositories
{
    public class CountryRepository : ViewRepository<Country, VMCountry, DTOCountry>, ICountryRepository
    {
        public CountryRepository(VLSDbContext context, ILogger<Country> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
        internal override Expression<Func<Country, bool>> GetWhereClauseByPK(object id)
        {
            return x => x.CountryId == Convert.ToInt32(id);
        }
    }
}
