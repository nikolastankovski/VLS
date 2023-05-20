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
    public class TransactionVisitorsController : ControllerBase
    {
        private readonly VLSDbContext _context;

        public TransactionVisitorsController(VLSDbContext context)
        {
            _context = context;
        }

        // GET: api/TransactionVisitors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionVisitor>>> GetTransactionVisitors()
        {
          if (_context.TransactionVisitors == null)
          {
              return NotFound();
          }
            return await _context.TransactionVisitors.ToListAsync();
        }

        // GET: api/TransactionVisitors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionVisitor>> GetTransactionVisitor(long id)
        {
          if (_context.TransactionVisitors == null)
          {
              return NotFound();
          }
            var transactionVisitor = await _context.TransactionVisitors.FindAsync(id);

            if (transactionVisitor == null)
            {
                return NotFound();
            }

            return transactionVisitor;
        }

        // PUT: api/TransactionVisitors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionVisitor(long id, TransactionVisitor transactionVisitor)
        {
            if (id != transactionVisitor.TransactionVisitorId)
            {
                return BadRequest();
            }

            _context.Entry(transactionVisitor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionVisitorExists(id))
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

        // POST: api/TransactionVisitors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransactionVisitor>> PostTransactionVisitor(TransactionVisitor transactionVisitor)
        {
          if (_context.TransactionVisitors == null)
          {
              return Problem("Entity set 'VLSDbContext.TransactionVisitors'  is null.");
          }
            _context.TransactionVisitors.Add(transactionVisitor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransactionVisitor", new { id = transactionVisitor.TransactionVisitorId }, transactionVisitor);
        }

        // DELETE: api/TransactionVisitors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionVisitor(long id)
        {
            if (_context.TransactionVisitors == null)
            {
                return NotFound();
            }
            var transactionVisitor = await _context.TransactionVisitors.FindAsync(id);
            if (transactionVisitor == null)
            {
                return NotFound();
            }

            _context.TransactionVisitors.Remove(transactionVisitor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionVisitorExists(long id)
        {
            return (_context.TransactionVisitors?.Any(e => e.TransactionVisitorId == id)).GetValueOrDefault();
        }
    }
}
