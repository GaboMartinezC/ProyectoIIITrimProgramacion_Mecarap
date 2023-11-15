using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIIITrimProgramacion_Mecarap.Models
{
    public class TipoUsuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        [Required]
        public bool? Borrado { get; set; }
    }
}
