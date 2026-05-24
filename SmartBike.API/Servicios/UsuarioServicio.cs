using Microsoft.EntityFrameworkCore;
using SmartBike.Entidades.DTos;
using SmartBike.Entidades;

namespace SmartBike.API.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly SmartBikeAPIContext _context;

        // Inyectamos el contexto de la base de datos que ya configuramos antes
        public UsuarioServicio(SmartBikeAPIContext context)
        {
            _context = context;
        }

        public async Task<UsuarioResponseDto?> RegistrarUsuarioAsync(UsuarioCreateDto usuarioDto)
        {
            // 1. Regla de negocio: Validar si la cédula ya existe en SQL Server para evitar duplicados
            var existe = await _context.Usuarios.AnyAsync(u => u.Cedula == usuarioDto.Cedula);
            if (existe)
            {
                throw new Exception("La cédula ya se encuentra registrada en el sistema.");
            }

            // 2. Mapear el DTO que viene del teléfono a la Entidad real de la Base de Datos
            var nuevoUsuario = new Usuario
            {
                Cedula = usuarioDto.Cedula,
                Nombres = usuarioDto.Nombres,
                Apellidos = usuarioDto.Apellidos,
                CorreoInstitucional = usuarioDto.CorreoInstitucional,
                Contrasena = usuarioDto.Contrasena,
                IdTipoUsuario = usuarioDto.IdTipoUsuario,
                FechaRegistro = DateTime.Now // El backend maneja de forma segura la hora del servidor
            };

            // 3. Agregar y guardar de forma asíncrona en SQL Server
            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();

            // 4. Retornar los datos limpios estructurados en el formato que la App requiere
            return await ObtenerPorCedulaAsync(nuevoUsuario.Cedula);
        }

        public async Task<UsuarioResponseDto?> ObtenerPorCedulaAsync(string cedula)
        {
            // Buscamos el usuario incluyendo los datos de su Tipo de Usuario (Estudiante/Docente)
            var usuario = await _context.Usuarios
                .Include(u => u.TipoUsuario)
                .FirstOrDefaultAsync(u => u.Cedula == cedula);

            if (usuario == null) return null;

            // Retornamos el DTO de respuesta transformado
            return new UsuarioResponseDto
            {
                Cedula = usuario.Cedula,
                NombreCompleto = $"{usuario.Nombres} {usuario.Apellidos}",
                CorreoInstitucional = usuario.CorreoInstitucional,
                Contrasena = usuario.Contrasena,
                TipoUsuarioDetalle = usuario.TipoUsuario?.Detalle ?? "No asignado",
                FechaRegistro = usuario.FechaRegistro
            };
        }

        // En UsuarioServicio.cs (La implementación)
        public async Task<UsuarioResponseDto?> ValidarLoginAsync(string correo, string contrasena)
        {
            var usuario = await _context.Usuarios
         .Include(u => u.TipoUsuario)
         .FirstOrDefaultAsync(u => u.CorreoInstitucional.Trim() == correo.Trim()
                                && u.Contrasena.Trim() == contrasena.Trim());

            if (usuario == null) return null;

            // Mapeo manual (Igual que en ObtenerPorCedulaAsync)
            return new UsuarioResponseDto
            {
                Cedula = usuario.Cedula,
                NombreCompleto = $"{usuario.Nombres} {usuario.Apellidos}",
                CorreoInstitucional = usuario.CorreoInstitucional,
                Contrasena = usuario.Contrasena,
                TipoUsuarioDetalle = usuario.TipoUsuario?.Detalle ?? "No asignado",
                FechaRegistro = usuario.FechaRegistro
            };
        }
    }
}
