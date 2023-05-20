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
    public class ReferencesController : ControllerBase
    {
        private readonly VLSDbContext _context;

        public ReferencesController(VLSDbContext context)
        {
            _context = context;
        }

        // GET: api/References
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reference>>> GetReferences()
        {
          if (_context.References == null)
          {
              return NotFound();
          }
            return await _context.References.ToListAsync();
        }

        // GET: api/References/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reference>> GetReference(int id)
        {
          if (_context.References == null)
          {
              return NotFound();
          }
            var reference = await _context.References.FindAsync(id);

            if (reference == null)
            {
                return NotFound();
            }

            return reference;
        }

        // PUT: api/References/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReference(int id, Reference reference)
        {
            if (id != reference.ReferenceId)
            {
                return BadRequest();
            }

            _context.Entry(reference).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferenceExists(id))
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

        // POST: api/References
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reference>> PostReference(Reference reference)
        {
          if (_context.References == null)
          {
              return Problem("Entity set 'VLSDbContext.References'  is null.");
          }
            _context.References.Add(reference);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReference", new { id = reference.ReferenceId }, reference);
        }

        // DELETE: api/References/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReference(int id)
        {
            if (_context.References == null)
            {
                return NotFound();
            }
            var reference = await _context.References.FindAsync(id);
            if (reference == null)
            {
                return NotFound();
            }

            _context.References.Remove(reference);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReferenceExists(int id)
        {
            return (_context.References?.Any(e => e.ReferenceId == id)).GetValueOrDefault();
        }
    }
}
