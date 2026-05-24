using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike.Entidades.DTos
{
    public class CamaraResponseDto
    {
        public int IdCam { get; set; }
        public string IdCamara { get; set; } = string.Empty;
        public string TipoTransporteDetalle { get; set; } = string.Empty;
        public string OperadorNombre { get; set; } = string.Empty;
        public string IpCamara { get; set; } = string.Empty;
        public DateTime FechaHoraAsignacion { get; set; }
    }
}
