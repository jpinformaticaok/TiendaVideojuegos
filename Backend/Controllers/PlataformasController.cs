using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Services.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlataformasController : ControllerBase
    {
        private readonly TiendaContext _context;

        public PlataformasController(TiendaContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plataforma>>> GetPlataformas([FromQuery] string filtro = "")
        {
            filtro = filtro.ToUpper();
            return await _context.Plataformas.Where(p => p.Name.ToUpper().Contains(filtro)).ToListAsync();
        }

        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Plataforma>>> GetDeleteds() =>
            await _context.Plataformas.IgnoreQueryFilters().Where(p => p.isDeleted).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Plataforma>> GetPlataforma(int id)
        {
            var p = await _context.Plataformas.FindAsync(id);
            if (p == null) return NotFound();
            return p;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlataforma(int id, Plataforma plataforma)
        {
            if (id != plataforma.Id) return BadRequest();
            _context.Entry(plataforma).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.Plataformas.Any(e => e.Id == id)) return NotFound(); else throw; }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Plataforma>> PostPlataforma(Plataforma plataforma)
        {
            _context.Plataformas.Add(plataforma);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPlataforma", new { id = plataforma.Id }, plataforma);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlataforma(int id)
        {
            var p = await _context.Plataformas.FindAsync(id);
            if (p == null) return NotFound();
            p.isDeleted = true;
            _context.Entry(p).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestorePlataforma(int id)
        {
            var p = await _context.Plataformas.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.Id == id);
            if (p == null) return NotFound();
            p.isDeleted = false;
            _context.Entry(p).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
