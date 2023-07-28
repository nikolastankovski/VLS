using Microsoft.AspNetCore.Mvc;
using VLS.Infrastructure.Services;

namespace VLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferencesController : ControllerBase
    {
        private readonly IReferenceRepository _referenceRepo;
        private readonly ReferenceService _referenceService;

        public ReferencesController(IReferenceRepository referenceRepo, ReferenceService referenceService)
        {
            _referenceRepo = referenceRepo;
            _referenceService = referenceService;
        }

        // GET: api/Locations/GetAll
        [HttpGet(nameof(GetAll))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        public async Task<IActionResult> GetAll()
        {
            ActionResponse response = new ActionResponse() { IsSuccess = true, Data = await _referenceRepo.GetAllAsync() };

            return Ok(response);
        }

        // GET: api/Locations/GetById/5
        [HttpGet(nameof(GetById) + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResponse))]
        public async Task<IActionResult> GetById(int id)
        {
            Reference? reference = await _referenceRepo.GetByIdAsync(id);

            if (reference is null)
                return NotFound(new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound });

            return Ok(new ActionResponse() { IsSuccess = true, Data = reference });
        }

        // POST: api/Locations/Create
        [HttpPost(nameof(Create))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse))]
        public async Task<IActionResult> Create(Reference reference)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ActionResponse() { IsSuccess = false, Message = Resources.ModelStateInvalid });

            ActionResponse createResponse = await _referenceRepo.CreateAsync(reference);

            if (!createResponse.IsSuccess)
                return BadRequest(createResponse);

            return Ok(createResponse);
        }

        // POST: api/Locations/BulkCreate
        [HttpPost(nameof(BulkCreate))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse))]
        public async Task<IActionResult> BulkCreate(List<Reference> references)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ActionResponse() { IsSuccess = false, Message = Resources.ModelStateInvalid });

            ActionResponse createResponse = await _referenceRepo.CreateAsync(references);

            if (!createResponse.IsSuccess)
                return BadRequest(createResponse);

            return Ok(createResponse);
        }

        // PUT: api/Locations/Update
        [HttpPut(nameof(Update))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse))]
        public async Task<IActionResult> Update(Reference reference)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ActionResponse() { IsSuccess = false, Message = Resources.ModelStateInvalid });

            ActionResponse updateResponse = await _referenceService.UpdateAsync(reference);

            if (!updateResponse.IsSuccess)
                return BadRequest(updateResponse);

            return Ok(updateResponse);
        }

        // DELETE: api/Locations/Delete/5
        [HttpDelete(nameof(Delete) + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse))]
        public async Task<IActionResult> Delete(int id)
        {
            ActionResponse deleteResponse = await _referenceRepo.DeleteAsync(id);

            if (!deleteResponse.IsSuccess)
                return BadRequest(deleteResponse);

            return Ok(deleteResponse);
        }
    }
}
