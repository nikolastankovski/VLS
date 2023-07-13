namespace VLS.Infrastructure.Repositories
{
    public class VisitorRepository : BaseRepository<Visitor>, IVisitorRepository
    {
        public VisitorRepository(VLSDbContext context) : base(context)
        {
        }
    }
}
