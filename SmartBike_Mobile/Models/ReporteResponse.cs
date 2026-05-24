using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike_Mobile.Models
{
    public class ReporteResponse
    {
        public int IdRep { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public string Periodo { get; set; } = string.Empty;
        public decimal TotalCo2 { get; set; }
        public string TipoTransporteDetalle { get; set; } = string.Empty;
    }
}
