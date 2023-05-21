using Microsoft.AspNetCore.Mvc;

namespace VLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepo;

        public CountriesController(ICountryRepository countryRepo)
        {
            _countryRepo = countryRepo;
        }

        [HttpGet(nameof(GetAll))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ActionResponse() { IsSuccess = true, Data = await _countryRepo.GetAllVMAsync() });
        }

        // GET: api/Cities/GetById/1
        [HttpGet(nameof(GetById) + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResponse))]
        public async Task<IActionResult> GetById(int id)
        {
            DTOCountry? city = await _countryRepo.GetDTOByIdAsync(id);

            if (city is null)
                return NotFound(new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound });

            return Ok(new ActionResponse() { IsSuccess = true, Data = city });
        }
    }
}
