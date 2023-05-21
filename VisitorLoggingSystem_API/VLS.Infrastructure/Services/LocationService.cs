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

            Location? location = await _locationRepo.GetByIdAsync(entity.LocationId);

            if(location == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound };

            location.Name = entity.Name;
            location.CountryId = entity.CountryId;
            location.CityId = entity.CityId;
            location.MunicipalityId = entity.MunicipalityId;

            return await _locationRepo.UpdateAsync(location);
        }
    }
}
