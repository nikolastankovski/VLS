using VLS.Shared.Resources;

namespace VLS.Infrastructure.Services
{
    public class LocationService
    {
        private readonly ILocationRepository _locationRepo;
        public LocationService(ILocationRepository locationRepo)
        {
            _locationRepo = locationRepo;
        }

        public async Task<ActionResponse> UpdateAsync(DTOLocation entity)
        {
            if(entity == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            var location = await _locationRepo.GetByIdAsync(entity.Location_ID);

            if(location == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound };

            location.Name = entity.Name;
            location.Country_ID = entity.Country_ID;
            location.City_ID = entity.City_ID;
            location.Municipality_ID = entity.Municipality_ID;

            return await _locationRepo.UpdateAsync(location);
        }
    }
}
