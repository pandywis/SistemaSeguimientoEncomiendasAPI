using Encomiendas.Infrastructure.Context;
using Encomiendas.Infrastructure.Models; // Ajusta según dónde estén tus entidades de dominio/infraestructura
using Microsoft.EntityFrameworkCore;
using SistemaSeguimientoEncomiendas.Application.Contract;
using SistemaSeguimientoEncomiendas.Application.Dtos;
using SistemaSeguimientoEncomiendas.Domain.Entities;

namespace SistemaSeguimientoEncomiendas.Application.Services
{
    public class PaqueteService : IPaqueteService
    {
        private readonly AppDbContext _context;

        public PaqueteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PaqueteDTO>> ObtenerTodosAsync()
        {
            return await _context.Paquetes
                .Include(p => p.Cliente)
                .Select(p => new PaqueteDTO
                {
                    Id = p.Id,
                    Codigo = p.Codigo,
                    Descripcion = p.Descripcion,
                    Estado = p.Estado,
                    FechaEnvio = p.FechaEnvio,
                    ClienteId = p.ClienteId
                })
                .ToListAsync();
        }

        public async Task<PaqueteDTO?> ObtenerPorIdAsync(int id)
        {
            return await _context.Paquetes
                .Where(p => p.Id == id)
                .Select(p => new PaqueteDTO
                {
                    Id = p.Id,
                    Codigo = p.Codigo,
                    Descripcion = p.Descripcion,
                    Estado = p.Estado,
                    FechaEnvio = p.FechaEnvio,
                    ClienteId = p.ClienteId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> CrearAsync(CrearPaqueteDTO dto)
        {
            var cliente = await _context.Clientes.FindAsync(dto.ClienteId);
            if (cliente == null) return false;

            var paquete = new Paquete
            {
                Codigo = dto.Codigo,
                Descripcion = dto.Descripcion,
                Estado = dto.Estado,
                FechaEnvio = dto.FechaEnvio,
                ClienteId = dto.ClienteId
            };

            _context.Paquetes.Add(paquete);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ActualizarAsync(int id, CrearPaqueteDTO dto)
        {
            var paquete = await _context.Paquetes.FindAsync(id);
            if (paquete == null) return false;

            var cliente = await _context.Clientes.FindAsync(dto.ClienteId);
            if (cliente == null) return false;

            paquete.Codigo = dto.Codigo;
            paquete.Descripcion = dto.Descripcion;
            paquete.Estado = dto.Estado;
            paquete.FechaEnvio = dto.FechaEnvio;
            paquete.ClienteId = dto.ClienteId;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var paquete = await _context.Paquetes.FindAsync(id);
            if (paquete == null) return false;

            _context.Paquetes.Remove(paquete);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}