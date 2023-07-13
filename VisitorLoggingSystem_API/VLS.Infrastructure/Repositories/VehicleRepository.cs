namespace VLS.Infrastructure.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(VLSDbContext context) : base(context)
        {
        }
    }
}
