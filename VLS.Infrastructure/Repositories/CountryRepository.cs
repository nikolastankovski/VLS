namespace VLS.Infrastructure.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(VLSDbContext context) : base(context)
        {
        }
    }
}
