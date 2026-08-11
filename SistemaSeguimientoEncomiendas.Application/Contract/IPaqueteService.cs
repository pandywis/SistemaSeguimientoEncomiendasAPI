using Encomiendas.Infrastructure.Models;
using SistemaSeguimientoEncomiendas.Application.Dtos; 
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaSeguimientoEncomiendas.Application.Contract
{
    public interface IPaqueteService
    {
        Task<List<Encomiendas.Infrastructure.Models.PaqueteDTO>> ObtenerTodosAsync();
        Task<Encomiendas.Infrastructure.Models.PaqueteDTO?> ObtenerPorIdAsync(int id);
        Task<bool> CrearAsync(Encomiendas.Infrastructure.Models.CrearPaqueteDTO dto);
        Task<bool> ActualizarAsync(int id, Encomiendas.Infrastructure.Models.CrearPaqueteDTO dto);
        Task<bool> EliminarAsync(int id);
    }
}