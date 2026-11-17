using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Services.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadesController : ControllerBase
    {
        private readonly TiendaContext _context;
        public LocalidadesController(TiendaContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Localidad>>> GetLocalidades([FromQuery] string filtro = "")
        {
            filtro = filtro.ToUpper();
            return await _context.Localidades
                .Include(l => l.Provincia).ThenInclude(p => p.Pais)
                .Where(l => l.Name.ToUpper().Contains(filtro))
                .ToListAsync();
        }

        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Localidad>>> GetDeleteds()
        {
            return await _context.Localidades.IgnoreQueryFilters()
                .Include(l => l.Provincia).ThenInclude(p => p.Pais)
                .Where(l => l.isDeleted).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Localidad>> GetLocalidad(int id)
        {
            var l = await _context.Localidades.Include(x => x.Provincia).ThenInclude(p => p.Pais).FirstOrDefaultAsync(x => x.Id == id);
            if (l == null) return NotFound();
            return l;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalidad(int id, Localidad localidad)
        {
            if (id != localidad.Id) return BadRequest();
            _context.Entry(localidad).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.Localidades.Any(e => e.Id == id)) return NotFound(); else throw; }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Localidad>> PostLocalidad(Localidad localidad)
        {
            _context.Localidades.Add(localidad);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetLocalidad", new { id = localidad.Id }, localidad);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalidad(int id)
        {
            var l = await _context.Localidades.FindAsync(id);
            if (l == null) return NotFound();
            l.isDeleted = true;
            _context.Entry(l).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreLocalidad(int id)
        {
            var l = await _context.Localidades.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.Id == id);
            if (l == null) return NotFound();
            l.isDeleted = false;
            _context.Entry(l).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}