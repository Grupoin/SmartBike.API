using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike.Entidades
{
    public class TipoUsuario
    {
        [Key]
        [Column("idtip")]
        public int IdTip { get; set; }

        [Required]
        [Column("detalle")]
        [StringLength(10)]
        public string Detalle { get; set; } = string.Empty;

    }
}
