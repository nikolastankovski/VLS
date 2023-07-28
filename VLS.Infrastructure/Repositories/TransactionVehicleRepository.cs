namespace VLS.Infrastructure.Repositories
{
    public class TransactionVehicleRepository : BaseRepository<TransactionVehicle>, ITransactionVehicleRepository
    {
        public TransactionVehicleRepository(VLSDbContext context) : base(context)
        {
        }
    }
}
