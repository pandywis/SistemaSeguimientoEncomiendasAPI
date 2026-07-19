using Microsoft.EntityFrameworkCore;
using Encomiendas.Infrastructure.Context;
using SistemaSeguimientoEncomiendas.Application.Contract;
using SistemaSeguimientoEncomiendas.Application.Dtos;
using SistemaSeguimientoEncomiendas.Domain.Entities;

namespace SistemaSeguimientoEncomiendas.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClienteDto>> ObtenerTodos()
        {
            return await _context.Clientes
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
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                return null;

            return new ClienteDto
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion
            };
        }

        public async Task Crear(CrearClienteDto dto)
        {
            var cliente = new Cliente
            {
                Nombre = dto.Nombre,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(int id, CrearClienteDto dto)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                throw new Exception("Cliente no encontrado.");

            cliente.Nombre = dto.Nombre;
            cliente.Telefono = dto.Telefono;
            cliente.Direccion = dto.Direccion;

            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                throw new Exception("Cliente no encontrado.");

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}