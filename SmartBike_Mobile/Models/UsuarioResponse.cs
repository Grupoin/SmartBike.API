using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike_Mobile.Models
{
    public class UsuarioResponse
    {
        public string Cedula { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string CorreoInstitucional { get; set; } = string.Empty;
        public string TipoUsuarioDetalle { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
    }
}
