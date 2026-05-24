using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike.Entidades.DTos
{
    public class RegistroDiarioCreateDto
    {
        [Required(ErrorMessage = "El CO2 generado es obligatorio.")]
        public decimal Co2Generado { get; set; }

        [Required(ErrorMessage = "La cédula del usuario es obligatoria.")]
        [StringLength(10, ErrorMessage = "La cédula debe tener 10 caracteres.")]
        public string IdUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "El tipo de transporte es obligatorio.")]
        public int IdTipoTransporte { get; set; }

        [Required(ErrorMessage = "El ID de la cámara que registró el evento es obligatorio.")]
        public int IdCamara { get; set; }
    }
}
