using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace VLS.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee, VMEmployee, DTOEmployee>, IEmployeeRepository
    {
        public EmployeeRepository(VLSDbContext context, ILogger<Employee> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
        internal override Expression<Func<Employee, bool>> GetWhereClauseByPK(object id)
        {
            return x => x.EmployeeId == Convert.ToInt32(id);
        }
    }
}
