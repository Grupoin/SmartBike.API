using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartBike_Mobile.Models
{
    public class UsuarioLogin
    {
        [JsonPropertyName("correoInstitucional")]
        public string CorreoInstitucional { get; set; } = string.Empty;

        [JsonPropertyName("contrasena")]
        public string Contrasena { get; set; } = string.Empty;
    }

}
