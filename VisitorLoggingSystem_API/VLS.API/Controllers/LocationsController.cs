using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VLS.Domain.ViewModels;
using VLS.Infrastructure.Services;
using VLS.Shared.Resources;

namespace VLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly VLSDbContext _context;
        private readonly ILocationRepository _locationRepo;
        private readonly LocationService _locationService;

        public LocationsController(VLSDbContext context, ILocationRepository locationRepo, LocationService locationService)
        {
            _context = context;
            _locationRepo = locationRepo;
            _locationService = locationService;
        }

        // GET: api/Locations/GetAll
        [HttpGet(nameof(GetAll))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<VMLocation>>> GetAll()
        {
            return Ok(await _locationRepo.GetAllVMAsync());
        }

        // GET: api/Locations/GetById/5
        [HttpGet(nameof(GetById) + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VMLocation>> GetById(int id)
        {
            DTOLocation? location = await _locationRepo.GetDTOByIdAsync(id);

            if (location is null)
                return BadRequest();

            return Ok(location);
        }

        // POST: api/Locations/Create
        [HttpPost(nameof(Create))]
        [ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Location>> Create(DTOLocation location)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var create = await _locationRepo.CreateAsync(location);

            if (!create.IsSuccess)
                return BadRequest(create.Message);

            return Ok(create.Message);
        }

        // POST: api/Locations/BulkCreate
        [HttpPost(nameof(BulkCreate))]
        [ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Location>> BulkCreate(List<DTOLocation> locations)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var create = await _locationRepo.CreateAsync(locations);

            if (!create.IsSuccess)
                return BadRequest(create.Message);

            return Ok(create.Message);
        }

        // PUT: api/Locations/Update
        [HttpPut(nameof(Update))]
        [ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(DTOLocation location)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var updateResponse = await _locationService.UpdateAsync(location);

            if (!updateResponse.IsSuccess)
                return BadRequest(updateResponse);

            return Ok(updateResponse);
        }

        // DELETE: api/Locations/Delete/5
        [HttpDelete(nameof(Delete) + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _locationRepo.DeleteAsync(id);

            if(!delete.IsSuccess)
                return BadRequest(delete.Message);

            return Ok(delete.Message);
        }
    }
}
