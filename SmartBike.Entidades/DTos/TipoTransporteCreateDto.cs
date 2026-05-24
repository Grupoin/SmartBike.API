using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike.Entidades.DTos
{
    public class TipoTransporteCreateDto
    {
        [Required(ErrorMessage = "El detalle del transporte es obligatorio.")]
        [StringLength(20, ErrorMessage = "El detalle no puede superar los 20 caracteres.")]
        public string Detalles { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe especificar si es cero emisiones.")]
        public bool EsCeroEmision { get; set; }
    }
}
