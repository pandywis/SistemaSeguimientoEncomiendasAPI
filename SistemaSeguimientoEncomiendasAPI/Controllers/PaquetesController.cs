using Microsoft.AspNetCore.Mvc;
using SistemaSeguimientoEncomiendas.Application.Contract;
using Encomiendas.Infrastructure.Models; // Mantiene tus DTOs si están aquí

namespace SistemaSeguimientoEncomiendasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaquetesController : ControllerBase
    {
        private readonly IPaqueteService _paqueteService;

        // Inyectamos la interfaz del servicio en lugar del AppDbContext
        public PaquetesController(IPaqueteService paqueteService)
        {
            _paqueteService = paqueteService;
        }

        // GET: api/paquetes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetPaquetes()
        {
            var paquetes = await _paqueteService.ObtenerTodosAsync();
            return Ok(paquetes);
        }

        // GET: api/paquetes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetPaquete(int id)
        {
            var paquete = await _paqueteService.ObtenerPorIdAsync(id);
            if (paquete == null)
                return NotFound("Paquete no encontrado.");

            return Ok(paquete);
        }

        // POST: api/paquetes
        [HttpPost]
        public async Task<ActionResult> CrearPaquete(CrearPaqueteDTO dto)
        {
            var exito = await _paqueteService.CrearAsync(dto);
            if (!exito)
                return BadRequest("El cliente especificado no existe o no se pudo crear el paquete.");

            return Ok("Paquete creado con éxito.");
        }

        // PUT: api/paquetes/5
        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarPaquete(int id, CrearPaqueteDTO dto)
        {
            var exito = await _paqueteService.ActualizarAsync(id, dto);
            if (!exito)
                return NotFound("Paquete o Cliente no encontrado.");

            return NoContent();
        }

        // DELETE: api/paquetes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarPaquete(int id)
        {
            var exito = await _paqueteService.EliminarAsync(id);
            if (!exito)
                return NotFound("Paquete no encontrado.");

            return NoContent();
        }
    }
}