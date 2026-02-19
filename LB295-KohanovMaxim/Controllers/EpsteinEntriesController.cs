using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KohanovMaximLB_295.Data;
using KohanovMaximLB_295.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KohanovMaximLB_295.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EpsteinEntriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EpsteinEntriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EpsteinEntry>>> GetAll()
        {
            return await _context.EpsteinEntries.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EpsteinEntry>> Get(int id)
        {
            var entry = await _context.EpsteinEntries.FindAsync(id);
            if (entry == null) return NotFound();
            return entry;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<EpsteinEntry>> Create(EpsteinEntry entry)
        {
            _context.EpsteinEntries.Add(entry);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = entry.Id }, entry);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, EpsteinEntry entry)
        {
            if (id != entry.Id) return BadRequest();
            _context.Entry(entry).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var entry = await _context.EpsteinEntries.FindAsync(id);
            if (entry == null) return NotFound();
            _context.EpsteinEntries.Remove(entry);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
