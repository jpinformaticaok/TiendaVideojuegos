using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Services.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly TiendaContext _context;
        public ProductosController(TiendaContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos([FromQuery] string filtro = "")
        {
            filtro = filtro.ToUpper();
            return await _context.Productos
                .Include(p => p.TipoProducto)
                .Include(p => p.Plataforma)
                .Include(p => p.Formato)
                .Where(p => p.Name.ToUpper().Contains(filtro)
                    || p.Description.ToUpper().Contains(filtro)
                    || (p.Plataforma != null && p.Plataforma.Name.ToUpper().Contains(filtro))
                    || (p.Formato != null && p.Formato.Name.ToUpper().Contains(filtro)))
                .ToListAsync();
        }

        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetDeleteds() =>
            await _context.Productos.IgnoreQueryFilters()
                .Include(p => p.TipoProducto)
                .Include(p => p.Plataforma)
                .Include(p => p.Formato)
                .Where(p => p.isDeleted)
                .ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var p = await _context.Productos
                .Include(x => x.TipoProducto)
                .Include(x => x.Plataforma)
                .Include(x => x.Formato)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (p == null) return NotFound();
            return p;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id) return BadRequest();
            _context.Entry(producto).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) { if (!_context.Productos.Any(e => e.Id == id)) return NotFound(); else throw; }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProducto", new { id = producto.Id }, producto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var p = await _context.Productos.FindAsync(id);
            if (p == null) return NotFound();
            p.isDeleted = true;
            _context.Entry(p).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreProducto(int id)
        {
            var p = await _context.Productos.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.Id == id);
            if (p == null) return NotFound();
            p.isDeleted = false;
            _context.Entry(p).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
