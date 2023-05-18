using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VLS.Domain.ViewModels;

namespace VLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly VLSDbContext _context;
        private readonly ILocationRepository _locationRepo;

        public LocationsController(VLSDbContext context, ILocationRepository locationRepo)
        {
            _context = context;
            _locationRepo = locationRepo;
        }

        // GET: api/Locations
        [HttpGet(nameof(GetAll))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<VMLocation>>> GetAll()
        {
            return Ok(await _locationRepo.GetAllVMAsync());
        }

        // GET: api/Locations/5
        [HttpGet(nameof(GetById) + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VMLocation>> GetById(int id)
        {
            DTOLocation? location = await _locationRepo.GetDTOByIdAsync(id);

            if (location is null)
                return BadRequest();

            return Ok(location);
        }

        // PUT: api/Locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, Location location)
        {
            if (id != location.Location_ID)
            {
                return BadRequest();
            }

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Location>> Create(DTOLocation location)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_locationRepo.Create(location));
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            if (_context.Locations == null)
            {
                return NotFound();
            }
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocationExists(int id)
        {
            return (_context.Locations?.Any(e => e.Location_ID == id)).GetValueOrDefault();
        }
    }
}
