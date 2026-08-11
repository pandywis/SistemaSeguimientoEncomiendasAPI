using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaSeguimientoEncomiendas.Domain.Entities;

    public class Reporte
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public string Contenido { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
