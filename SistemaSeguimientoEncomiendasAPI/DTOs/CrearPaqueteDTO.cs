using System.ComponentModel.DataAnnotations;

namespace SistemaSeguimientoEncomiendasAPI.DTOS
{
    public class CrearPaqueteDTO
    {
        [Required]
        public string Codigo { get; set; } = string.Empty;

        [Required]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public string Estado { get; set; } = string.Empty;

        [Required]
        public DateTime FechaEnvio { get; set; }

        [Required]
        public int ClienteId { get; set; }
    }
}
