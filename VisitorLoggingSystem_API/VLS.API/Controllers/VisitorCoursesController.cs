using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VLS.Domain.DbModels;
using VLS.Infrastructure.Data;

namespace VLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorCoursesController : ControllerBase
    {
        private readonly VLSDbContext _context;

        public VisitorCoursesController(VLSDbContext context)
        {
            _context = context;
        }

        // GET: api/VisitorCourses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitorCourse>>> GetVisitorCourses()
        {
          if (_context.VisitorCourses == null)
          {
              return NotFound();
          }
            return await _context.VisitorCourses.ToListAsync();
        }

        // GET: api/VisitorCourses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VisitorCourse>> GetVisitorCourse(int id)
        {
          if (_context.VisitorCourses == null)
          {
              return NotFound();
          }
            var visitorCourse = await _context.VisitorCourses.FindAsync(id);

            if (visitorCourse == null)
            {
                return NotFound();
            }

            return visitorCourse;
        }

        // PUT: api/VisitorCourses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitorCourse(int id, VisitorCourse visitorCourse)
        {
            if (id != visitorCourse.VisitorCourseId)
            {
                return BadRequest();
            }

            _context.Entry(visitorCourse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitorCourseExists(id))
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

        // POST: api/VisitorCourses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VisitorCourse>> PostVisitorCourse(VisitorCourse visitorCourse)
        {
          if (_context.VisitorCourses == null)
          {
              return Problem("Entity set 'VLSDbContext.VisitorCourses'  is null.");
          }
            _context.VisitorCourses.Add(visitorCourse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVisitorCourse", new { id = visitorCourse.VisitorCourseId }, visitorCourse);
        }

        // DELETE: api/VisitorCourses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitorCourse(int id)
        {
            if (_context.VisitorCourses == null)
            {
                return NotFound();
            }
            var visitorCourse = await _context.VisitorCourses.FindAsync(id);
            if (visitorCourse == null)
            {
                return NotFound();
            }

            _context.VisitorCourses.Remove(visitorCourse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VisitorCourseExists(int id)
        {
            return (_context.VisitorCourses?.Any(e => e.VisitorCourseId == id)).GetValueOrDefault();
        }
    }
}
