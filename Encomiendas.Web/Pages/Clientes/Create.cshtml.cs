using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using SistemaSeguimientoEncomiendas.Application.Contract;
using SistemaSeguimientoEncomiendas.Application.Dtos;

namespace Encomiendas.Web.Pages.Clientes
{
    public class CreateModel : PageModel
    {
        private readonly IClienteService _clienteService;

        public CreateModel(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        [BindProperty(SupportsGet = true)]
        public string? ReturnUrl { get; set; }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                var dto = new CrearClienteDto
                {
                    Nombre = Input.Nombre,
                    Telefono = Input.Telefono,
                    Direccion = Input.Direccion
                };

                await _clienteService.Crear(dto);
                if (!string.IsNullOrEmpty(ReturnUrl) && ReturnUrl.StartsWith("/"))
                    return LocalRedirect(ReturnUrl);

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error al guardar: {ex.Message}");
                return Page();
            }
        }

        public class InputModel
        {
            [Required]
            [StringLength(100)]
            public string Nombre { get; set; } = string.Empty;

            [Required]
            [Phone]
            [StringLength(15)]
            public string Telefono { get; set; } = string.Empty;

            [Required]
            [StringLength(200)]
            public string Direccion { get; set; } = string.Empty;
        }
    }
}
