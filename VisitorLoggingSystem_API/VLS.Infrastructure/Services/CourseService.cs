using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLS.Shared.Resources;

namespace VLS.Infrastructure.Services
{
    public class CourseService
    {
        private readonly ICourseRepository _courseRepo;
        public CourseService(ICourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
        }

        public async Task<ActionResponse> UpdateAsync(DTOCourse entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            Course? course = await _courseRepo.GetByIdAsync(entity.CourseId);

            if (course == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound };

            course.Name = entity.Name;
            course.ShortName = entity.ShortName;
            course.IsMandatory = entity.IsMandatory;

            return await _courseRepo.UpdateAsync(course);
        }
    }
}
