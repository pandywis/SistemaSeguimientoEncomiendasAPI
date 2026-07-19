using System;
using System.Collections.Generic;
using System.Text;

using SistemaSeguimientoEncomiendas.Application.Contract;
using SistemaSeguimientoEncomiendas.Application.Dtos;

namespace SistemaSeguimientoEncomiendas.Application.Services
{
    public class PaqueteService : IPaqueteService
    {
        public Task Actualizar(int id, CrearPaqueteDto dto)
        {
            throw new NotImplementedException();
        }

        public Task Crear(CrearPaqueteDto dto)
        {
            throw new NotImplementedException();
        }

        public Task Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaqueteDto?> ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PaqueteDto>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}