using System.ComponentModel.DataAnnotations;

namespace Encomiendas.Infrastructure.Models;

    public class CrearClienteDTO
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        public string Direccion { get; set; } = string.Empty;
    }

