using Microsoft.EntityFrameworkCore;
using SistemaSeguimientoEncomiendasAPI.Models;

namespace SistemaSeguimientoEncomiendasAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Paquete> Paquetes { get; set; }


    }
}
