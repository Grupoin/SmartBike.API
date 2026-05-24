using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike.Entidades.DTos
{
    public class TipoUsuarioResponseDto
    {
        public int IdTip { get; set; }
        public string Detalle { get; set; } = string.Empty;
    }
}
