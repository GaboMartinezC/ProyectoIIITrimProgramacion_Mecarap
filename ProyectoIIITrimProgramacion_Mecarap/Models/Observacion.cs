using System.ComponentModel.DataAnnotations;

namespace ProyectoIIITrimProgramacion_Mecarap.Models
{
    public class Observacion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        [Required]
        public string? Fecha { get; set; }
        [Required]
        public string? ImgUrl { get; set; }
    }
}
