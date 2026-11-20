using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Services.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly TiendaContext _context;

        public ClientesController(TiendaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes([FromQuery] string filtro = "")
        {
            try
            {
                filtro = filtro.ToUpper();
                return await _context.Clientes
                    .Where(c => c.Firstname.ToUpper().Contains(filtro)
                        || c.Lastname.ToUpper().Contains(filtro)
                        || c.Dni.Contains(filtro)
                        || c.Address.ToUpper().Contains(filtro)
                        || c.Localidad.ToUpper().Contains(filtro)
                        || c.Provincia.ToUpper().Contains(filtro)
                        || c.Pais.ToUpper().Contains(filtro))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "internal server error", details = ex.Message, stack = ex.StackTrace });
            }
        }

        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetDeleteds()
        {
            return await _context.Clientes
                .IgnoreQueryFilters()
                .Where(c => c.isDeleted)
                .ToListAsync();
        }

        [HttpGet("total")]
        public async Task<ActionResult<int>> GetTotalClientes()
        {
            var total = await _context.Clientes.CountAsync(c => !c.isDeleted);
            return Ok(total);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Id == id);
            if (cliente == null) return NotFound();
            return cliente;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id) return BadRequest();
            _context.Entry(cliente).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Clientes.Any(e => e.Id == id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();
            cliente.isDeleted = true;
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreCliente(int id)
        {
            var cliente = await _context.Clientes.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == id);
            if (cliente == null) return NotFound();
            cliente.isDeleted = false;
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ClienteExists(int id) => _context.Clientes.Any(e => e.Id == id);
    }
}
