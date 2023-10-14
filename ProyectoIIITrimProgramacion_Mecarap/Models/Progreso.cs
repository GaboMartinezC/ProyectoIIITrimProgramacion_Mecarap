using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIIITrimProgramacion_Mecarap.Models
{
    public class Progreso
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        [Required]
        public int IdObservacion { get; set; }
        [ForeignKey("IdObservacion")]
        public virtual Observacion? Observacion { get; set; }
        [Required]
        public bool? Borrado { get; set; }
    }
}
