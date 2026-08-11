using Microsoft.EntityFrameworkCore;
using SistemaSeguimientoEncomiendas.Domain.Entities;

namespace Encomiendas.Infrastructure.Context;


    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Paquete> Paquetes { get; set; }

        public DbSet<SistemaSeguimientoEncomiendas.Domain.Entities.Reporte> Reportes { get; set; }


    }
