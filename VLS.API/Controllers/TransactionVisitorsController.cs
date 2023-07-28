using Microsoft.AspNetCore.Mvc;
using VLS.Infrastructure.Services;

namespace VLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionVisitorsController : ControllerBase
    {
        private readonly ITransactionVisitorRepository _transVisitorRepo;
        private readonly TransactionVisitorService _transVisitorService;

        public TransactionVisitorsController(ITransactionVisitorRepository transVisitorRepo, TransactionVisitorService transVisitorService)
        {
            _transVisitorRepo = transVisitorRepo;
            _transVisitorService = transVisitorService;
        }

        // GET: api/Locations/GetAll
        [HttpGet(nameof(GetAll))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        public async Task<IActionResult> GetAll()
        {
            ActionResponse response = new ActionResponse() { IsSuccess = true, Data = await _transVisitorRepo.GetAllAsync() };

            return Ok(response);
        }

        // GET: api/Locations/GetById/5
        [HttpGet(nameof(GetById) + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResponse))]
        public async Task<IActionResult> GetById(int id)
        {
            TransactionVisitor? transVisitor = await _transVisitorRepo.GetByIdAsync(id);

            if (transVisitor is null)
                return NotFound(new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound });

            return Ok(new ActionResponse() { IsSuccess = true, Data = transVisitor });
        }

        // POST: api/Locations/Create
        [HttpPost(nameof(Create))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse))]
        public async Task<IActionResult> Create(TransactionVisitor transVisitor)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ActionResponse() { IsSuccess = false, Message = Resources.ModelStateInvalid });

            ActionResponse createResponse = await _transVisitorRepo.CreateAsync(transVisitor);

            if (!createResponse.IsSuccess)
                return BadRequest(createResponse);

            return Ok(createResponse);
        }

        // POST: api/Locations/BulkCreate
        [HttpPost(nameof(BulkCreate))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse))]
        public async Task<IActionResult> BulkCreate(List<TransactionVisitor> transVisitors)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ActionResponse() { IsSuccess = false, Message = Resources.ModelStateInvalid });

            ActionResponse createResponse = await _transVisitorRepo.CreateAsync(transVisitors);

            if (!createResponse.IsSuccess)
                return BadRequest(createResponse);

            return Ok(createResponse);
        }

        // PUT: api/Locations/Update
        [HttpPut(nameof(Update))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse))]
        public async Task<IActionResult> Update(TransactionVisitor transVisitor)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ActionResponse() { IsSuccess = false, Message = Resources.ModelStateInvalid });

            ActionResponse updateResponse = await _transVisitorService.UpdateAsync(transVisitor);

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
            ActionResponse deleteResponse = await _transVisitorRepo.DeleteAsync(id);

            if (!deleteResponse.IsSuccess)
                return BadRequest(deleteResponse);

            return Ok(deleteResponse);
        }
    }
}
