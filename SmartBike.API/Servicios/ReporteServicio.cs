using Microsoft.EntityFrameworkCore;
using SmartBike.Entidades.DTos;
using SmartBike.Entidades;

namespace SmartBike.API.Servicios
{
    public class ReporteServicio : IReporteServicio
    {
        private readonly SmartBikeAPIContext _context;

        public ReporteServicio(SmartBikeAPIContext context)
        {
            _context = context;
        }

        public async Task<ReporteResponseDto> GenerarReporteMensualAsync(int idTipoTransporte, string periodo)
        {
            // Sumamos todo el CO2 registrado en la base para ese transporte específico
            var sumaCo2 = await _context.RegistroDiarios
                .Where(r => r.IdTipoTransporte == idTipoTransporte)
                .SumAsync(r => r.Co2Generado);

            var nuevoReporte = new Reporte
            {
                FechaGeneracion = DateTime.Now,
                Periodo = periodo,
                TotalCo2 = sumaCo2,
                IdTipoTransporte = idTipoTransporte
            };

            _context.Reportes.Add(nuevoReporte);
            await _context.SaveChangesAsync();

            var trans = await _context.TipoTransportes.FindAsync(idTipoTransporte);

            return new ReporteResponseDto
            {
                IdRep = nuevoReporte.IdRep,
                FechaGeneracion = nuevoReporte.FechaGeneracion,
                Periodo = nuevoReporte.Periodo,
                TotalCo2 = nuevoReporte.TotalCo2,
                TipoTransporteDetalle = trans?.Detalles ?? "Desconocido"
            };
        }

        public async Task<IEnumerable<ReporteResponseDto>> ObtenerHistoricoReportesAsync()
        {
            return await _context.Reportes
                .Include(r => r.TipoTransporte)
                .OrderByDescending(r => r.FechaGeneracion)
                .Select(r => new ReporteResponseDto
                {
                    IdRep = r.IdRep,
                    FechaGeneracion = r.FechaGeneracion,
                    Periodo = r.Periodo,
                    TotalCo2 = r.TotalCo2,
                    TipoTransporteDetalle = r.TipoTransporte.Detalles
                })
                .ToListAsync();
        }
    }
}
