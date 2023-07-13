namespace VLS.Infrastructure.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(VLSDbContext context) : base(context)
        {
        }

     
    }
}
