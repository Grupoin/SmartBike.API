using SmartBike.Entidades.DTos;

namespace SmartBike.API.Servicios
{
    public interface IUsuarioServicio
    {
        // Contrato para registrar un nuevo usuario desde la App Móvil
        Task<UsuarioResponseDto?> RegistrarUsuarioAsync(UsuarioCreateDto usuarioDto);

        // Contrato para buscar un usuario por su cédula (útil para el Login)
        Task<UsuarioResponseDto?> ObtenerPorCedulaAsync(string cedula);
        Task<UsuarioResponseDto?> ValidarLoginAsync(string correo, string contrasena);
    }
}
