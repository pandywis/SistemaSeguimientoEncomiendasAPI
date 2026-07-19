using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace SistemaSeguimientoEncomiendas.Application.Dtos
{
    public class CrearPaqueteDto
    {
        [Required(ErrorMessage = "El código es obligatorio.")]
        [StringLength(50)]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(200)]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [StringLength(50)]
        public string Estado { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de envío es obligatoria.")]
        public DateTime FechaEnvio { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un cliente.")]
        public int ClienteId { get; set; }
    }
}