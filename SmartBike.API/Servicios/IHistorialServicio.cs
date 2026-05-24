using SmartBike.Entidades.DTos;

namespace SmartBike.API.Servicios
{
    public interface IHistorialServicio
    {
        Task<IEnumerable<HistorialResponseDto>> ObtenerResumenUsuarioAsync(string cedula);
    }
}
