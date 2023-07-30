using Microsoft.AspNetCore.Mvc;
using VLS.Infrastructure.Constants;
using VLS.Infrastructure.Services;

namespace VLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepo;
        private readonly CourseService _courseService;
        private readonly LoggingService _logService;


        public CoursesController(ICourseRepository courseRepo, CourseService courseService, LoggingService logService)
        {
            _courseRepo = courseRepo;
            _courseService = courseService;
            _logService = logService;
        }

        // GET: api/Locations/GetAll
        [HttpGet(nameof(GetAll))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Course>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _courseRepo.GetAllAsync());
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Course))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Course? entity = await _courseRepo.GetByIdAsync(id);

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
        public async Task<IActionResult> Create(Course course)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ActionResponse() { IsSuccess = false, Message = Resources.ModelStateInvalid });

            ActionResponse createResponse = await _courseRepo.CreateAsync(course);

            if (!createResponse.IsSuccess)
                return BadRequest(createResponse);

            return Ok(createResponse);
        }*/

        // POST: api/Locations/BulkCreate
        /*[HttpPost(nameof(BulkCreate))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse))]
        public async Task<IActionResult> BulkCreate(List<Course> courses)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ActionResponse() { IsSuccess = false, Message = Resources.ModelStateInvalid });

            ActionResponse createResponse = await _courseRepo.CreateAsync(courses);

            if (!createResponse.IsSuccess)
                return BadRequest(createResponse);

            return Ok(createResponse);
        }*/

        // PUT: api/Locations/Update
        /*[HttpPut(nameof(Update))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse))]
        public async Task<IActionResult> Update(Course company)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ActionResponse() { IsSuccess = false, Message = Resources.ModelStateInvalid });

            ActionResponse updateResponse = await _courseService.UpdateAsync(company);

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
            ActionResponse deleteResponse = await _courseRepo.DeleteAsync(id);

            if (!deleteResponse.IsSuccess)
                return BadRequest(deleteResponse);

            return Ok(deleteResponse);
        }*/
    }
}
