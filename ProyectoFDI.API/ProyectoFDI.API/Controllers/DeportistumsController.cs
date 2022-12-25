using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFDI.API.Entidades;

namespace ProyectoFDI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeportistumsController : ControllerBase
    {
        private readonly ProyectoFdiContext _context;

        public DeportistumsController(ProyectoFdiContext context)
        {
            _context = context;
        }

        // GET: api/Deportistums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deportistum>>> GetDeportista()
        {
            return await _context.Deportista.ToListAsync();
        }

        // GET: api/Deportistums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deportistum>> GetDeportistum(int id)
        {
            var deportistum = await _context.Deportista.FindAsync(id);

            if (deportistum == null)
            {
                return NotFound();
            }

            return deportistum;
        }

        // PUT: api/Deportistums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeportistum(int id, Deportistum deportistum)
        {
            if (id != deportistum.IdDep)
            {
                return BadRequest();
            }

            _context.Entry(deportistum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeportistumExists(id))
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

        // POST: api/Deportistums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Deportistum>> PostDeportistum(Deportistum deportistum)
        {
            _context.Deportista.Add(deportistum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeportistum", new { id = deportistum.IdDep }, deportistum);
        }

        // DELETE: api/Deportistums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeportistum(int id)
        {
            var deportistum = await _context.Deportista.FindAsync(id);
            if (deportistum == null)
            {
                return NotFound();
            }

            _context.Deportista.Remove(deportistum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeportistumExists(int id)
        {
            return _context.Deportista.Any(e => e.IdDep == id);
        }
    }
}
