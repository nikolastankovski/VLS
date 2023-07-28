namespace VLS.Infrastructure.Repositories
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        public LocationRepository(VLSDbContext context) : base(context)
        {
        }
    }
}
