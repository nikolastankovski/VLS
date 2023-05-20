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
    public class OrganizationalUnitsController : ControllerBase
    {
        private readonly VLSDbContext _context;

        public OrganizationalUnitsController(VLSDbContext context)
        {
            _context = context;
        }

        // GET: api/OrganizationalUnits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizationalUnit>>> GetOrganizationalUnits()
        {
          if (_context.OrganizationalUnits == null)
          {
              return NotFound();
          }
            return await _context.OrganizationalUnits.ToListAsync();
        }

        // GET: api/OrganizationalUnits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationalUnit>> GetOrganizationalUnit(int id)
        {
          if (_context.OrganizationalUnits == null)
          {
              return NotFound();
          }
            var organizationalUnit = await _context.OrganizationalUnits.FindAsync(id);

            if (organizationalUnit == null)
            {
                return NotFound();
            }

            return organizationalUnit;
        }

        // PUT: api/OrganizationalUnits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizationalUnit(int id, OrganizationalUnit organizationalUnit)
        {
            if (id != organizationalUnit.OrganizationalUnitId)
            {
                return BadRequest();
            }

            _context.Entry(organizationalUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationalUnitExists(id))
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

        // POST: api/OrganizationalUnits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrganizationalUnit>> PostOrganizationalUnit(OrganizationalUnit organizationalUnit)
        {
          if (_context.OrganizationalUnits == null)
          {
              return Problem("Entity set 'VLSDbContext.OrganizationalUnits'  is null.");
          }
            _context.OrganizationalUnits.Add(organizationalUnit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganizationalUnit", new { id = organizationalUnit.OrganizationalUnitId }, organizationalUnit);
        }

        // DELETE: api/OrganizationalUnits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizationalUnit(int id)
        {
            if (_context.OrganizationalUnits == null)
            {
                return NotFound();
            }
            var organizationalUnit = await _context.OrganizationalUnits.FindAsync(id);
            if (organizationalUnit == null)
            {
                return NotFound();
            }

            _context.OrganizationalUnits.Remove(organizationalUnit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrganizationalUnitExists(int id)
        {
            return (_context.OrganizationalUnits?.Any(e => e.OrganizationalUnitId == id)).GetValueOrDefault();
        }
    }
}
