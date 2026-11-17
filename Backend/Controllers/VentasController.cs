using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Services.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly TiendaContext _context;
        public VentasController(TiendaContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas([FromQuery] string filtro = "")
        {
            return await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Detalles).ThenInclude(d => d.Producto)
                .OrderByDescending(v => v.Date)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetVenta(int id)
        {
            var v = await _context.Ventas
                .Include(x => x.Cliente)
                .Include(x => x.Detalles).ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (v == null) return NotFound();
            return v;
        }

        [HttpPost]
        public async Task<ActionResult<Venta>> PostVenta(Venta venta)
        {
            // generar numero FAC-00001
            var last = await _context.Ventas.IgnoreQueryFilters().OrderByDescending(v => v.Id).FirstOrDefaultAsync();
            int next = (last?.Id ?? 0) + 1;
            venta.Number = $"FAC-{next:D5}";
            venta.Date = DateTimeOffset.UtcNow;

            // calcular subtotal/total y descontar stock
            decimal total = 0;
            foreach (var d in venta.Detalles)
            {
                d.Subtotal = d.Quantity * d.UnitPrice;
                total += d.Subtotal;
                var prod = await _context.Productos.FindAsync(d.ProductoId);
                if (prod != null)
                {
                    prod.Stock -= d.Quantity;
                    _context.Entry(prod).State = EntityState.Modified;
                }
            }
            venta.Total = total;

            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetVenta", new { id = venta.Id }, venta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            var v = await _context.Ventas.FindAsync(id);
            if (v == null) return NotFound();
            v.isDeleted = true;
            _context.Entry(v).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}