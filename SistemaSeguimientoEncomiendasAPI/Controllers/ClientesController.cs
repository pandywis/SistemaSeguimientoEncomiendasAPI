using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaSeguimientoEncomiendasAPI.Data;
using SistemaSeguimientoEncomiendasAPI.DTOs;
using SistemaSeguimientoEncomiendasAPI.Models;

namespace SistemaSeguimientoEncomiendasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientes()
        {
            var clientes = await _context.Clientes
                .Select(c => new ClienteDTO
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Telefono = c.Telefono,
                    Direccion = c.Direccion
                })
                .ToListAsync();

            return Ok(clientes);
        }

        // GET: api/clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound();

            return new ClienteDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion
            };
        }

        // POST: api/clientes
        [HttpPost]
        public async Task<ActionResult> CrearCliente(CrearClienteDTO dto)
        {
            var cliente = new Cliente
            {
                Nombre = dto.Nombre,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
        }

        // PUT: api/clientes/5
        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarCliente(int id, CrearClienteDTO dto)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound();

            cliente.Nombre = dto.Nombre;
            cliente.Telefono = dto.Telefono;
            cliente.Direccion = dto.Direccion;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound();

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}