using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike_Mobile.Models
{
    public class RegistroDiarioCreate
    {
        public decimal Co2Generado { get; set; }
        public string IdUsuario { get; set; } = string.Empty;
        public int IdTipoTransporte { get; set; }
        public int IdCamara { get; set; }
    }
}
