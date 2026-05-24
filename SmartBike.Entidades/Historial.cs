using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike.Entidades
{
    public class Historial
    {
        [Key]
        [Column("idhi")]
        public int IdHi { get; set; }

        [Required]
        [Column("fecha")]
        public DateTime Fecha { get; set; }

        [Required]
        [Column("co2_acumulado")]
        public decimal Co2Acumulado { get; set; }

        [Required]
        [Column("id_usuario")]
        [StringLength(10)]
        public string IdUsuario { get; set; } = string.Empty;

        [Required]
        [Column("id_tipo_transporte")]
        public int IdTipoTransporte { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; } = null!;

        [ForeignKey("IdTipoTransporte")]
        public virtual TipoTransporte TipoTransporte { get; set; } = null!;
    }
}
