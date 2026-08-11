using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaSeguimientoEncomiendas.Application.Contract;
using SistemaSeguimientoEncomiendas.Application.Dtos;

namespace Encomiendas.Web.Pages.Reportes
{
    public class IndexModel : PageModel
    {
        private readonly IReporteService _reporteService;

        public IndexModel(IReporteService reporteService)
        {
            _reporteService = reporteService;
        }
        public List<ReporteViewModel> Reportes { get; set; } = new();

        public async Task OnGetAsync()
        {
            try
            {
                var res = await _reporteService.ObtenerTodos();
                if (res != null)
                    Reportes = res.Select(r => new ReporteViewModel { Id = r.Id, Titulo = r.Titulo, Contenido = r.Contenido, FechaCreacion = r.FechaCreacion }).ToList();
            }
            catch
            {
                Reportes = new List<ReporteViewModel>();
            }
        }

        public class ReporteViewModel
        {
            public int Id { get; set; }
            public string Titulo { get; set; } = string.Empty;
            public string Contenido { get; set; } = string.Empty;
            public DateTime FechaCreacion { get; set; }
        }
    }
}
