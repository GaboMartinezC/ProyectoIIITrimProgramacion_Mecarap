using System.ComponentModel.DataAnnotations;

namespace ProyectoIIITrimProgramacion_Mecarap.Models
{
    public class Permiso
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Descripcion { get; set; }
    }
}
