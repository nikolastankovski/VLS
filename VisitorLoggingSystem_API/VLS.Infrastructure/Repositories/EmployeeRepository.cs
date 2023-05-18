using AutoMapper;
using Microsoft.Extensions.Logging;

namespace VLS.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee, VMEmployee, DTOEmployee>, IEmployeeRepository
    {
        public EmployeeRepository(VLSDbContext context, ILogger<Employee> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
    }
}
