using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Encomiendas.Infrastructure.Context;
using SistemaSeguimientoEncomiendas.Application.Contract;
using SistemaSeguimientoEncomiendas.Application.Dtos;
using SistemaSeguimientoEncomiendas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace SistemaSeguimientoEncomiendas.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly AppDbContext _db;

        public ClienteService(AppDbContext db)
        {
            _db = db;
        }

        public async Task Crear(CrearClienteDto dto)
        {
            var entidad = new Cliente
            {
                Nombre = dto.Nombre,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion
            };

            _db.Clientes.Add(entidad);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ClienteDto>> ObtenerTodos()
        {
            return await _db.Clientes
                .AsNoTracking()
                .Select(c => new ClienteDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Telefono = c.Telefono,
                    Direccion = c.Direccion
                })
                .ToListAsync();
        }

        public async Task<ClienteDto?> ObtenerPorId(int id)
        {
            var c = await _db.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (c == null) return null;

            return new ClienteDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Telefono = c.Telefono,
                Direccion = c.Direccion
            };
        }

        public async Task Actualizar(int id, CrearClienteDto dto)
        {
            var entidad = await _db.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if (entidad == null)
                throw new KeyNotFoundException("Cliente no encontrado.");

            entidad.Nombre = dto.Nombre;
            entidad.Telefono = dto.Telefono;
            entidad.Direccion = dto.Direccion;

            await _db.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var entidad = await _db.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if (entidad == null)
                throw new KeyNotFoundException("Cliente no encontrado.");

            _db.Clientes.Remove(entidad);
            await _db.SaveChangesAsync();
        }
    }
}
