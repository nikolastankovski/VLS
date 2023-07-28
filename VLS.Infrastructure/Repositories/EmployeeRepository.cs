namespace VLS.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(VLSDbContext context) : base(context)
        {
        }
    }
}
