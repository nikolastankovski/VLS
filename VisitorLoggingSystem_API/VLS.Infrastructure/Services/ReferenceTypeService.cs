using VLS.Shared.Resources;

namespace VLS.Infrastructure.Services
{
    public class ReferenceTypeService
    {
        private readonly IReferenceTypeRepository _referenceTypeRepo;
        public ReferenceTypeService(IReferenceTypeRepository referenceRepo)
        {
            _referenceTypeRepo = referenceRepo;
        }

        public async Task<ActionResponse> UpdateAsync(ReferenceType entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            ReferenceType? reference = await _referenceTypeRepo.GetByIdAsync(entity.ReferenceTypeId);

            if (reference == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound };

            reference.Description = entity.Description;
            reference.Code = entity.Code;

            return await _referenceTypeRepo.UpdateAsync(reference);
        }
    }
}
