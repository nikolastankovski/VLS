using VLS.Shared.Resources;

namespace VLS.Infrastructure.Services
{
    public class TransactionVehicleService
    {
        private readonly ITransactionVehicleRepository _transVehicleRepo;
        public TransactionVehicleService(ITransactionVehicleRepository transVehicleRepo)
        {
            _transVehicleRepo = transVehicleRepo;
        }

        /*public async Task<ActionResponse> UpdateAsync(TransactionVehicle entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            TransactionVehicle? transVehicle = await _transVehicleRepo.GetByIdAsync(entity.TransactionVehicleId);

            if (transVehicle == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound };

            transVehicle.LocationId = transVehicle.LocationId;
            transVehicle.VehicleId = transVehicle.VehicleId;
            transVehicle.EntryDateTime = transVehicle.EntryDateTime;
            transVehicle.ExitDateTime = transVehicle.ExitDateTime;
            transVehicle.EntryVisitorId = transVehicle.EntryVisitorId;
            transVehicle.ExitVisitorId = transVehicle.ExitVisitorId;

            return await _transVehicleRepo.UpdateAsync(transVehicle);
        }*/
    }
}
