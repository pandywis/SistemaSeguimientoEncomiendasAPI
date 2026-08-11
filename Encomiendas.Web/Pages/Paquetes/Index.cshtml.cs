using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaSeguimientoEncomiendas.Application.Contract;
using SistemaSeguimientoEncomiendas.Application.Dtos;

namespace Encomiendas.Web.Pages.Paquetes
{
    public class IndexModel : PageModel
    {
        private readonly IPaqueteService _paqueteService;

        public IndexModel(IPaqueteService paqueteService)
        {
            _paqueteService = paqueteService;
        }
        public List<PaqueteViewModel> Paquetes { get; set; } = new();

        public async Task OnGetAsync()
        {
            try
            {
                var result = await _paqueteService.ObtenerTodosAsync();
                if (result != null)
                    Paquetes = result.Select(p => new PaqueteViewModel { Id = p.Id, Codigo = p.Codigo, Descripcion = p.Descripcion, Estado = p.Estado, FechaEnvio = p.FechaEnvio, ClienteId = p.ClienteId }).ToList();
            }
            catch
            {
                Paquetes = new List<PaqueteViewModel>();
            }
        }

        public class PaqueteViewModel
        {
            public int Id { get; set; }
            public string Codigo { get; set; } = string.Empty;
            public string Descripcion { get; set; } = string.Empty;
            public string Estado { get; set; } = string.Empty;
            public DateTime FechaEnvio { get; set; }
            public int ClienteId { get; set; }
        }
    }
}

