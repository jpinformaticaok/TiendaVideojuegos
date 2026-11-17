using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Services.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposProductoController : ControllerBase
    {
        private readonly TiendaContext _context;
        public TiposProductoController(TiendaContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoProducto>>> GetTipos([FromQuery] string filtro = "")
        {
            filtro = filtro.ToUpper();
            return await _context.TiposProducto.Where(t => t.Name.ToUpper().Contains(filtro)).ToListAsync();
        }

        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<TipoProducto>>> GetDeleteds() =>
            await _context.TiposProducto.IgnoreQueryFilters().Where(t => t.isDeleted).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoProducto>> GetTipo(int id)
        {
            var t = await _context.TiposProducto.FindAsync(id);
            if (t == null) return NotFound();
            return t;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipo(int id, TipoProducto tipo)
        {
            if (id != tipo.Id) return BadRequest();
            _context.Entry(tipo).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.TiposProducto.Any(e => e.Id == id)) return NotFound(); else throw; }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TipoProducto>> PostTipo(TipoProducto tipo)
        {
            _context.TiposProducto.Add(tipo);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTipo", new { id = tipo.Id }, tipo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipo(int id)
        {
            var t = await _context.TiposProducto.FindAsync(id);
            if (t == null) return NotFound();
            t.isDeleted = true;
            _context.Entry(t).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreTipo(int id)
        {
            var t = await _context.TiposProducto.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.Id == id);
            if (t == null) return NotFound();
            t.isDeleted = false;
            _context.Entry(t).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}