using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike.Entidades
{
    public class ConteoCamara
    {
        [Key]
        [Column("id_conte_cama")]
        public int IdConteCama { get; set; }

        [Required]
        [Column("nombre_camara")]
        [StringLength(20)]
        public string NombreCamara { get; set; } = string.Empty;

        [Required]
        [Column("ip_camara")]
        [StringLength(50)]
        public string IpCamara { get; set; } = string.Empty;

        [Required]
        [Column("estado")]
        public bool Estado { get; set; }

        [Required]
        [Column("id_tipo_transporte")]
        public int IdTipoTransporte { get; set; }

        [Required]
        [Column("fecha")]
        public DateTime Fecha { get; set; }

        [ForeignKey("IdTipoTransporte")]
        public virtual TipoTransporte TipoTransporte { get; set; } = null!;
    }
}
