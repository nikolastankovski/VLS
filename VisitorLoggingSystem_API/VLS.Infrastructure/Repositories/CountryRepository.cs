using AutoMapper;
using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class CountryRepository : ViewRepository<Country, VMCountry, DTOCountry>, ICountryRepository
    {
        public CountryRepository(VLSDbContext context, ILogger<Country> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
    }
}
