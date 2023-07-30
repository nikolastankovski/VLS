using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VLS.Domain.DbModels;
using VLS.Infrastructure.Constants;
using VLS.Infrastructure.Data;
using VLS.Infrastructure.Services;

namespace VLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorsController : ControllerBase
    {
        private readonly IVisitorRepository _visitorRepo;
        private readonly VisitorService _visitorService;
        private readonly LoggingService _logService;

        public VisitorsController(IVisitorRepository referenceRepo, VisitorService referenceService, LoggingService logService)
        {
            _visitorRepo = referenceRepo;
            _visitorService = referenceService;
            _logService = logService;
        }

        // GET: api/Locations/GetAll
        [HttpGet(nameof(GetAll))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Visitor>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _visitorRepo.GetAllAsync());
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Visitor))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Visitor? entity = await _visitorRepo.GetByIdAsync(id);

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
        public async Task<IActionResult> Create(Visitor vehicle)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ActionResponse() { IsSuccess = false, Message = Resources.ModelStateInvalid });

            ActionResponse createResponse = await _visitorRepo.CreateAsync(vehicle);

            if (!createResponse.IsSuccess)
                return BadRequest(createResponse);

            return Ok(createResponse);
        }*/

        // POST: api/Locations/BulkCreate
        /*[HttpPost(nameof(BulkCreate))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse))]
        public async Task<IActionResult> BulkCreate(List<Visitor> visitors)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ActionResponse() { IsSuccess = false, Message = Resources.ModelStateInvalid });

            ActionResponse createResponse = await _visitorRepo.CreateAsync(visitors);

            if (!createResponse.IsSuccess)
                return BadRequest(createResponse);

            return Ok(createResponse);
        }*/

        // PUT: api/Locations/Update
        /*[HttpPut(nameof(Update))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse))]
        public async Task<IActionResult> Update(Visitor visitor)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ActionResponse() { IsSuccess = false, Message = Resources.ModelStateInvalid });

            ActionResponse updateResponse = await _visitorService.UpdateAsync(visitor);

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
            ActionResponse deleteResponse = await _visitorRepo.DeleteAsync(id);

            if (!deleteResponse.IsSuccess)
                return BadRequest(deleteResponse);

            return Ok(deleteResponse);
        }*/
    }
}
