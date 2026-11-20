using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Services.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatosController : ControllerBase
    {
        private readonly TiendaContext _context;

        public FormatosController(TiendaContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Formato>>> GetFormatos([FromQuery] string filtro = "")
        {
            filtro = filtro.ToUpper();
            return await _context.Formatos.Where(f => f.Name.ToUpper().Contains(filtro)).ToListAsync();
        }

        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Formato>>> GetDeleteds() =>
            await _context.Formatos.IgnoreQueryFilters().Where(f => f.isDeleted).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Formato>> GetFormato(int id)
        {
            var f = await _context.Formatos.FindAsync(id);
            if (f == null) return NotFound();
            return f;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormato(int id, Formato formato)
        {
            if (id != formato.Id) return BadRequest();
            _context.Entry(formato).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.Formatos.Any(e => e.Id == id)) return NotFound(); else throw; }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Formato>> PostFormato(Formato formato)
        {
            _context.Formatos.Add(formato);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFormato", new { id = formato.Id }, formato);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormato(int id)
        {
            var f = await _context.Formatos.FindAsync(id);
            if (f == null) return NotFound();
            f.isDeleted = true;
            _context.Entry(f).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreFormato(int id)
        {
            var f = await _context.Formatos.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.Id == id);
            if (f == null) return NotFound();
            f.isDeleted = false;
            _context.Entry(f).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
