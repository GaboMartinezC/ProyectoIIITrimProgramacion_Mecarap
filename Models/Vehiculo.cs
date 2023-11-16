using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIIITrimProgramacion_Mecarap.Models
{
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        [Required]
        public string? Modelo { get; set; }
        [Required]
        public int IdTipoAuto { get; set; }
        [ForeignKey("IdTipoAuto")]
        public virtual TipoAuto? TipoAuto { get; set; }
        public int IdPropietario { get; set; }
        [ForeignKey("IdPropietario")]
        public virtual Cliente? Usuario { get; set; }
        [Required]
        public bool Borrado { get; set; }
    }
}
