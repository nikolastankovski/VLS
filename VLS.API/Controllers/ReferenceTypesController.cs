using Microsoft.AspNetCore.Mvc;
using VLS.Infrastructure.Services;

namespace VLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceTypesController : ControllerBase
    {
        private readonly IReferenceTypeRepository _referenceTypeRepo;
        private readonly ReferenceTypeService _referenceTypeService;

        public ReferenceTypesController(IReferenceTypeRepository referenceTypeRepo, ReferenceTypeService referenceTypeService)
        {
            _referenceTypeRepo = referenceTypeRepo;
            _referenceTypeService = referenceTypeService;
        }

        // GET: api/Locations/GetAll
        [HttpGet(nameof(GetAll))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        public async Task<IActionResult> GetAll()
        {
            ActionResponse response = new ActionResponse() { IsSuccess = true, Data = await _referenceTypeRepo.GetAllAsync() };

            return Ok(response);
        }

        // GET: api/Locations/GetById/5
        [HttpGet(nameof(GetById) + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResponse))]
        public async Task<IActionResult> GetById(int id)
        {
            ReferenceType? referenceType = await _referenceTypeRepo.GetByIdAsync(id);

            if (referenceType is null)
                return NotFound(new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound });

            return Ok(new ActionResponse() { IsSuccess = true, Data = referenceType });
        }

        // POST: api/Locations/Create
        [HttpPost(nameof(Create))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse))]
        public async Task<IActionResult> Create(ReferenceType referenceType)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ActionResponse() { IsSuccess = false, Message = Resources.ModelStateInvalid });

            ActionResponse createResponse = await _referenceTypeRepo.CreateAsync(referenceType);

            if (!createResponse.IsSuccess)
                return BadRequest(createResponse);

            return Ok(createResponse);
        }

        // POST: api/Locations/BulkCreate
        [HttpPost(nameof(BulkCreate))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse))]
        public async Task<IActionResult> BulkCreate(List<ReferenceType> referenceTypes)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ActionResponse() { IsSuccess = false, Message = Resources.ModelStateInvalid });

            ActionResponse createResponse = await _referenceTypeRepo.CreateAsync(referenceTypes);

            if (!createResponse.IsSuccess)
                return BadRequest(createResponse);

            return Ok(createResponse);
        }

        // PUT: api/Locations/Update
        [HttpPut(nameof(Update))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse))]
        public async Task<IActionResult> Update(ReferenceType referenceType)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ActionResponse() { IsSuccess = false, Message = Resources.ModelStateInvalid });

            ActionResponse updateResponse = await _referenceTypeService.UpdateAsync(referenceType);

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
            ActionResponse deleteResponse = await _referenceTypeRepo.DeleteAsync(id);

            if (!deleteResponse.IsSuccess)
                return BadRequest(deleteResponse);

            return Ok(deleteResponse);
        }
    }
}
