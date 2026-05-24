using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike.Entidades
{
    public class Camara
    {
        [Key]
        [Column("idcam")]
        public int IdCam { get; set; }

        [Required]
        [Column("id_camara")]
        public string IdCamara { get; set; } = string.Empty;

        [Required]
        [Column("id_tipo_transporte")]
        public int IdTipoTransporte { get; set; }

        [Required]
        [Column("id_usuario")]
        [StringLength(10)]
        public string IdUsuario { get; set; } = string.Empty;

        [Required]
        [Column("fecha_hora")]
        public DateTime FechaHora { get; set; }

        [Required]
        [Column("ip_camara")]
        [StringLength(50)]
        public string IpCamara { get; set; } = string.Empty;

        [ForeignKey("IdTipoTransporte")]
        public virtual TipoTransporte TipoTransporte { get; set; } = null!;

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; } = null!;
    }
}
