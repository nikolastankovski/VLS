namespace VLS.Infrastructure.Repositories
{
    public class TransactionVisitorRepository : BaseRepository<TransactionVisitor>, ITransactionVisitorRepository
    {
        public TransactionVisitorRepository(VLSDbContext context) : base(context)
        {
        }
    }
}
