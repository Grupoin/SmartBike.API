using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike_Mobile.Models
{
    public class UsuarioCreate
    {
        public string Cedula { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string CorreoInstitucional { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public int IdTipoUsuario { get; set; }
    }
}
