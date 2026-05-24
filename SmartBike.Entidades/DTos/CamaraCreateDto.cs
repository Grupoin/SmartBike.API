using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike.Entidades.DTos
{
    public class CamaraCreateDto
    {
        [Required(ErrorMessage = "El código identificador de la cámara es obligatorio.")]
        public string IdCamara { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe asignar un tipo de transporte a monitorear.")]
        public int IdTipoTransporte { get; set; }

        [Required(ErrorMessage = "Debe asignar el usuario/operador responsable.")]
        [StringLength(10, ErrorMessage = "La cédula debe tener 10 caracteres.")]
        public string IdUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección IP de la cámara es obligatoria.")]
        [RegularExpression(@"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$",
            ErrorMessage = "El formato de la dirección IP no es válido.")]
        public string IpCamara { get; set; } = string.Empty;
    }
}
