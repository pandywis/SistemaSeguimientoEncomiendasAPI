using Encomiendas.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

using SistemaSeguimientoEncomiendas.Application.Dtos;

namespace SistemaSeguimientoEncomiendas.Application.Contract
{
    public interface IClienteService
    {
        Task<List<ClienteDto>> ObtenerTodos();

        Task<ClienteDto?> ObtenerPorId(int id);

        Task Crear(CrearClienteDto dto);

        Task Actualizar(int id, CrearClienteDto dto);

        Task Eliminar(int id);
    }
}