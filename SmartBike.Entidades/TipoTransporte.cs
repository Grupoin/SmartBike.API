using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike.Entidades
{
    public class TipoTransporte
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idtiptra")]
        public int IdTipTra { get; set; }

        [Required]
        [Column("detalles")]
        [StringLength(20)]
        public string Detalles { get; set; } = string.Empty;

        [Required]
        [Column("es_cero_emision")]
        public bool EsCeroEmision { get; set; }
    }
}
