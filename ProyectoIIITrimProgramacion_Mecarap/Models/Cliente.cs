using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIIITrimProgramacion_Mecarap.Models
{
    public class Cliente
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Pass { get; set; }
        [Required]
        public bool? Borrado { get; set; }

    }
}
