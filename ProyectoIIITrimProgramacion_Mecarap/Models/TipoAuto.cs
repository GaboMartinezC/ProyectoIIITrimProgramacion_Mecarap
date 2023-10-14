using System.ComponentModel.DataAnnotations;

namespace ProyectoIIITrimProgramacion_Mecarap.Models
{
    public class TipoAuto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        [Required]
        public string? ImgUrl { get; set; }
        [Required]
        public bool? Borrado { get; set; }
    }
}
