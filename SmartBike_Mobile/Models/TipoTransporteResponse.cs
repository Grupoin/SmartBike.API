using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike_Mobile.Models
{
    public class TipoTransporteResponse
    {
        public int IdTipTra { get; set; }
        public string Detalles { get; set; } = string.Empty;
        public bool EsCeroEmision { get; set; }
    }
}
