using Microsoft.AspNetCore.Mvc;
using VLS.Infrastructure.Constants;
using VLS.Infrastructure.Services;

namespace VLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceTypesController : ControllerBase
    {
        private readonly IReferenceTypeRepository _referenceTypeRepo;
        private readonly ReferenceTypeService _referenceTypeService;
        private readonly LoggingService _logService;

        public ReferenceTypesController(IReferenceTypeRepository referenceTypeRepo, ReferenceTypeService referenceTypeService, LoggingService logService)
        {
            _referenceTypeRepo = referenceTypeRepo;
            _referenceTypeService = referenceTypeService;
            _logService = logService;
        }

        // GET: api/Locations/GetAll
        [HttpGet(nameof(GetAll))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReferenceType>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _referenceTypeRepo.GetAllAsync());
            }
            catch (Exception e)
            {
                ApplicationLog log = new ApplicationLog()
                {
                    Application = nameof(Applications.VLS_API),
                    Source = $"{Request.Path}{Request.QueryString}",
                    IsSuccess = false,
                    Description = $"Exception: {(e.InnerException == null ? e.Message : e.InnerException.Message)}",
                    LogDateTime = DateTime.Now
                };

                await _logService.LogAsync(log);

                return StatusCode(statusCode: StatusCodes.Status500InternalServerError, Resources.UnexpectedErrorOccured);
            }
        }

        // GET: api/Locations/GetById/5
        [HttpGet(nameof(GetById) + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReferenceType))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                ReferenceType? entity = await _referenceTypeRepo.GetByIdAsync(id);

                if (entity is null)
                    return NotFound(Resources.EntityNotFound);

                return Ok(entity);
            }
            catch (Exception e)
            {
                ApplicationLog log = new ApplicationLog()
                {
                    Application = nameof(Applications.VLS_API),
                    Source = $"{Request.Path}{Request.QueryString}",
                    IsSuccess = false,
                    Description = $"Exception: {(e.InnerException == null ? e.Message : e.InnerException.Message)}",
                    LogDateTime = DateTime.Now
                };

                await _logService.LogAsync(log);

                return StatusCode(statusCode: StatusCodes.Status500InternalServerError, Resources.UnexpectedErrorOccured);
            }
        }

        // POST: api/Locations/Create
        /*[HttpPost(nameof(Create))]
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
        }*/

        // POST: api/Locations/BulkCreate
        /*[HttpPost(nameof(BulkCreate))]
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
        }*/

        // PUT: api/Locations/Update
        /*[HttpPut(nameof(Update))]
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
        }*/

        // DELETE: api/Locations/Delete/5
        /*[HttpDelete(nameof(Delete) + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse))]
        public async Task<IActionResult> Delete(int id)
        {
            ActionResponse deleteResponse = await _referenceTypeRepo.DeleteAsync(id);

            if (!deleteResponse.IsSuccess)
                return BadRequest(deleteResponse);

            return Ok(deleteResponse);
        }*/
    }
}
