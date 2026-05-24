using SmartBike.Entidades.DTos;

namespace SmartBike.API.Servicios
{
    public interface IReporteServicio
    {
        Task<ReporteResponseDto> GenerarReporteMensualAsync(int idTipoTransporte, string periodo);
        Task<IEnumerable<ReporteResponseDto>> ObtenerHistoricoReportesAsync();
    }
}
