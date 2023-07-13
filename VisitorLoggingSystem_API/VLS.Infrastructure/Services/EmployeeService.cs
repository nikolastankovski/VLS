using VLS.Shared.Resources;

namespace VLS.Infrastructure.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;
        public EmployeeService(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<ActionResponse> UpdateAsync(Employee entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            Employee? employee = await _employeeRepo.GetByIdAsync(entity.EmployeeId);

            if (employee == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound };

            employee.Name = entity.Name;
            employee.Code = entity.Code;
            employee.PersonalNumber = entity.PersonalNumber;
            employee.OrganizationalUnitCode = entity.OrganizationalUnitCode;
            employee.IsActive = entity.IsActive;

            return await _employeeRepo.UpdateAsync(employee);
        }
    }
}
