using SmartBike.Entidades.DTos;

namespace SmartBike.API.Servicios
{
    public interface IRegistroDiarioServicio
    {
        Task<RegistroDiarioResponseDto> RegistrarActividadAsync(RegistroDiarioCreateDto dto);
        Task<IEnumerable<RegistroDiarioResponseDto>> ObtenerPorUsuarioAsync(string cedula);
    }
}
