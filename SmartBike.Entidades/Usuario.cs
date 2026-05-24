using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartBike.Entidades
{
    public class Usuario
    {
        [Key]
        [Column("cedula")]
        [StringLength(10)]
        public string Cedula { get; set; } = string.Empty;

        [Required]
        [Column("nombres")]
        [StringLength(100)]
        public string Nombres { get; set; } = string.Empty;

        [Required]
        [Column("apellidos")]
        [StringLength(100)]
        public string Apellidos { get; set; } = string.Empty;

        [Required]
        [Column("correo_institucional")]
        [StringLength(50)]
        public string CorreoInstitucional { get; set; } = string.Empty;

        [Required]
        [Column("fecharegistro")]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // CORREGIDO: Cambiado a int para solucionar el error del cuadro de diálogo
        [Required]
        [Column("id_tipo_usuario")]
        public int IdTipoUsuario { get; set; }
        [Required]
        [Column("contrasena")]  
        [StringLength(100)]
        public string Contrasena { get; set; } = string.Empty;

        [ForeignKey("IdTipoUsuario")]
        public virtual TipoUsuario TipoUsuario { get; set; } = null!;
    }
}
