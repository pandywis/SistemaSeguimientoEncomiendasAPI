using Microsoft.AspNetCore.Mvc;
using SistemaSeguimientoEncomiendas.Application.Contract;
using SistemaSeguimientoEncomiendas.Application.Dtos;

namespace SistemaSeguimientoEncomiendasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly IReporteService _reporteService;

        public ReportesController(IReporteService reporteService)
        {
            _reporteService = reporteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReporteDto>>> GetReportes()
        {
            var r = await _reporteService.ObtenerTodos();
            return Ok(r);
        }

        [HttpPost]
        public async Task<ActionResult> CrearReporte(CrearReporteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _reporteService.Crear(dto);
            return Ok(new { mensaje = "Reporte creado." });
        }
    }
}
