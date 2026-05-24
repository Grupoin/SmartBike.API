using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike.Entidades.DTos
{
    public class UsuarioCreateDto
    {
        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "La cédula debe tener exactamente 10 caracteres.")]
        public string Cedula { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(10, ErrorMessage = "El nombre no puede superar los 10 caracteres.")]
        public string Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(10, ErrorMessage = "El apellido no puede superar los 10 caracteres.")]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo institucional es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido.")]
        [StringLength(50, ErrorMessage = "El correo no puede superar los 50 caracteres.")]
        public string CorreoInstitucional { get; set; } = string.Empty;
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string Contrasena { get; set; } = string.Empty;

        [Required(ErrorMessage = "El tipo de usuario es obligatorio.")]
        public int IdTipoUsuario { get; set; }
    }
 
}
