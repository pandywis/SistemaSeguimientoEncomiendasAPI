using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaSeguimientoEncomiendas.Domain.Entities;

    public class Paquete
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(200)]
        public string Descripcion { get; set; }

        [Required]
        [MaxLength(50)]
        public string Estado { get; set; }

        public DateTime FechaEnvio { get; set; }

        // Llave foránea
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        // Relación
        public Cliente? Cliente { get; set; }
    }

