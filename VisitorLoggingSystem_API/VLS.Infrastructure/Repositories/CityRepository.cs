using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace VLS.Infrastructure.Repositories
{
    public class CityRepository : ViewRepository<City, VMCity, DTOCity>, ICityRepository
    {
        public CityRepository(VLSDbContext context, ILogger<City> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }

        internal override Expression<Func<City, bool>> GetWhereClauseByPK(object id)
        {
            return x => x.CityId == Convert.ToInt32(id);
        }
    }
}
