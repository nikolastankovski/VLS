namespace VLS.Infrastructure.Repositories
{
    public class ReferenceRepository : BaseRepository<Reference>, IReferenceRepository
    {
        public ReferenceRepository(VLSDbContext context) : base(context)
        {
        }
    }
}
