using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike.Entidades.DTos
{
    public class ReporteResponseDto
    {
        public int IdRep { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public string Periodo { get; set; } = string.Empty; // Ej: "Mayo 2026"
        public decimal TotalCo2 { get; set; }
        public string TipoTransporteDetalle { get; set; } = string.Empty;
    }
}
