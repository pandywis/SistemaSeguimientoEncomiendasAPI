using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;

namespace Encomiendas.Web.Pages.Paquetes
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();

        public List<SelectListItem> ClientesSelect { get; set; } = new();

        public async Task OnGetAsync()
        {
            // Cargar clientes para el select
            try
            {
                using var http = new HttpClient();
                http.BaseAddress = new Uri("https://localhost:7288/");
                var clientes = await http.GetFromJsonAsync<List<ClienteDto>>("api/clientes");
                if (clientes != null)
                {
                    ClientesSelect = clientes.Select(c => new SelectListItem(c.Nombre, c.Id.ToString())).ToList();
                }
            }
            catch
            {
                ClientesSelect = new List<SelectListItem>();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }

            using var http = new HttpClient();
            http.BaseAddress = new Uri("https://localhost:7288/");

            var dto = new
            {
                Codigo = Input.Codigo,
                Descripcion = Input.Descripcion,
                Estado = Input.Estado,
                FechaEnvio = Input.FechaEnvio,
                ClienteId = Input.ClienteId
            };

            var res = await http.PostAsJsonAsync("api/paquetes", dto);
            if (res.IsSuccessStatusCode)
                return RedirectToPage("./Index");

            ModelState.AddModelError(string.Empty, "No se pudo crear el paquete.");
            await OnGetAsync();
            return Page();
        }

        public class InputModel
        {
            [Required]
            public string Codigo { get; set; } = string.Empty;

            [Required]
            public string Descripcion { get; set; } = string.Empty;

            [Required]
            public string Estado { get; set; } = string.Empty;

            [Required]
            public DateTime FechaEnvio { get; set; } = DateTime.Now;

            [Required]
            public int ClienteId { get; set; }
        }

        private class ClienteDto
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
        }
    }
}
