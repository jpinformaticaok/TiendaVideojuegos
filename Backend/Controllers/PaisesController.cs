using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Services.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly TiendaContext _context;
        public PaisesController(TiendaContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pais>>> GetPaises([FromQuery] string filtro = "")
        {
            filtro = filtro.ToUpper();
            return await _context.Paises.Where(p => p.Name.ToUpper().Contains(filtro)).ToListAsync();
        }

        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Pais>>> GetDeleteds() =>
            await _context.Paises.IgnoreQueryFilters().Where(p => p.isDeleted).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> GetPais(int id)
        {
            var p = await _context.Paises.FindAsync(id);
            if (p == null) return NotFound();
            return p;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPais(int id, Pais pais)
        {
            if (id != pais.Id) return BadRequest();
            _context.Entry(pais).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.Paises.Any(e => e.Id == id)) return NotFound(); else throw; }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Pais>> PostPais(Pais pais)
        {
            _context.Paises.Add(pais);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPais", new { id = pais.Id }, pais);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePais(int id)
        {
            var p = await _context.Paises.FindAsync(id);
            if (p == null) return NotFound();
            p.isDeleted = true;
            _context.Entry(p).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestorePais(int id)
        {
            var p = await _context.Paises.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.Id == id);
            if (p == null) return NotFound();
            p.isDeleted = false;
            _context.Entry(p).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}