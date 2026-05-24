using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike.Entidades.DTos
{
    public class TipoTransporteResponseDto
    {
        public int IdTipTra { get; set; }
        public string Detalles { get; set; } = string.Empty;
        public bool EsCeroEmision { get; set; }
    }
}
