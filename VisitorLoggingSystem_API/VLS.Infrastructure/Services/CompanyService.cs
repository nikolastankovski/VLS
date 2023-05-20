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

        public async Task<ActionResponse> UpdateAsync(DTOCompany entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            var location = await _companyRepo.GetByIdAsync(entity.CompanyId);

            if (location == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound };

            location.Name = entity.Name;
            location.Address = entity.Address;
            location.Email = entity.Email;
            location.PhoneNumber = entity.PhoneNumber;
            location.IDNumber = entity.IDNumber;

            return await _companyRepo.UpdateAsync(location);
        }
    }
}
