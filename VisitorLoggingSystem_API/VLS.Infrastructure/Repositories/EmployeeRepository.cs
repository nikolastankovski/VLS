using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(VLSDbContext context, ILogger<Employee> logger) : base(context, logger)
        {
        }
    }
}
