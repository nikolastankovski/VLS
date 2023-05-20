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
    public class ReferenceTypesController : ControllerBase
    {
        private readonly VLSDbContext _context;

        public ReferenceTypesController(VLSDbContext context)
        {
            _context = context;
        }

        // GET: api/ReferenceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReferenceType>>> GetReferenceTypes()
        {
          if (_context.ReferenceTypes == null)
          {
              return NotFound();
          }
            return await _context.ReferenceTypes.ToListAsync();
        }

        // GET: api/ReferenceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReferenceType>> GetReferenceType(int id)
        {
          if (_context.ReferenceTypes == null)
          {
              return NotFound();
          }
            var referenceType = await _context.ReferenceTypes.FindAsync(id);

            if (referenceType == null)
            {
                return NotFound();
            }

            return referenceType;
        }

        // PUT: api/ReferenceTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReferenceType(int id, ReferenceType referenceType)
        {
            if (id != referenceType.ReferenceTypeId)
            {
                return BadRequest();
            }

            _context.Entry(referenceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferenceTypeExists(id))
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

        // POST: api/ReferenceTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReferenceType>> PostReferenceType(ReferenceType referenceType)
        {
          if (_context.ReferenceTypes == null)
          {
              return Problem("Entity set 'VLSDbContext.ReferenceTypes'  is null.");
          }
            _context.ReferenceTypes.Add(referenceType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReferenceType", new { id = referenceType.ReferenceTypeId }, referenceType);
        }

        // DELETE: api/ReferenceTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReferenceType(int id)
        {
            if (_context.ReferenceTypes == null)
            {
                return NotFound();
            }
            var referenceType = await _context.ReferenceTypes.FindAsync(id);
            if (referenceType == null)
            {
                return NotFound();
            }

            _context.ReferenceTypes.Remove(referenceType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReferenceTypeExists(int id)
        {
            return (_context.ReferenceTypes?.Any(e => e.ReferenceTypeId == id)).GetValueOrDefault();
        }
    }
}
