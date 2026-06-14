using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaSeguimientoEncomiendasAPI.Data;
using SistemaSeguimientoEncomiendasAPI.DTOs;
using SistemaSeguimientoEncomiendasAPI.DTOS;
using SistemaSeguimientoEncomiendasAPI.Models;

namespace SistemaSeguimientoEncomiendasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaquetesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaquetesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/paquetes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetPaquetes()
        {
            var paquetes = await _context.Paquetes
                .Include(p => p.Cliente)
                .Select(p => new
                {
                    p.Id,
                    p.Codigo,
                    p.Descripcion,
                    p.Estado,
                    p.FechaEnvio,
                    Cliente = p.Cliente!.Nombre
                })
                .ToListAsync();

            return Ok(paquetes);
        }

        // GET: api/paquetes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetPaquete(int id)
        {
            var paquete = await _context.Paquetes
                .Include(p => p.Cliente)
                .Where(p => p.Id == id)
                .Select(p => new
                {
                    p.Id,
                    p.Codigo,
                    p.Descripcion,
                    p.Estado,
                    p.FechaEnvio,
                    Cliente = p.Cliente!.Nombre
                })
                .FirstOrDefaultAsync();

            if (paquete == null)
                return NotFound("Paquete no encontrado.");

            return Ok(paquete);
        }

        // POST: api/paquetes
        [HttpPost]
        public async Task<ActionResult> CrearPaquete(CrearPaqueteDTO dto)
        {
            var cliente = await _context.Clientes.FindAsync(dto.ClienteId);

            if (cliente == null)
                return BadRequest("El cliente especificado no existe.");

            var paquete = new Paquete
            {
                Codigo = dto.Codigo,
                Descripcion = dto.Descripcion,
                Estado = dto.Estado,
                FechaEnvio = dto.FechaEnvio,
                ClienteId = dto.ClienteId
            };

            _context.Paquetes.Add(paquete);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPaquete), new { id = paquete.Id }, paquete);
        }

        // PUT: api/paquetes/5
        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarPaquete(int id, CrearPaqueteDTO dto)
        {
            var paquete = await _context.Paquetes.FindAsync(id);

            if (paquete == null)
                return NotFound("Paquete no encontrado.");

            paquete.Codigo = dto.Codigo;
            paquete.Descripcion = dto.Descripcion;
            paquete.Estado = dto.Estado;
            paquete.FechaEnvio = dto.FechaEnvio;
            paquete.ClienteId = dto.ClienteId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/paquetes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarPaquete(int id)
        {
            var paquete = await _context.Paquetes.FindAsync(id);

            if (paquete == null)
                return NotFound("Paquete no encontrado.");

            _context.Paquetes.Remove(paquete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}