using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaSeguimientoEncomiendas.Application.Contract;
using SistemaSeguimientoEncomiendas.Application.Dtos;

namespace Encomiendas.Web.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly IClienteService _clienteService;

        public IndexModel(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        public List<ClienteViewModel> Clientes { get; set; } = new();

        public async Task OnGetAsync()
        {
            try
            {
                var result = await _clienteService.ObtenerTodos();
                Clientes = result.Select(c => new ClienteViewModel { Id = c.Id, Nombre = c.Nombre, Telefono = c.Telefono, Direccion = c.Direccion }).ToList();
            }
            catch
            {
                Clientes = new List<ClienteViewModel>();
            }
        }

        public class ClienteViewModel
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
            public string Telefono { get; set; } = string.Empty;
            public string Direccion { get; set; } = string.Empty;
        }
    }
}
