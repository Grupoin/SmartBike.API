using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartBike_Mobile.Models
{
    public class TipoUsuarioResponse
    {
        [JsonPropertyName("idtip")]
        public int IdTip { get; set; }
        [JsonPropertyName("detalle")]
        public string Detalle { get; set; } = string.Empty;
    }
}
