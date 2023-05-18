using AutoMapper;
using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class CityRepository : ViewRepository<City, VMCity, DTOCity>, ICityRepository
    {
        public CityRepository(VLSDbContext context, ILogger<City> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
    }
}
