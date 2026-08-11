using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Encomiendas.Infrastructure.Context;
using SistemaSeguimientoEncomiendas.Application.Contract;
using SistemaSeguimientoEncomiendas.Application.Dtos;
using SistemaSeguimientoEncomiendas.Domain.Entities;

namespace SistemaSeguimientoEncomiendas.Application.Services
{
    public class ReporteService : IReporteService
    {
        private readonly AppDbContext _db;

        public ReporteService(AppDbContext db)
        {
            _db = db;
        }

        public async Task Crear(CrearReporteDto dto)
        {
            var entidad = new Reporte
            {
                Titulo = dto.Titulo,
                Contenido = dto.Contenido
            };

            _db.Add(entidad);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ReporteDto>> ObtenerTodos()
        {
            return await _db.Set<Reporte>()
                .AsNoTracking()
                .Select(r => new ReporteDto
                {
                    Id = r.Id,
                    Titulo = r.Titulo,
                    Contenido = r.Contenido,
                    FechaCreacion = r.FechaCreacion
                }).ToListAsync();
        }

        public async Task<ReporteDto?> ObtenerPorId(int id)
        {
            var r = await _db.Set<Reporte>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (r == null) return null;
            return new ReporteDto { Id = r.Id, Titulo = r.Titulo, Contenido = r.Contenido, FechaCreacion = r.FechaCreacion };
        }
    }
}
