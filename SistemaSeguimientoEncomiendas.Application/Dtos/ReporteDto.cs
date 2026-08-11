using System;

namespace SistemaSeguimientoEncomiendas.Application.Dtos
{
    public class ReporteDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Contenido { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
    }
}
