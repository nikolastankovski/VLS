using VLS.Shared.Resources;

namespace VLS.Infrastructure.Services
{
    public class OrganizationalUnitService
    {
        private readonly IOrganizationalUnitRepository _orgUnitRepo;
        public OrganizationalUnitService(IOrganizationalUnitRepository orgUnit)
        {
            _orgUnitRepo = orgUnit;
        }

        public async Task<ActionResponse> UpdateAsync(OrganizationalUnit entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            OrganizationalUnit? orgUnit = await _orgUnitRepo.GetByIdAsync(entity.OrganizationalUnitId);

            if (orgUnit == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound };

            orgUnit.Name = entity.Name;
            orgUnit.Code = entity.Code;

            return await _orgUnitRepo.UpdateAsync(orgUnit);
        }
    }
}
