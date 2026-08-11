using Microsoft.AspNetCore.Mvc;
using SistemaSeguimientoEncomiendas.Application.Contract;
using SistemaSeguimientoEncomiendas.Application.Dtos;

namespace SistemaSeguimientoEncomiendasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetClientes()
        {
            var clientes = await _clienteService.ObtenerTodos();
            return Ok(clientes);
        }

        // GET: api/clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> GetCliente(int id)
        {
            var cliente = await _clienteService.ObtenerPorId(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        // POST: api/clientes
        [HttpPost]
        public async Task<ActionResult> CrearCliente(CrearClienteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _clienteService.Crear(dto);

            return Ok(new
            {
                mensaje = "Cliente creado correctamente."
            });
        }

        // PUT: api/clientes/5
        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarCliente(int id, CrearClienteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _clienteService.Actualizar(id, dto);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        // DELETE: api/clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarCliente(int id)
        {
            try
            {
                await _clienteService.Eliminar(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}