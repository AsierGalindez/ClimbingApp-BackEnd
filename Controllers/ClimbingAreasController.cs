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
    public class ClimbingAreasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClimbingAreasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ClimbingAreas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClimbingArea>>> GetClimbingArea()
        {
            return await _context.ClimbingArea.Include(c=>c.Crags).ToListAsync();
        }

        // GET: api/ClimbingAreas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClimbingArea>> GetClimbingArea(int id)
        {
            var climbingArea = await _context.ClimbingArea.FindAsync(id);

            if (climbingArea == null)
            {
                return NotFound();
            }

            return climbingArea;
        }
        // GET: api/ClimbingAreas/province
        [HttpGet("province/{province}")]
        public async Task<ActionResult<IEnumerable<ClimbingArea>>> GetClimbingArea(string province)
        {
            var climbingArea = await _context.ClimbingArea.Where(p => p.Province == province).Include(c => c.Crags).ThenInclude(r=>r.Routes).ToListAsync();

            if (climbingArea == null)
            {
                return NotFound();
            }

            return climbingArea;
        }

        // PUT: api/ClimbingAreas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClimbingArea(int id, ClimbingArea climbingArea)
        {
            if (id != climbingArea.Id)
            {
                return BadRequest();
            }

            _context.Entry(climbingArea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClimbingAreaExists(id))
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

        // POST: api/ClimbingAreas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClimbingArea>> PostClimbingArea(ClimbingArea climbingArea)
        {
            _context.ClimbingArea.Add(climbingArea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClimbingArea", new { id = climbingArea.Id }, climbingArea);
        }

        // DELETE: api/ClimbingAreas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClimbingArea(int id)
        {
            var climbingArea = await _context.ClimbingArea.FindAsync(id);
            if (climbingArea == null)
            {
                return NotFound();
            }

            _context.ClimbingArea.Remove(climbingArea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClimbingAreaExists(int id)
        {
            return _context.ClimbingArea.Any(e => e.Id == id);
        }
    }
}
