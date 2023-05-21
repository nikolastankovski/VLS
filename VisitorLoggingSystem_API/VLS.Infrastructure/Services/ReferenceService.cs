using VLS.Shared.Resources;

namespace VLS.Infrastructure.Services
{
    public class ReferenceService
    {
        private readonly IReferenceRepository _referenceRepo;
        public ReferenceService(IReferenceRepository referenceRepo)
        {
            _referenceRepo = referenceRepo;
        }

        public async Task<ActionResponse> UpdateAsync(DTOReference entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            Reference? reference = await _referenceRepo.GetByIdAsync(entity.ReferenceId);

            if (reference == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound };

            reference.ReferenceTypeId = entity.ReferenceTypeId;
            reference.Description = entity.Description;
            reference.Code = entity.Code;

            return await _referenceRepo.UpdateAsync(reference);
        }
    }
}
