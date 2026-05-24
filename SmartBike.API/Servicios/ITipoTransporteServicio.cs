using SmartBike.Entidades.DTos;

namespace SmartBike.API.Servicios
{
    public interface ITipoTransporteServicio
    {
        Task<TipoTransporteResponseDto> CrearAsync(TipoTransporteCreateDto dto);
        Task<IEnumerable<TipoTransporteResponseDto>> ObtenerTodosAsync();
    }
}
