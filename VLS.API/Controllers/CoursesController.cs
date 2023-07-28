using Microsoft.AspNetCore.Mvc;
using VLS.Infrastructure.Services;

namespace VLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepo;
        private readonly CourseService _courseService;

        public CoursesController(ICourseRepository courseRepo, CourseService courseService)
        {
            _courseRepo = courseRepo;
            _courseService = courseService;
        }

        // GET: api/Locations/GetAll
        [HttpGet(nameof(GetAll))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        public async Task<IActionResult> GetAll()
        {
            ActionResponse response = new ActionResponse() { IsSuccess = true, Data = await _courseRepo.GetAllAsync() };

            return Ok(response);
        }

        // GET: api/Locations/GetById/5
        [HttpGet(nameof(GetById) + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResponse))]
        public async Task<IActionResult> GetById(int id)
        {
            Course? course = await _courseRepo.GetByIdAsync(id);

            if (course is null)
                return NotFound(new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound });

            return Ok(new ActionResponse() { IsSuccess = true, Data = course });
        }

        // POST: api/Locations/Create
        [HttpPost(nameof(Create))]
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
        }

        // POST: api/Locations/BulkCreate
        [HttpPost(nameof(BulkCreate))]
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
        }

        // PUT: api/Locations/Update
        [HttpPut(nameof(Update))]
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
        }

        // DELETE: api/Locations/Delete/5
        [HttpDelete(nameof(Delete) + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ActionResponse))]
        public async Task<IActionResult> Delete(int id)
        {
            ActionResponse deleteResponse = await _courseRepo.DeleteAsync(id);

            if (!deleteResponse.IsSuccess)
                return BadRequest(deleteResponse);

            return Ok(deleteResponse);
        }
    }
}
