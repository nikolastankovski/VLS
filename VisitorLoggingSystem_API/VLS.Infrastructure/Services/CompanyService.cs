using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLS.Shared.Resources;

namespace VLS.Infrastructure.Services
{
    public class CompanyService
    {
        private readonly ICompanyRepository _companyRepo;

        public CompanyService(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }

        public async Task<ActionResponse> UpdateAsync(Company entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            Company? company = await _companyRepo.GetByIdAsync(entity.CompanyId);

            if (company == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound };

            company.Name = entity.Name;
            company.Address = entity.Address;
            company.Email = entity.Email;
            company.PhoneNumber = entity.PhoneNumber;
            company.IDNumber = entity.IDNumber;

            return await _companyRepo.UpdateAsync(company);
        }
    }
}
