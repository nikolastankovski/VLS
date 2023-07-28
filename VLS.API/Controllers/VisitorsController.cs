using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VLS.Domain.DbModels;
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

        public VisitorsController(IVisitorRepository referenceRepo, VisitorService referenceService)
        {
            _visitorRepo = referenceRepo;
            _visitorService = referenceService;
        }

        // GET: api/Locations/GetAll
        [HttpGet(nameof(GetAll))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        public async Task<IActionResult> GetAll()
        {
            ActionResponse response = new ActionResponse() { IsSuccess = true, Data = await _visitorRepo.GetAllAsync() };

            return Ok(response);
        }

        // GET: api/Locations/GetById/5
        [HttpGet(nameof(GetById) + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResponse))]
        public async Task<IActionResult> GetById(int id)
        {
            Visitor? visitor = await _visitorRepo.GetByIdAsync(id);

            if (visitor is null)
                return NotFound(new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound });

            return Ok(new ActionResponse() { IsSuccess = true, Data = visitor });
        }

        // POST: api/Locations/Create
        [HttpPost(nameof(Create))]
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
        }

        // POST: api/Locations/BulkCreate
        [HttpPost(nameof(BulkCreate))]
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
        }

        // PUT: api/Locations/Update
        [HttpPut(nameof(Update))]
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
        }

        // DELETE: api/Locations/Delete/5
        [HttpDelete(nameof(Delete) + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse))]
        public async Task<IActionResult> Delete(int id)
        {
            ActionResponse deleteResponse = await _visitorRepo.DeleteAsync(id);

            if (!deleteResponse.IsSuccess)
                return BadRequest(deleteResponse);

            return Ok(deleteResponse);
        }
    }
}
