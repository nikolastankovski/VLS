namespace VLS.Infrastructure.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(VLSDbContext context) : base(context)
        {
        }
    }
}
