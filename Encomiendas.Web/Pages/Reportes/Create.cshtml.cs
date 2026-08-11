using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using SistemaSeguimientoEncomiendas.Application.Contract;
using SistemaSeguimientoEncomiendas.Application.Dtos;

namespace Encomiendas.Web.Pages.Reportes
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();

        public void OnGet()
        {

        }

        private readonly IReporteService _reporteService;

        public CreateModel(IReporteService reporteService)
        {
            _reporteService = reporteService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                var dto = new CrearReporteDto
                {
                    Titulo = Input.Titulo,
                    Contenido = Input.Contenido
                };

                await _reporteService.Crear(dto);
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
            [StringLength(200)]
            public string Titulo { get; set; } = string.Empty;

            [Required]
            public string Contenido { get; set; } = string.Empty;
        }
    }
}
