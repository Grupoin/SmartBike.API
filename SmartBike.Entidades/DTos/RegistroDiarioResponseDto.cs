using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike.Entidades.DTos
{
    public class RegistroDiarioResponseDto
    {
        public int IdReg { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Co2Generado { get; set; }
        public string UsuarioNombre { get; set; } = string.Empty;
        public string TransporteDetalle { get; set; } = string.Empty;
        public string CamaraCodigo { get; set; } = string.Empty;
    }
}
