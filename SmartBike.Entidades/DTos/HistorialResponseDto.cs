using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike.Entidades.DTos
{
    public class HistorialResponseDto
    {
        public int IdHi { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Co2Acumulado { get; set; }
        public string UsuarioNombre { get; set; } = string.Empty;
        public string TransporteDetalle { get; set; } = string.Empty;
    }
}
