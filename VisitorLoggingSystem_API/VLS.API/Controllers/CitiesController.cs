using Microsoft.AspNetCore.Mvc;

namespace VLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepository _cityRepo;

        public CitiesController(ICityRepository cityRepo)
        {
            _cityRepo = cityRepo;
        }

        // GET: api/Cities/GetAll
        [HttpGet(nameof(GetAll))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ActionResponse() { IsSuccess = true, Data = await _cityRepo.GetAllVMAsync() });
        }

        // GET: api/Cities/GetById/1
        [HttpGet(nameof(GetById) + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResponse))]
        public async Task<IActionResult> GetById(int id)
        {
            DTOCity? city = await _cityRepo.GetDTOByIdAsync(id);

            if (city is null)
                return NotFound(new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound});

            return Ok(new ActionResponse() { IsSuccess = true, Data = city });
        }        
    }
}
