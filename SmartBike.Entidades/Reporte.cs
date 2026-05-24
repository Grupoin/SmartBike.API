using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike.Entidades
{
    public class Reporte
    {
        [Key]
        [Column("idrep")]
        public int IdRep { get; set; }

        [Required]
        [Column("fecha_generacion")]
        public DateTime FechaGeneracion { get; set; }

        [Required]
        [Column("periodo")]
        [StringLength(20)]
        public string Periodo { get; set; } = string.Empty;

        [Required]
        [Column("total_co2")]
        public decimal TotalCo2 { get; set; }

        [Required]
        [Column("id_tipo_transporte")]
        public int IdTipoTransporte { get; set; }

        [ForeignKey("IdTipoTransporte")]
        public virtual TipoTransporte TipoTransporte { get; set; } = null!;

    }
}
