namespace VLS.Infrastructure.Repositories
{
    public class OrganizationalUnitRepository : BaseRepository<OrganizationalUnit>, IOrganizationalUnitRepository
    {
        public OrganizationalUnitRepository(VLSDbContext context) : base(context)
        {
        }
    }
}
