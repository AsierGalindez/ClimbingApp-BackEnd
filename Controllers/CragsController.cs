using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClimbingBack.Data;
using ClimbingBack.Models;

namespace ClimbingBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CragsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CragsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Crags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Crag>>> GetCrag()
        {
            return await _context.Crag.Include(r => r.Routes).ToListAsync();
        }

        // GET: api/Crags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Crag>> GetCrag(int id)
        {
            var crag = await _context.Crag.FindAsync(id);

            if (crag == null)
            {
                return NotFound();
            }

            return crag;
        }

        // PUT: api/Crags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrag(int id, Crag crag)
        {
            if (id != crag.Id)
            {
                return BadRequest();
            }

            _context.Entry(crag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CragExists(id))
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

        // POST: api/Crags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Crag>> PostCrag(Crag crag)
        {
            _context.Crag.Add(crag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCrag", new { id = crag.Id }, crag);
        }
        [HttpGet("crag/{crag}")]
        public async Task<ActionResult<IEnumerable<Crag>>> GetCrag(string name)
        {
            var crag = await _context.Crag.Where(c => c.Name == name).Include(r => r.Routes).ToListAsync();

            if (crag == null)
            {
                return NotFound();
            }

            return crag;
        }
        // DELETE: api/Crags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrag(int id)
        {
            var crag = await _context.Crag.FindAsync(id);
            if (crag == null)
            {
                return NotFound();
            }

            _context.Crag.Remove(crag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CragExists(int id)
        {
            return _context.Crag.Any(e => e.Id == id);
        }
    }
}
