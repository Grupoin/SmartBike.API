using SmartBike.Entidades.DTos;

namespace SmartBike.API.Servicios
{
    public interface ICamaraServicio
    {
        Task<CamaraResponseDto> RegistrarAsync(CamaraCreateDto dto);
        Task<IEnumerable<CamaraResponseDto>> ObtenerTodasAsync();
    }
}
