using System;
using System.Collections.Generic;
using System.Text;

using SistemaSeguimientoEncomiendas.Application.Contract;
using SistemaSeguimientoEncomiendas.Application.Dtos;

namespace SistemaSeguimientoEncomiendas.Application.Services
{
    public class ClienteService : IClienteService
    {
        public Task Actualizar(int id, CrearClienteDto dto)
        {
            throw new NotImplementedException();
        }

        public Task Crear(CrearClienteDto dto)
        {
            throw new NotImplementedException();
        }

        public Task Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteDto?> ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClienteDto>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}