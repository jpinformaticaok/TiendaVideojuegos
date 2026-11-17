using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Services.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        private readonly TiendaContext _context;
        public ProvinciasController(TiendaContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Provincia>>> GetProvincias([FromQuery] string filtro = "")
        {
            filtro = filtro.ToUpper();
            return await _context.Provincias.Include(p => p.Pais)
                .Where(p => p.Name.ToUpper().Contains(filtro)).ToListAsync();
        }

        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Provincia>>> GetDeleteds() =>
            await _context.Provincias.IgnoreQueryFilters().Include(p => p.Pais).Where(p => p.isDeleted).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Provincia>> GetProvincia(int id)
        {
            var p = await _context.Provincias.Include(x => x.Pais).FirstOrDefaultAsync(x => x.Id == id);
            if (p == null) return NotFound();
            return p;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvincia(int id, Provincia provincia)
        {
            if (id != provincia.Id) return BadRequest();
            _context.Entry(provincia).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.Provincias.Any(e => e.Id == id)) return NotFound(); else throw; }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Provincia>> PostProvincia(Provincia provincia)
        {
            _context.Provincias.Add(provincia);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProvincia", new { id = provincia.Id }, provincia);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvincia(int id)
        {
            var p = await _context.Provincias.FindAsync(id);
            if (p == null) return NotFound();
            p.isDeleted = true;
            _context.Entry(p).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreProvincia(int id)
        {
            var p = await _context.Provincias.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.Id == id);
            if (p == null) return NotFound();
            p.isDeleted = false;
            _context.Entry(p).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}