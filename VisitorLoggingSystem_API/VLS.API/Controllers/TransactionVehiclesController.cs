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
    public class TransactionVehiclesController : ControllerBase
    {
        private readonly VLSDbContext _context;

        public TransactionVehiclesController(VLSDbContext context)
        {
            _context = context;
        }

        // GET: api/TransactionVehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionVehicle>>> GetTransactionVehicles()
        {
          if (_context.TransactionVehicles == null)
          {
              return NotFound();
          }
            return await _context.TransactionVehicles.ToListAsync();
        }

        // GET: api/TransactionVehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionVehicle>> GetTransactionVehicle(long id)
        {
          if (_context.TransactionVehicles == null)
          {
              return NotFound();
          }
            var transactionVehicle = await _context.TransactionVehicles.FindAsync(id);

            if (transactionVehicle == null)
            {
                return NotFound();
            }

            return transactionVehicle;
        }

        // PUT: api/TransactionVehicles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionVehicle(long id, TransactionVehicle transactionVehicle)
        {
            if (id != transactionVehicle.TransactionVehicleId)
            {
                return BadRequest();
            }

            _context.Entry(transactionVehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionVehicleExists(id))
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

        // POST: api/TransactionVehicles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransactionVehicle>> PostTransactionVehicle(TransactionVehicle transactionVehicle)
        {
          if (_context.TransactionVehicles == null)
          {
              return Problem("Entity set 'VLSDbContext.TransactionVehicles'  is null.");
          }
            _context.TransactionVehicles.Add(transactionVehicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransactionVehicle", new { id = transactionVehicle.TransactionVehicleId }, transactionVehicle);
        }

        // DELETE: api/TransactionVehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionVehicle(long id)
        {
            if (_context.TransactionVehicles == null)
            {
                return NotFound();
            }
            var transactionVehicle = await _context.TransactionVehicles.FindAsync(id);
            if (transactionVehicle == null)
            {
                return NotFound();
            }

            _context.TransactionVehicles.Remove(transactionVehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionVehicleExists(long id)
        {
            return (_context.TransactionVehicles?.Any(e => e.TransactionVehicleId == id)).GetValueOrDefault();
        }
    }
}
