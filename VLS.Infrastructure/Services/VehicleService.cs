using VLS.Shared.Resources;

namespace VLS.Infrastructure.Services
{
    public class VehicleService
    {
        private readonly IVehicleRepository _vehicleRepo;
        public VehicleService(IVehicleRepository vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;
        }

        /*public async Task<ActionResponse> UpdateAsync(Vehicle entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            Vehicle? vehicle = await _vehicleRepo.GetByIdAsync(entity.VehicleId);

            if (vehicle == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound };

            vehicle.CompanyId = entity.CompanyId;
            vehicle.RegistrationNumber = entity.RegistrationNumber;
            vehicle.TechnicalCorrectnessExpireDate = entity.TechnicalCorrectnessExpireDate;
            vehicle.Description = entity.Description;

            return await _vehicleRepo.UpdateAsync(vehicle);
        }*/
    }
}
