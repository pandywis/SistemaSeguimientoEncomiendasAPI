using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaSeguimientoEncomiendas.Application.Dtos
{
    public class PaqueteDto
    {
        public int Id { get; set; }

        public string Codigo { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public DateTime FechaEnvio { get; set; }

        public int ClienteId { get; set; }
    }
}