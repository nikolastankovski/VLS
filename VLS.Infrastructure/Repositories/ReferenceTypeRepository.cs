namespace VLS.Infrastructure.Repositories
{
    public class ReferenceTypeRepository : BaseRepository<ReferenceType>, IReferenceTypeRepository
    {
        public ReferenceTypeRepository(VLSDbContext context) : base(context)
        {
        }
    }
}
