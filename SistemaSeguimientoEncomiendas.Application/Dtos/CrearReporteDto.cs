using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaSeguimientoEncomiendas.Application.Dtos
{
    public class CrearReporteDto
    {
        [Required]
        [StringLength(200)]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public string Contenido { get; set; } = string.Empty;
    }
}
