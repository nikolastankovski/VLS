using VLS.Shared.Resources;

namespace VLS.Infrastructure.Services
{
    public class TransactionVisitorService
    {
        private readonly ITransactionVisitorRepository _transVisitorRepo;
        public TransactionVisitorService(ITransactionVisitorRepository transVisitorRepo)
        {
            _transVisitorRepo = transVisitorRepo;
        }

        public async Task<ActionResponse> UpdateAsync(DTOTransactionVisitor entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            TransactionVisitor? transVisitor = await _transVisitorRepo.GetByIdAsync(entity.TransactionVisitorId);

            if (transVisitor == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound };

            transVisitor.VisitorId = entity.VisitorId;
            transVisitor.VehicleRegistrationNumber = entity.VehicleRegistrationNumber;
            transVisitor.VisiteeCode = entity.VisiteeCode;
            transVisitor.OrganizationUnitCode = entity.OrganizationUnitCode;
            transVisitor.LocationId = entity.LocationId;
            transVisitor.SpecificPlace = entity.SpecificPlace;
            transVisitor.EntryDateTime = entity.EntryDateTime;
            transVisitor.ExitDateTime = entity.ExitDateTime;
            transVisitor.ActivityId = entity.ActivityId;
            transVisitor.Incident = entity.Incident;
            transVisitor.IncidentDescription = entity.IncidentDescription;

            return await _transVisitorRepo.UpdateAsync(transVisitor);
        }
    }
}
