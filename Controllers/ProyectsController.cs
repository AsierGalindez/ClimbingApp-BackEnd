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
    public class ProyectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProyectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Proyects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyect>>> GetProyect()
        {
            return await _context.Proyect.ToListAsync();
        }

        // GET: api/Proyects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyect>> GetProyect(int id)
        {
            var proyect = await _context.Proyect.FindAsync(id);

            if (proyect == null)
            {
                return NotFound();
            }

            return proyect;
        }

        // PUT: api/Proyects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyect(int id, Proyect proyect)
        {
            if (id != proyect.Id)
            {
                return BadRequest();
            }

            _context.Entry(proyect).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectExists(id))
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

        // POST: api/Proyects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proyect>> PostProyect(Proyect proyect)
        {
            _context.Proyect.Add(proyect);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProyect", new { id = proyect.Id }, proyect);
        }

        // DELETE: api/Proyects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProyect(int id)
        {
            var proyect = await _context.Proyect.FindAsync(id);
            if (proyect == null)
            {
                return NotFound();
            }

            _context.Proyect.Remove(proyect);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProyectExists(int id)
        {
            return _context.Proyect.Any(e => e.Id == id);
        }
    }
}
