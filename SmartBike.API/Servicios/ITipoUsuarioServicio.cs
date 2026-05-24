using SmartBike.Entidades.DTos;

namespace SmartBike.API.Servicios
{
    public interface ITipoUsuarioServicio
    {
        Task<IEnumerable<TipoUsuarioResponseDto>> ObtenerTodosAsync();
    }
}
