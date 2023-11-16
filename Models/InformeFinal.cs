using System.ComponentModel.DataAnnotations;

namespace ProyectoIIITrimProgramacion_Mecarap.Models
{
    public class InformeFinal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
}
