using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaSeguimientoEncomiendas.Application.Dtos;

namespace SistemaSeguimientoEncomiendas.Application.Contract
{
    public interface IReporteService
    {
        Task<List<ReporteDto>> ObtenerTodos();
        Task<ReporteDto?> ObtenerPorId(int id);
        Task Crear(CrearReporteDto dto);
    }
}
