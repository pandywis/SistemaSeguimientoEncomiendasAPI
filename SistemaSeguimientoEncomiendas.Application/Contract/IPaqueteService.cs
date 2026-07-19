using System;
using System.Collections.Generic;
using System.Text;
using SistemaSeguimientoEncomiendas.Application.Dtos;

namespace SistemaSeguimientoEncomiendas.Application.Contract
{
    public interface IPaqueteService
    {
        Task<List<PaqueteDto>> ObtenerTodos();

        Task<PaqueteDto?> ObtenerPorId(int id);

        Task Crear(CrearPaqueteDto dto);

        Task Actualizar(int id, CrearPaqueteDto dto);

        Task Eliminar(int id);
    }
}