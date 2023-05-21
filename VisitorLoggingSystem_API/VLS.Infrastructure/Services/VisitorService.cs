using VLS.Shared.Resources;

namespace VLS.Infrastructure.Services
{
    public class VisitorService
    {
        private readonly IVisitorRepository _visitorRepo;
        public VisitorService(IVisitorRepository visitorRepo)
        {
            _visitorRepo = visitorRepo;
        }

        public async Task<ActionResponse> UpdateAsync(DTOVisitor entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            Visitor? visitor = await _visitorRepo.GetByIdAsync(entity.VisitorId);

            if (visitor == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound };

            visitor.FullName = entity.FullName;
            visitor.IDTypeId = entity.IDTypeId;
            visitor.IDNumber = entity.IDNumber;
            visitor.IDExpirationDate = entity.IDExpirationDate;
            visitor.CountryId = entity.CountryId;
            visitor.CompanyId = entity.CompanyId;

            return await _visitorRepo.UpdateAsync(visitor);
        }
    }
}
