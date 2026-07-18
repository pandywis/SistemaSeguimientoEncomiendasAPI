using System.ComponentModel.DataAnnotations;

namespace SistemaSeguimientoEncomiendas.Domain.Entities;

    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(15)]
        public string Telefono { get; set; }

        [Required]
        [MaxLength(200)]
        public string Direccion { get; set; }

        // Un cliente puede tener muchos paquetes
        public ICollection<Paquete>? Paquetes { get; set; }
    }

